using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyQuanBilliard.Models;
using QuanLyQuanBilliard.Models.EF;

namespace QuanLyQuanBilliard.Controllers
{
    public class DangNhapController : Controller
    {
        private readonly QuanLyQuanBilliardContext _context;

        public DangNhapController(QuanLyQuanBilliardContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DangNhap(string tenDangNhap, string matKhau)
        {
            if (string.IsNullOrEmpty(tenDangNhap) || string.IsNullOrEmpty(matKhau))
            {
                return Json(new { success = false, message = "Tên đăng nhập và mật khẩu không được để trống." });
            }

            var taiKhoan = await _context.TaiKhoans.FirstOrDefaultAsync(t => t.TenDangNhap == tenDangNhap && !t.IsDelete);

            if (taiKhoan == null || new PasswordHasher<TaiKhoan>().VerifyHashedPassword(taiKhoan, taiKhoan.MatKhau, matKhau) == PasswordVerificationResult.Failed)
            {
                return Json(new { success = false, message = "Tài khoản hoặc mật khẩu không chính xác." });
            }

            HttpContext.Session.SetInt32("TaiKhoanId", taiKhoan.TaiKhoanId);
            HttpContext.Session.SetString("TenDangNhap", taiKhoan.TenDangNhap);
            HttpContext.Session.SetString("TenQuyen", taiKhoan.TenQuyen);
            if(taiKhoan.TenQuyen.Equals("Tiếp Tân"))
            {
                return Json(new { success = true, message = "Đăng nhập thành công!", redirectUrl = Url.Action("Index", "DatBan")});
            }
            return Json(new { success = true, message = "Đăng nhập thành công!", redirectUrl = Url.Action("Index", "Home") });
        }

        public IActionResult DangXuat()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "DangNhap");
        }
    }
}
