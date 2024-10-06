using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyQuanBilliard.Models;
using QuanLyQuanBilliard.Models.EF;

namespace QuanLyQuanBilliard.Controllers
{
    [AuthorizeRole("Quản Lý", "Tiếp Tân")]
    public class DatBanController : Controller
    {
        private readonly QuanLyQuanBilliardContext _context;

        public DatBanController(QuanLyQuanBilliardContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var bans = _context.Bans
                .Where(b => b.IsDelete != true)
                .OrderBy(b => b.TenBan)
                .ToList();

            return View(bans);
        }

        [HttpGet]
        public IActionResult CreateOrEdit(int id)
        {
            var hoaDon = _context.HoaDons.Include(h => h.HoaDonChiTiets).FirstOrDefault(hd => hd.BanId == id && hd.TrangThai.Equals("Chưa thanh toán"));
            if (hoaDon == null)
            {
                hoaDon =  new HoaDon();
                hoaDon.BanId = id;
            }
            ViewBag.BanList = _context.Bans.Where(b => b.IsDelete != true).ToList();
            ViewBag.NhanVienList = _context.NhanViens.Where(nv => nv.IsDelete != true).ToList();
            ViewBag.KhoList = _context.Khos.Where(k => k.SoLuong > 0 && k.IsDelete != true).ToList();
            ViewBag.TheThanhVienList = _context.TheThanhViens.Where(b => b.IsDelete != true).ToList();
            return PartialView("~/Views/HoaDon/_CreateOrEdit.cshtml", hoaDon);
        }

        [HttpGet]
        public async Task<IActionResult> UpdStatus(int id)
        {
            var HoaDon = await _context.HoaDons.Include(h => h.NhanVien)
                                            .Include(h => h.Ban)
                                            .Include(h => h.HoaDonChiTiets)
                                            .ThenInclude(hct => hct.Kho)
                                            .FirstOrDefaultAsync(hd => hd.BanId == id && hd.TrangThai.Equals("Chưa thanh toán"));
            if (HoaDon == null)
            {
                return NotFound();
            }
            return PartialView("~/Views/HoaDon/_UpdStatus.cshtml", HoaDon);
        }

        [HttpGet]
        public IActionResult GetTableList()
        {
            var bans = _context.Bans
                .Where(b => b.IsDelete != true)
                .OrderBy(b => b.TenBan)
                .ToList();
            return PartialView("_TableList", bans);
        }
    }
}
