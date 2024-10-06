using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyQuanBilliard.Models;

namespace QuanLyQuanBilliard.Controllers
{
    [AuthorizeRole("Quản Lý")]
    public class HomeController : Controller
    {
        private readonly QuanLyQuanBilliardContext _context;

        public HomeController(QuanLyQuanBilliardContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var soBan = _context.Bans.Count(b => !b.IsDelete);
            var soTheThanhVien = _context.TheThanhViens.Count(tv => !tv.IsDelete);

            ViewBag.SoBan = soBan;
            ViewBag.SoTheThanhVien = soTheThanhVien;

            return View();
        }


        [HttpPost]
        public IActionResult FilterData(DateTime startDate, DateTime endDate, string filterType)
        {
            var query = _context.HoaDons
                .Include(h => h.HoaDonChiTiets)
                .AsQueryable();

            if (filterType == "day")
            {
                query = query.Where(hd => hd.NgayLap.Date >= startDate.Date && hd.NgayLap.Date <= endDate.Date);

                var tongTienTheoNgay = query
                    .SelectMany(hd => hd.HoaDonChiTiets.Select(ct => new
                    {
                        Ngay = hd.NgayLap.Date,
                        TongTien = hd.TongTien,
                        GiaNhap = ct.SoLuong * ct.GiaNhap,
                        GiaBan = ct.SoLuong * ct.GiaBan
                    }))
                    .GroupBy(x => x.Ngay)
                    .Select(g => new
                    {
                        Ngay = g.Key.ToString("dd/MM/yyyy"),
                        TongTien = g.Sum(x => x.TongTien),
                        GiaNhap = g.Sum(x => x.GiaNhap),
                        GiaBan = g.Sum(x => x.GiaBan)
                    })
                    .ToList();

                return Json(new
                {
                    labels = tongTienTheoNgay.Select(x => x.Ngay).ToArray(),
                    tongTien = tongTienTheoNgay.Select(x => x.TongTien).ToArray(),
                    giaNhap = tongTienTheoNgay.Select(x => x.GiaNhap).ToArray(),
                    giaBan = tongTienTheoNgay.Select(x => x.GiaBan).ToArray(),
                    loiNhuan = tongTienTheoNgay.Select(x => x.TongTien - x.GiaNhap).ToArray()
                });
            }
            else if (filterType == "month")
            {
                query = query.Where(hd => hd.NgayLap.Date >= startDate.Date && hd.NgayLap.Date <= endDate.Date);

                var tongTienTheoThang = query
                    .SelectMany(hd => hd.HoaDonChiTiets.Select(ct => new
                    {
                        Thang = new { hd.NgayLap.Year, hd.NgayLap.Month },
                        TongTien = hd.TongTien,
                        GiaNhap = ct.SoLuong * ct.GiaNhap,
                        GiaBan = ct.SoLuong * ct.GiaBan
                    }))
                    .GroupBy(x => x.Thang)
                    .Select(g => new
                    {
                        Thang = g.Key.Month + "/" + g.Key.Year,
                        TongTien = g.Sum(x => x.TongTien),
                        GiaNhap = g.Sum(x => x.GiaNhap),
                        GiaBan = g.Sum(x => x.GiaBan)
                    })
                    .ToList();

                return Json(new
                {
                    labels = tongTienTheoThang.Select(x => x.Thang).ToArray(),
                    tongTien = tongTienTheoThang.Select(x => x.TongTien).ToArray(),
                    giaNhap = tongTienTheoThang.Select(x => x.GiaNhap).ToArray(),
                    giaBan = tongTienTheoThang.Select(x => x.GiaBan).ToArray(),
                    loiNhuan = tongTienTheoThang.Select(x => x.TongTien - x.GiaNhap).ToArray()
                });
            }
            else if (filterType == "year")
            {
                query = query.Where(hd => hd.NgayLap.Date >= startDate.Date && hd.NgayLap.Date <= endDate.Date);

                var tongTienTheoNam = query
                    .SelectMany(hd => hd.HoaDonChiTiets.Select(ct => new
                    {
                        Nam = hd.NgayLap.Year,
                        TongTien = hd.TongTien,
                        GiaNhap = ct.SoLuong * ct.GiaNhap,
                        GiaBan = ct.SoLuong * ct.GiaBan
                    }))
                    .GroupBy(x => x.Nam)
                    .Select(g => new
                    {
                        Nam = g.Key.ToString(),
                        TongTien = g.Sum(x => x.TongTien),
                        GiaNhap = g.Sum(x => x.GiaNhap),
                        GiaBan = g.Sum(x => x.GiaBan)
                    })
                    .ToList();

                return Json(new
                {
                    labels = tongTienTheoNam.Select(x => x.Nam).ToArray(),
                    tongTien = tongTienTheoNam.Select(x => x.TongTien).ToArray(),
                    giaNhap = tongTienTheoNam.Select(x => x.GiaNhap).ToArray(),
                    giaBan = tongTienTheoNam.Select(x => x.GiaBan).ToArray(),
                    loiNhuan = tongTienTheoNam.Select(x => x.TongTien - x.GiaNhap).ToArray()
                });
            }

            return BadRequest();
        }

    }
}
