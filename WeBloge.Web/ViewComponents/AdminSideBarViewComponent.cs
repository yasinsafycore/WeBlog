using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeBloge.Application.Services.Interfaces;

namespace WeBloge.Web.ViewComponents
{
    public class AdminSideBarViewComponent : ViewComponent
    {
        #region Ctor

        private readonly IWeBlogeService _weBlogeService;
        public AdminSideBarViewComponent(IWeBlogeService weBlogeService)
        {
            _weBlogeService = weBlogeService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var writer = await _weBlogeService.GetWriter();

            return View("AdminSideBar", writer);
        }
    }
}
