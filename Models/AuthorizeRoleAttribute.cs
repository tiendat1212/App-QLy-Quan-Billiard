using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace QuanLyQuanBilliard.Models
{
    public class AuthorizeRoleAttribute : ActionFilterAttribute
    {
        private readonly string[] _roles;

        public AuthorizeRoleAttribute(params string[] roles)
        {
            _roles = roles;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var tenDangNhap = context.HttpContext.Session.GetString("TenDangNhap");
            var vaiTro = context.HttpContext.Session.GetString("TenQuyen");

            if (string.IsNullOrEmpty(tenDangNhap) || !IsAuthorized(vaiTro))
            {
                context.Result = new RedirectToActionResult("Index", "DangNhap", null);
            }

            base.OnActionExecuting(context);
        }

        private bool IsAuthorized(string vaiTro)
        {
            return _roles.Contains(vaiTro);
        }
    }
}
