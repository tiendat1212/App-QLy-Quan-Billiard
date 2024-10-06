using Microsoft.AspNetCore.Mvc;
using QuanLyQuanBilliard.Models;
using QuanLyQuanBilliard.Models.EF;

namespace QuanLyQuanBilliard.Controllers
{
    [AuthorizeRole("Quản Lý")]
    public class NhanVienController : Controller
    {
        private readonly QuanLyQuanBilliardContext _context;

        public NhanVienController(QuanLyQuanBilliardContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var NhanViens = _context.NhanViens
                .Where(b => b.IsDelete != true)
                .OrderByDescending(b => b.NhanVienId)
                .ToList();

            return View(NhanViens);
        }

        [HttpGet]
        public IActionResult CreateOrEdit(int? id)
        {
            var NhanVien = id.HasValue ? _context.NhanViens.Find(id.Value) : new NhanVien();
            if (NhanVien == null && id.HasValue)
            {
                return NotFound();
            }
            return PartialView("_CreateOrEdit", NhanVien);
        }

        [HttpPost]
        public async Task<IActionResult> Save(NhanVien NhanVien)
        {
            if (ModelState.IsValid)
            {
                if (NhanVien.NhanVienId == 0)
                {
                    _context.Add(NhanVien);
                    await _context.SaveChangesAsync();
                    return Json(new { isValid = true, message = "Nhân viên đã được thêm thành công!" });
                }
                else
                {
                    NhanVien.NgayCapNhap = DateTime.Now;
                    _context.Update(NhanVien);
                    await _context.SaveChangesAsync();
                    return Json(new { isValid = true, message = "Nhân viên đã được cập nhật thành công!" });
                }

            }
            return PartialView("_CreateOrEdit", NhanVien);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var NhanVien = await _context.NhanViens.FindAsync(id);
            if (NhanVien == null)
            {
                return NotFound();
            }
            return PartialView("_Delete", NhanVien);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(NhanVien NhanVien)
        {
            if (NhanVien != null)
            {
                NhanVien.IsDelete = true;
                NhanVien.NgayCapNhap = DateTime.Now;
                _context.NhanViens.Update(NhanVien);
                await _context.SaveChangesAsync();
                return Json(new { isValid = true, message = "Nhân viên đã được xóa thành công!" });
            }
            return Json(new { isValid = false, message = "Xóa nhân viên không thành công!" });
        }

        [HttpGet]
        public IActionResult GetTableList()
        {
            var NhanViens = _context.NhanViens
                .Where(b => b.IsDelete != true)
                .OrderByDescending(b => b.NhanVienId)
                .ToList();
            return PartialView("_TableList", NhanViens);
        }
    }
}
