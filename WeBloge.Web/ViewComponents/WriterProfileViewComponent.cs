using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeBloge.Application.Services.Interfaces;

namespace WeBloge.Web.ViewComponents
{
    public class WriterProfileViewComponent : ViewComponent
    {
        #region Ctor

        private readonly IWeBlogeService _weBlogeService;
        public WriterProfileViewComponent(IWeBlogeService weBlogeService)
        {
            _weBlogeService = weBlogeService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var writer = await _weBlogeService.GetWriter();

            return View("WriterProfile", writer);
        }
    }

    public class WriterWeBlogeDetailViewComponent : ViewComponent
    {
        #region Ctor

        private readonly IWeBlogeService _weBlogeService;
        public WriterWeBlogeDetailViewComponent(IWeBlogeService weBlogeService)
        {
            _weBlogeService = weBlogeService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var writer = await _weBlogeService.GetWriter();

            return View("WriterWeBlogeDetail", writer);
        }
    }
}
