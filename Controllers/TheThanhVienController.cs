using Microsoft.AspNetCore.Mvc;
using QuanLyQuanBilliard.Models;
using QuanLyQuanBilliard.Models.EF;

namespace QuanLyQuanBilliard.Controllers
{
    [AuthorizeRole("Quản Lý")]
    public class TheThanhVienController : Controller
    {
        private readonly QuanLyQuanBilliardContext _context;

        public TheThanhVienController(QuanLyQuanBilliardContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var TheThanhViens = _context.TheThanhViens
                .Where(b => b.IsDelete != true)
                .OrderByDescending(b => b.TheThanhVienId)
                .ToList();

            return View(TheThanhViens);
        }

        [HttpGet]
        public IActionResult CreateOrEdit(int? id)
        {
            var TheThanhVien = id.HasValue ? _context.TheThanhViens.Find(id.Value) : new TheThanhVien();
            if (TheThanhVien == null && id.HasValue)
            {
                return NotFound();
            }
            return PartialView("_CreateOrEdit", TheThanhVien);
        }

        [HttpPost]
        public async Task<IActionResult> Save(TheThanhVien TheThanhVien)
        {
            if (ModelState.IsValid)
            {
                if (TheThanhVien.TheThanhVienId == 0)
                {
                    _context.Add(TheThanhVien);
                    await _context.SaveChangesAsync();
                    return Json(new { isValid = true, message = "Thẻ thành viên đã được thêm thành công!" });
                }
                else
                {
                    TheThanhVien.NgayCapNhap = DateTime.Now;
                    _context.Update(TheThanhVien);
                    await _context.SaveChangesAsync();
                    return Json(new { isValid = true, message = "Thẻ thành viên đã được cập nhật thành công!" });
                }

            }
            return PartialView("_CreateOrEdit", TheThanhVien);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var TheThanhVien = await _context.TheThanhViens.FindAsync(id);
            if (TheThanhVien == null)
            {
                return NotFound();
            }
            return PartialView("_Delete", TheThanhVien);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(TheThanhVien TheThanhVien)
        {
            if (TheThanhVien != null)
            {
                TheThanhVien.IsDelete = true;
                TheThanhVien.NgayCapNhap = DateTime.Now;
                _context.TheThanhViens.Update(TheThanhVien);
                await _context.SaveChangesAsync();
                return Json(new { isValid = true, message = "Thẻ thành viên đã được xóa thành công!" });
            }
            return Json(new { isValid = false, message = "Xóa thẻ thành viên không thành công!" });
        }

        [HttpGet]
        public IActionResult GetTableList()
        {
            var TheThanhViens = _context.TheThanhViens
                .Where(b => b.IsDelete != true)
                .OrderByDescending(b => b.TheThanhVienId)
                .ToList();
            return PartialView("_TableList", TheThanhViens);
        }
    }
}
