using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyQuanBilliard.Models;
using QuanLyQuanBilliard.Models.EF;

namespace QuanLyQuanBilliard.Controllers
{
    [AuthorizeRole("Quản Lý", "Tiếp Tân")]
    public class HoaDonController : Controller
    {
        private readonly QuanLyQuanBilliardContext _context;

        public HoaDonController(QuanLyQuanBilliardContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var hoaDons = _context.HoaDons.Include(h => h.NhanVien)
                                           .Include(h => h.Ban)
                                           .Include(h => h.HoaDonChiTiets)
                                           .OrderByDescending(h => h.HoaDonId)
                                           .ToList();
            return View(hoaDons);
        }

        [HttpGet]
        public IActionResult CreateOrEdit(int? id)
        {
            var hoaDon = id.HasValue
                ? _context.HoaDons.Include(h => h.HoaDonChiTiets)
                                  .FirstOrDefault(hd => hd.HoaDonId == id.Value)
                : new HoaDon();
            if (hoaDon == null && id.HasValue)
            {
                return NotFound();
            }
            ViewBag.BanList = _context.Bans.Where(b => b.IsDelete != true).ToList();
            ViewBag.NhanVienList = _context.NhanViens.Where(nv => nv.IsDelete != true).ToList();
            ViewBag.KhoList = _context.Khos.Where(k => k.SoLuong > 0 && k.IsDelete != true).ToList();
            ViewBag.TheThanhVienList = _context.TheThanhViens.Where(b => b.IsDelete != true).ToList();
            return PartialView("_CreateOrEdit", hoaDon);
        }

        [HttpPost]
        public async Task<IActionResult> Save(HoaDon hoaDon, List<HoaDonChiTiet> hoaDonChiTiets)
        {
            if (ModelState.IsValid)
            {
                var ban = await _context.Bans.FindAsync(hoaDon.BanId);

                if (ban == null)
                {
                    return NotFound();
                }

                ban.TrangThai = "Đang sử dụng";

                if (hoaDon.HoaDonId > 0)
                {
                    var existingHoaDon = await _context.HoaDons
                        .Include(h => h.Ban)
                        .Include(h => h.HoaDonChiTiets)
                        .ThenInclude(hct => hct.Kho)
                        .FirstOrDefaultAsync(h => h.HoaDonId == hoaDon.HoaDonId);

                    if (existingHoaDon == null)
                    {
                        return NotFound();
                    }

                    if (existingHoaDon.BanId != hoaDon.BanId)
                    {
                        var banUpd = await _context.Bans.FindAsync(existingHoaDon.BanId);
                        banUpd.TrangThai = "Trống";
                    }

                    existingHoaDon.BanId = hoaDon.BanId;
                    existingHoaDon.GioBatDau = hoaDon.GioBatDau;
                    existingHoaDon.GioKetThuc = hoaDon.GioKetThuc;
                    existingHoaDon.GiaGio = hoaDon.GiaGio;
                    existingHoaDon.TheThanhVienId = hoaDon.TheThanhVienId;
                    existingHoaDon.NhanVienId = hoaDon.NhanVienId;
                    existingHoaDon.HoaDonId = hoaDon.HoaDonId;

                    await RestoreStock(existingHoaDon.HoaDonChiTiets);
                    _context.HoaDonChiTiets.RemoveRange(existingHoaDon.HoaDonChiTiets);

                    existingHoaDon.HoaDonChiTiets = hoaDonChiTiets;

                    var playCost = CalculatePlayCost(hoaDon.GioBatDau, hoaDon.GioKetThuc, hoaDon.GiaGio);
                    existingHoaDon.TongTien = playCost + hoaDonChiTiets.Sum(ct => ct.ThanhTien);

                    var stockDeductionResult = await DeductStock(hoaDonChiTiets);
                    if (!stockDeductionResult)
                    {
                        return PartialView("_CreateOrEdit", hoaDon);
                    }

                    _context.Update(existingHoaDon);
                    await _context.SaveChangesAsync();
                    return Json(new { isValid = true, message = "Hóa đơn đã được cập nhật thành công!" });
                }
                else
                {
                    hoaDon.NgayLap = DateTime.Now;
                    hoaDon.HoaDonChiTiets = hoaDonChiTiets;

                    var playCost = CalculatePlayCost(hoaDon.GioBatDau, hoaDon.GioKetThuc, hoaDon.GiaGio);
                    hoaDon.TongTien = playCost + hoaDonChiTiets.Sum(ct => ct.ThanhTien);

                    var stockDeductionResult = await DeductStock(hoaDonChiTiets);
                    if (!stockDeductionResult)
                    {
                        return PartialView("_CreateOrEdit", hoaDon);
                    }

                    _context.HoaDons.Add(hoaDon);
                    await _context.SaveChangesAsync();
                    return Json(new { isValid = true, message = "Hóa đơn đã được thêm thành công!" });

                }
            }

            ViewBag.BanList = _context.Bans.Where(b => b.IsDelete != true).ToList();
            ViewBag.NhanVienList = _context.NhanViens.Where(nv => nv.IsDelete != true).ToList();
            ViewBag.KhoList = _context.Khos.Where(k => k.SoLuong > 0 && k.IsDelete != true).ToList();
            ViewBag.TheThanhVienList = _context.TheThanhViens.Where(b => b.IsDelete != true).ToList();
            return PartialView("_CreateOrEdit", hoaDon);
        }

        private long CalculatePlayCost(TimeSpan startTime, TimeSpan endTime, long hourlyRate)
        {
            var totalHours = (endTime - startTime).TotalHours;
            var playCost = totalHours * hourlyRate;

            return (long)playCost;
        }
        private async Task RestoreStock(IEnumerable<HoaDonChiTiet> hoaDonChiTiets)
        {
            foreach (var item in hoaDonChiTiets)
            {
                var khoItem = await _context.Khos.FindAsync(item.IdKho);
                if (khoItem != null)
                {
                    khoItem.SoLuong += item.SoLuong;
                }
            }
        }

        private async Task<bool> DeductStock(List<HoaDonChiTiet> hoaDonChiTiets)
        {
            foreach (var newItem in hoaDonChiTiets)
            {
                var khoItem = await _context.Khos.FindAsync(newItem.IdKho);
                if (khoItem != null)
                {
                    if (khoItem.SoLuong >= newItem.SoLuong)
                    {
                        khoItem.SoLuong -= newItem.SoLuong;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        [HttpGet]
        public async Task<IActionResult> UpdStatus(int id)
        {
            var HoaDon = await _context.HoaDons.Include(h => h.NhanVien)
                                            .Include(h => h.Ban)
                                            .Include(h => h.HoaDonChiTiets)
                                            .ThenInclude(hct => hct.Kho)
                                            .FirstOrDefaultAsync(h => h.HoaDonId == id);
            if (HoaDon == null)
            {
                return NotFound();
            }
            return PartialView("_UpdStatus", HoaDon);
        }

        [HttpPost]
        public async Task<IActionResult> UpdStatusConfirmed(HoaDon hoaDon)
        {
            var HoaDon = await _context.HoaDons
                        .Include(h => h.Ban)
                        .FirstOrDefaultAsync(h => h.HoaDonId == hoaDon.HoaDonId); 
            if (HoaDon != null)
            {
                HoaDon.Ban.TrangThai = "Trống";
                HoaDon.TrangThai = "Đã thanh toán";
                _context.HoaDons.Update(HoaDon);
                await _context.SaveChangesAsync();
                return Json(new { isValid = true, message = "Hóa đơn đã được thanh toán!" });
            }
            return Json(new { isValid = false, message = "Lỗi khi thanh toán" });
        }

        [HttpGet]
        public IActionResult GetTableList()
        {
            var hoaDons = _context.HoaDons.Include(h => h.NhanVien)
                                           .Include(h => h.Ban)
                                           .Include(h => h.HoaDonChiTiets)
                                           .OrderByDescending(h => h.HoaDonId)
                                           .ToList();

            return PartialView("_TableList", hoaDons);
        }
        [HttpGet]
        public IActionResult GetGiaGio(int banId, int hoaDonId)
        {
            var ban = _context.Bans.FirstOrDefault(nv => nv.BanId == banId);
            if (hoaDonId == 0)
            {
                if (ban != null)
                {
                    if (ban.TrangThai.Equals("Trống"))
                    {
                        return Json(new { success = true, giaGio = ban.GiaGio });
                    }else
                    {
                        return Json(new { success = false, ms ="Bàn đang được sử dụng" });
                    }
                }
            }else
            {
                var hoaDons = _context.HoaDons.FirstOrDefault(p=>p.HoaDonId == hoaDonId);
                if (hoaDons != null)
                {
                    if (hoaDons.BanId == banId && ban != null)
                    {
                        return Json(new { success = true, giaGio = ban.GiaGio });
                    }
                    else if (ban != null && ban.TrangThai.Equals("Trống"))
                    {
                        return Json(new { success = true, giaGio = ban.GiaGio });
                    }else
                    {
                        return Json(new { success = false, ms = "Bàn đang được sử dụng" });
                    }
                }
            }
            
            return Json(new { success = false });
        }
        [HttpGet]
        public IActionResult GetKho(int khoId)
        {
            var kho = _context.Khos.FirstOrDefault(k => k.IdMatHang == khoId);
            if (kho != null)
            {
                return Json(new { success = true, Kho = kho });
            }
            return Json(new { success = false });
        }
    }
}
