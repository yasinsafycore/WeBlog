using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeBloge.Application.Services.Implementations;
using WeBloge.Application.Services.Interfaces;

namespace WeBloge.Web.ViewComponents
{
    public class ShowCategoriesViewComponent : ViewComponent
    {
        #region Ctor

        private readonly IAdminService _adminService;
        public ShowCategoriesViewComponent(IAdminService adminService)
        {
            _adminService = adminService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _adminService.GetAllCategories();

            return View("ShowCategories", categories);
        }

    }

    public class ShowSocialViewComponent : ViewComponent
    {
        #region Ctor

        private readonly IWeBlogeService _weblogeService;
        public ShowSocialViewComponent(IWeBlogeService weblogeService)
        {
            _weblogeService = weblogeService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var social = await _weblogeService.GetSocial();

            return View("ShowSocial", social);
        }

    }
}
