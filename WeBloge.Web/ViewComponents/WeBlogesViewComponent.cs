using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeBloge.Application.Services.Interfaces;

namespace WeBloge.Web.ViewComponents
{
    public class LatestPostsViewComponent : ViewComponent
    {
        #region Ctor

        private readonly IWeBlogeService _weblogeService;
        public LatestPostsViewComponent(IWeBlogeService weblogeService)
        {
            _weblogeService = weblogeService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _weblogeService.GetLatestPosts();

            return View("LatestPosts", result);
        }
    }

    public class WidgetCategoriesViewComponent : ViewComponent
    {
        #region Ctor

        private readonly IWeBlogeService _weblogeService;
        public WidgetCategoriesViewComponent(IWeBlogeService weblogeService)
        {
            _weblogeService = weblogeService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync(int categoriesId)
        {
            var result = await _weblogeService.GetAllCategories();

            return View("WidgetCategories", result);
        }
    }

    public class WidgetCommentsViewComponent : ViewComponent
    {
        #region Ctor

        private readonly IWeBlogeService _weblogeService;
        public WidgetCommentsViewComponent(IWeBlogeService weblogeService)
        {
            _weblogeService = weblogeService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync(int weBlogesId)
        {
            var result = await _weblogeService.GetAllComments(weBlogesId);

            return View("WidgetComments", result);
        }
    }
}
