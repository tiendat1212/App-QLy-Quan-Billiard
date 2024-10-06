using Microsoft.AspNetCore.Mvc;
using QuanLyQuanBilliard.Models;
using QuanLyQuanBilliard.Models.EF;

namespace QuanLyQuanBilliard.Controllers
{
    [AuthorizeRole("Quản Lý")]
    public class KhoController : Controller
    {
        private readonly QuanLyQuanBilliardContext _context;

        public KhoController(QuanLyQuanBilliardContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var Khos = _context.Khos
                .Where(b => b.IsDelete != true)
                .OrderByDescending(b => b.IdMatHang)
                .ToList();

            return View(Khos);
        }

        [HttpGet]
        public IActionResult CreateOrEdit(int? id)
        {
            var Kho = id.HasValue ? _context.Khos.Find(id.Value) : new Kho();
            if (Kho == null && id.HasValue)
            {
                return NotFound();
            }
            return PartialView("_CreateOrEdit", Kho);
        }

        [HttpPost]
        public async Task<IActionResult> Save(Kho Kho)
        {
            if (ModelState.IsValid)
            {
                if (Kho.IdMatHang == 0)
                {
                    _context.Add(Kho);
                    await _context.SaveChangesAsync();
                    return Json(new { isValid = true, message = "Kho đã được thêm thành công!" });
                }
                else
                {
                    Kho.NgayCapNhap = DateTime.Now;
                    _context.Update(Kho);
                    await _context.SaveChangesAsync();
                    return Json(new { isValid = true, message = "Kho đã được cập nhật thành công!" });
                }

            }
            return PartialView("_CreateOrEdit", Kho);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var Kho = await _context.Khos.FindAsync(id);
            if (Kho == null)
            {
                return NotFound();
            }
            return PartialView("_Delete", Kho);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(Kho Kho)
        {
            if (Kho != null)
            {
                Kho.IsDelete = true;
                Kho.NgayCapNhap = DateTime.Now;
                _context.Khos.Update(Kho);
                await _context.SaveChangesAsync();
                return Json(new { isValid = true, message = "Kho đã được xóa thành công!" });
            }
            return Json(new { isValid = false, message = "Kho bàn không thành công!" });
        }

        [HttpGet]
        public IActionResult GetTableList()
        {
            var Khos = _context.Khos
                .Where(b => b.IsDelete != true)
                .OrderByDescending(b => b.IdMatHang)
                .ToList();
            return PartialView("_TableList", Khos);
        }
    }
}
