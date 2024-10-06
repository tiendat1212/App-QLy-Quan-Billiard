using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyQuanBilliard.Models;
using QuanLyQuanBilliard.Models.EF;

namespace QuanLyQuanBilliard.Controllers
{
    [AuthorizeRole("Quản Lý")]
    public class TaiKhoanController : Controller
    {
        private readonly QuanLyQuanBilliardContext _context;

        public TaiKhoanController(QuanLyQuanBilliardContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var TaiKhoans = _context.TaiKhoans
                .Include(t => t.NhanVien)
                .Where(b => b.IsDelete != true)
                .OrderByDescending(b => b.TaiKhoanId)
                .ToList();

            return View(TaiKhoans);
        }


        [HttpGet]
        public IActionResult CreateOrEdit(int? id)
        {
            var TaiKhoan = id.HasValue ? _context.TaiKhoans.Find(id.Value) : new TaiKhoan();
            if (TaiKhoan == null && id.HasValue)
            {
                return NotFound();
            }

            ViewBag.NhanVienList = _context.NhanViens.Where(b => b.IsDelete != true).ToList();
            return PartialView("_CreateOrEdit", TaiKhoan);
        }

        public async Task<IActionResult> Save(TaiKhoan TaiKhoan)
        {
            if (ModelState.IsValid || string.IsNullOrEmpty(TaiKhoan.MatKhau))
            {
                var passwordHasher = new PasswordHasher<TaiKhoan>();

                var duplicateUser = await _context.TaiKhoans
                    .FirstOrDefaultAsync(t => t.TenDangNhap == TaiKhoan.TenDangNhap && t.TaiKhoanId != TaiKhoan.TaiKhoanId);

                if (duplicateUser != null)
                {
                    return Json(new { isValid = false, message = "Tên đăng nhập đã tồn tại!" });
                }

                if (TaiKhoan.TaiKhoanId == 0)
                {
                    TaiKhoan.MatKhau = passwordHasher.HashPassword(TaiKhoan, TaiKhoan.MatKhau);
                    _context.Add(TaiKhoan);
                    await _context.SaveChangesAsync();
                    return Json(new { isValid = true, message = "Tài khoản đã được thêm thành công!" });
                }
                else
                {
                    var existingTaiKhoan = await _context.TaiKhoans.FindAsync(TaiKhoan.TaiKhoanId);
                    if (existingTaiKhoan == null)
                    {
                        return Json(new { isValid = false, message = "Lỗi không tìm thấy tài khoản!" });
                    }

                    if (!string.IsNullOrEmpty(TaiKhoan.MatKhau) && TaiKhoan.MatKhau != existingTaiKhoan.MatKhau)
                    {
                        existingTaiKhoan.MatKhau = passwordHasher.HashPassword(TaiKhoan, TaiKhoan.MatKhau);
                    }

                    existingTaiKhoan.TenDangNhap = TaiKhoan.TenDangNhap;
                    existingTaiKhoan.TenQuyen = TaiKhoan.TenQuyen;
                    existingTaiKhoan.NhanVienId = TaiKhoan.NhanVienId;
                    existingTaiKhoan.NgayCapNhap = DateTime.Now;

                    _context.Update(existingTaiKhoan);
                    await _context.SaveChangesAsync();
                    return Json(new { isValid = true, message = "Tài khoản đã được cập nhật thành công!" });
                }
            }

            ViewBag.NhanVienList = _context.NhanViens.Where(b => b.IsDelete != true).ToList();
            return PartialView("_CreateOrEdit", TaiKhoan);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var TaiKhoan = await _context.TaiKhoans.FindAsync(id);
            if (TaiKhoan == null)
            {
                return NotFound();
            }
            return PartialView("_Delete", TaiKhoan);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(TaiKhoan TaiKhoan)
        {
            if (TaiKhoan != null)
            {
                TaiKhoan.IsDelete = true;
                TaiKhoan.NgayCapNhap = DateTime.Now;
                _context.TaiKhoans.Update(TaiKhoan);
                await _context.SaveChangesAsync();
                return Json(new { isValid = true, message = "Tài khoản đã được xóa thành công!" });
            }
            return Json(new { isValid = false, message = "Xóa tài khoản không thành công!" });
        }

        [HttpGet]
        public IActionResult GetTableList()
        {
            var TaiKhoans = _context.TaiKhoans
                .Include(t => t.NhanVien)
                .Where(b => b.IsDelete != true)
                .OrderByDescending(b => b.TaiKhoanId)
                .ToList();
            return PartialView("_TableList", TaiKhoans);
        }
    }
}
