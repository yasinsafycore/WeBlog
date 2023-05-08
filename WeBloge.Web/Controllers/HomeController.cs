using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WeBloge.Application.Extensions;
using WeBloge.Application.Services.Implementations;
using WeBloge.Application.Services.Interfaces;
using WeBloge.Application.Statics;
using WeBloge.Domain.Entities.Admin;

namespace WeBloge.Web.Controllers
{
    public class HomeController : BaseController
    {
        #region Ctor

        private readonly IWeBlogeService _weBlogeService;
        public HomeController(IWeBlogeService weBlogeService)
        {
            _weBlogeService = weBlogeService;
        }

        #endregion

        #region WeBloges

        [HttpGet]
        public async Task<IActionResult> Index(int weBlogesId = 1)
        {
            var result = await _weBlogeService.GetAllWeBloges(weBlogesId);

            int Count = _weBlogeService.WeBlogesCount();

            ViewBag.PageID = weBlogesId;
            ViewBag.PageCount = Count / 7;

            return View(result);
        }

        #endregion

        #region Editor Upload

        public async Task<IActionResult> UploadEditorImage(IFormFile upload)
        {
            var fileName = Guid.NewGuid() + Path.GetExtension(upload.FileName);

            upload.UploadFile(fileName, PathTools.EditorImageServerPath);

            return Json(new { url = $"{PathTools.EditorImagePath}{fileName}" });
        }

        #endregion

        #region 404

        [HttpGet("/404")]
        public IActionResult NotFoundPage()
        {
            return View();
        }

        #endregion
    }
}
