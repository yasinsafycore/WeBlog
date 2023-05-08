using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeBloge.Application.Extensions;
using WeBloge.Application.Security;
using WeBloge.Application.Services.Implementations;
using WeBloge.Application.Services.Interfaces;
using WeBloge.Domain.Entities.Admin;
using WeBloge.Domain.ViewModels.Admin;
using WeBloge.Domain.ViewModels.WeBloge;

namespace WeBloge.Web.Controllers
{
    public class WeBlogeController : BaseController
    {
        #region Ctor

        private readonly IWeBlogeService _weBlogeService;
        public WeBlogeController(IWeBlogeService weBlogeService)
        {
            _weBlogeService = weBlogeService;
        }

        #endregion

        #region Writer

        [HttpGet]
        public IActionResult WriterProfile()
        {
            int Count = _weBlogeService.WeBlogesCount();

            ViewBag.Count = Count;

            return View();
        }

        #endregion

        #region WeBloge Detail

        [HttpGet("WeBloges/{weBlogesId}")]
        public async Task<IActionResult> WeBlogeDetail(int weBlogesId)
        {
            var weBloges = await _weBlogeService.GetWeBlogesById(weBlogesId);

            if (weBloges == null) return NotFound();

            return View(weBloges);
        }

        #endregion

        #region Comment

        [HttpPost,ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> CommentWeBloge(CommentViewModel viewModel, int weBlogesId)
        {
            if (ModelState.IsValid)
            {
                var result = await _weBlogeService.CommentWeBloge(viewModel);

                if (result)
                {
                    return RedirectToAction("WeBlogeDetail", "WeBloge", new {weBlogesId = weBlogesId});
                }
            }

            return View(viewModel);
        }

        #endregion

        #region ContactUs

        [HttpGet]
        public IActionResult ContactUs()
        {
            return View();
        }

        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> ContactUs(ContactUsViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _weBlogeService.AddContactUs(viewModel);

                if (result)
                {
                    return View(viewModel);
                }
            }

            return View(viewModel);
        }

        #endregion
    }
}
