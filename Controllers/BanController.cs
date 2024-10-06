using Microsoft.AspNetCore.Mvc;
using QuanLyQuanBilliard.Models;
using QuanLyQuanBilliard.Models.EF;

namespace QuanLyQuanBilliard.Controllers
{
    [AuthorizeRole("Quản Lý")]
    public class BanController : Controller
    {
        private readonly QuanLyQuanBilliardContext _context;

        public BanController(QuanLyQuanBilliardContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var bans = _context.Bans
                .Where(b => b.IsDelete != true)
                .OrderByDescending(b => b.BanId)
                .ToList();

            return View(bans);
        }

        [HttpGet]
        public IActionResult CreateOrEdit(int? id)
        {
            var ban = id.HasValue ? _context.Bans.Find(id.Value) : new Ban();
            if (ban == null && id.HasValue)
            {
                return NotFound();
            }
            return PartialView("_CreateOrEdit", ban);
        }

        [HttpPost]
        public async Task<IActionResult> Save(Ban ban)
        {
            if (ModelState.IsValid)
            {
                if (ban.BanId == 0)
                {
                    _context.Add(ban);
                    await _context.SaveChangesAsync();
                    return Json(new { isValid = true, message = "Bàn đã được thêm thành công!" });
                }
                else
                {
                    ban.NgayCapNhap = DateTime.Now;
                    _context.Update(ban);
                    await _context.SaveChangesAsync();
                    return Json(new { isValid = true, message = "Bàn đã được cập nhật thành công!" });
                }
            }
            return PartialView("_CreateOrEdit", ban);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var ban = await _context.Bans.FindAsync(id);
            if (ban == null)
            {
                return NotFound();
            }
            return PartialView("_Delete", ban);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(Ban ban)
        {
            if (ban != null)
            {
                ban.IsDelete = true;
                ban.NgayCapNhap = DateTime.Now;
                _context.Bans.Update(ban);
                await _context.SaveChangesAsync();
                return Json(new { isValid = true, message = "Bàn đã được xóa thành công!" });
            }
            return Json(new { isValid = false, message = "Xóa bàn không thành công!" });
        }

        [HttpGet]
        public IActionResult GetTableList()
        {
            var bans = _context.Bans
                .Where(b => b.IsDelete != true)
                .OrderByDescending(b => b.BanId)
                .ToList();
            return PartialView("_TableList", bans);
        }
    }
}
