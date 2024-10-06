using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyQuanBilliard.Models;
using QuanLyQuanBilliard.Models.EF;

namespace QuanLyQuanBilliard.Controllers
{
    [AuthorizeRole("Quản Lý")]
    public class LuongController : Controller
    {
        private readonly QuanLyQuanBilliardContext _context;

        public LuongController(QuanLyQuanBilliardContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var Luongs = _context.Luongs
                .Include(t => t.NhanVien)
                .Where(b => b.IsDelete != true)
                .OrderByDescending(b => b.LuongId)
                .ToList();

            return View(Luongs);
        }


        [HttpGet]
        public IActionResult CreateOrEdit(int? id)
        {
            var Luong = id.HasValue ? _context.Luongs.Find(id.Value) : new Luong();
            if (Luong == null && id.HasValue)
            {
                return NotFound();
            }

            ViewBag.NhanVienList = _context.NhanViens.Where(b => b.IsDelete != true).ToList();
            return PartialView("_CreateOrEdit", Luong);
        }

        public async Task<IActionResult> Save(Luong Luong)
        {
            if (ModelState.IsValid)
            {
                if (Luong.LuongId == 0)
                {
                    _context.Add(Luong);
                    await _context.SaveChangesAsync();
                    return Json(new { isValid = true, message = "Lương của nhân viên đã được thêm thành công!" });
                }
                else
                {
                    Luong.NgayCapNhap = DateTime.Now;
                    _context.Update(Luong);
                    await _context.SaveChangesAsync();
                    return Json(new { isValid = true, message = "Lương của nhân viên đã được cập nhật thành công!" });
                }

            }

            ViewBag.NhanVienList = _context.NhanViens.Where(b => b.IsDelete != true).ToList();
            return PartialView("_CreateOrEdit", Luong);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var Luong = await _context.Luongs.FindAsync(id);
            if (Luong == null)
            {
                return NotFound();
            }
            return PartialView("_Delete", Luong);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(Luong Luong)
        {
            if (Luong != null)
            {
                Luong.IsDelete = true;
                Luong.NgayCapNhap = DateTime.Now;
                _context.Luongs.Update(Luong);
                await _context.SaveChangesAsync();
                return Json(new { isValid = true, message = "Lương của nhân viên đã được xóa thành công!" });
            }
            return Json(new { isValid = false, message = "Xóa lương của nhân viên không thành công!" });
        }

        [HttpGet]
        public IActionResult GetTableList()
        {
            var Luongs = _context.Luongs
                .Include(t => t.NhanVien)
                .Where(b => b.IsDelete != true)
                .OrderByDescending(b => b.LuongId)
                .ToList();
            return PartialView("_TableList", Luongs);
        }
        [HttpGet]
        public IActionResult GetLuongCoBan(int nhanVienId)
        {
            var nhanVien = _context.NhanViens.FirstOrDefault(nv => nv.NhanVienId == nhanVienId);
            if (nhanVien != null)
            {
                return Json(new { success = true, luongCoBan = nhanVien.LuongCoBan });
            }
            return Json(new { success = false, message = "Không tìm thấy nhân viên!" });
        }

    }
}
