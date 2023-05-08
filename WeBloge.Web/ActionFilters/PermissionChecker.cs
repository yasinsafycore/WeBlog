using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;
using WeBloge.Application.Extensions;
using WeBloge.Application.Services.Interfaces;

namespace WeBloge.Web.ActionFilters
{
    public class PermissionChecker : Attribute, IAsyncAuthorizationFilter
    {
        private readonly int _permissionId;
        public PermissionChecker(int permissionId)
        {
            _permissionId = permissionId;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var adminService = (IAdminService)context.HttpContext.RequestServices.GetService(typeof(IAdminService))!;

            if (!await adminService.CheckUserPermission(_permissionId, context.HttpContext.User.GetUserId()))
            {
                context.Result = new RedirectResult("/");
            }
        }
    }
}
