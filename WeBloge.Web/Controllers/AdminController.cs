using Core.Classes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WeBloge.Application.Security;
using WeBloge.Application.Services.Interfaces;
using WeBloge.DataLayer.Context;
using WeBloge.Domain.Entities.Account;
using WeBloge.Domain.Entities.Admin;
using WeBloge.Domain.Interfaces;
using WeBloge.Domain.ViewModels.Admin;
using WeBloge.Web.ActionFilters;

namespace WeBloge.Web.Controllers
{
    [Authorize]
    [PermissionChecker(1)]
    public class AdminController : BaseController
    {
        #region Ctor

		private readonly IAdminService _adminService;
        private readonly WeBlogeDbContext _context;
        public AdminController(IAdminService adminService, WeBlogeDbContext context)
		{
			_adminService = adminService;
            _context = context;
		}

        #endregion

        #region Writer

        [HttpGet("Admin")]
        public IActionResult Writer()
        {
            return View();
        }

		[HttpPost("Admin"),ValidateAntiForgeryToken]
		public async Task<IActionResult> Writer(WriterViewModel viewModel)
		{
			if (viewModel.Img != null)
			{
				string filePath = "";
				viewModel.ImgName = RandomCodeGenerators.CreateFileCode() + Path.GetExtension(viewModel.Img.FileName);
				filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/content/gallery", viewModel.ImgName);

				using (var stream = new FileStream(filePath, FileMode.Create))
				{
					viewModel.Img.CopyTo(stream);
				}

				Writer writer = new Writer()
				{
					Img = viewModel.ImgName.SanitizeText(),
					FirstName = viewModel.FirstName.SanitizeText(),
					LastName = viewModel.LastName.SanitizeText(),
					Description = viewModel.Description.SanitizeText(),
				};

				_adminService.AddWriter(writer);
				await _adminService.SaveChange();

				TempData["SuccessMessage"] = "پروفایل نویسنده اضافه شد";

				return RedirectToAction("WriterProfile", "WeBloge");
			}

			return View(viewModel);
		}

		#endregion

		#region Categories

		[HttpGet("categories")]
		public IActionResult Categories()
		{
			return View();
		}

        [HttpPost("categories"), ValidateAntiForgeryToken]
        public async Task<IActionResult> Categories(CategoriesViewModel viewModel)
        {
			if (ModelState.IsValid)
			{
				var result = await _adminService.Categories(viewModel);
				switch (result)
				{
					case CategoriesResult.Success:
                        TempData["SuccessMessage"] = "دسته بندی مورد نظر اضافه شد";
						return RedirectToAction("ShowAllCategories", "Admin");
                }
            }

			return View(viewModel);
		}

		[HttpGet]
		public async Task<IActionResult> ShowAllCategories()
		{
            var result = await _adminService.GetAllCategories();

            return View(result);
		}

		[HttpGet("UpdateCategories/{categoriesId}")]
		public async Task<IActionResult> UpdateCategories(int categoriesId)
		{
			var result = await _adminService.UpdateCategoriesView(categoriesId);

			return View(result);
		}

        [HttpPost("UpdateCategories/{categoriesId}"), ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateCategories(UpdateCategoriesViewModel viewModel, int categoriesId)
        {
			if (ModelState.IsValid)
			{
				var result = await _adminService.UpdateCategories(viewModel, categoriesId);
				switch (result)
				{
					case UpdateCategoriesResult.Success:
                        return RedirectToAction("ShowAllCategories", "Admin");
                }
			}

			return View(viewModel);
		}

        [HttpGet("DeleteCategories/{categoriesId}")]
        public async Task<IActionResult> DeleteCategories(int categoriesId)
        {
            var result = await _adminService.DeleteCategoriesView(categoriesId);

            return View(result);
        }

        [HttpPost("DeleteCategories/{categoriesId}"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCategories(DeleteCategoriesViewModel viewModel, int categoriesId)
        {
           var result = await _adminService.DeleteCategories(viewModel, categoriesId);
           switch (result)
              {
                  case DeleteCategoriesResult.Success:
                    return RedirectToAction("ShowAllCategories", "Admin");
              }

           return View(viewModel);
        }

        #endregion

        #region WeBloge

        [HttpGet("createWeBloge")]
        public async Task<IActionResult> CreateWeBloge()
        {
            ViewData["Categorie"] = await _adminService.GetAllCategories();
            return View();
        }

        [HttpPost("createWeBloge"), ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateWeBloge(CreateWeBlogeViewModel viewModel)
        {
			if (ModelState.IsValid)
			{
				var result = await _adminService.WeBlogeResult(viewModel);
				switch (result)
				{
					case CreateWeBlogeResult.Success:
						TempData["SuccessMessage"] = "وبلاگ اضافه شد";
						return RedirectToAction("ShowAllWeBloge", "Admin");
					case CreateWeBlogeResult.NotValidImg:
                        TempData["WarningMessage"] = "لطفا تصویر را وارد کنید";
                        break;
				}
			}

			ViewData["Categorie"] = await _adminService.GetAllCategories();
            return View(viewModel);
		}

        [HttpGet]
        public async Task<IActionResult> ShowAllWeBloge(int weBlogesId = 1)
        {
            var result = await _adminService.GetAllWeBloges(weBlogesId);

            int Count = _adminService.WeBlogesCount();

            ViewBag.PageID = weBlogesId;
            ViewBag.PageCount = Count / 7;

            return View(result);
        }

        [HttpGet("UpdateWeBloges/{weBlogesId}")]
        public async Task<IActionResult> UpdateWeBloges(int weBlogesId)
        {
            ViewData["Categorie"] = await _adminService.GetAllCategories();

            var result = await _adminService.UpdateWeBlogeView(weBlogesId);

            return View(result);
        }

        [HttpPost("UpdateWeBloges/{weBlogesId}"), ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateWeBloges(UpdateCreateWeBlogeViewModel viewModel, int weBlogesId)
        {
            if (ModelState.IsValid)
            {
                var result = await _adminService.UpdateWeBloge(viewModel, weBlogesId);
                switch (result)
                {
                    case UpdateCreateWeBlogeResult.Success:
                        return RedirectToAction("ShowAllWeBloge", "Admin");
                }
            }

            ViewData["Categorie"] = _adminService.GetAllCategories();
            return View(viewModel);
        }

        [HttpGet("UpdateImg/{weBlogesId}")]
        public async Task<IActionResult> UpdateImg(int weBlogesId)
        {
            var result = await _adminService.UpdateImgView(weBlogesId);

            return View(result);
        }

        [HttpPost("UpdateImg/{weBlogesId}"), ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateImg(UpdateImgWeBlogeViewModel viewModel, int weBlogesId)
        {
            if (ModelState.IsValid)
            {
                var result = await _adminService.UpdateImg(viewModel, weBlogesId);
                switch (result)
                {
                    case UpdateImgWeBlogeResult.Success:
                        return RedirectToAction("ShowAllWeBloge", "Admin");
                }
            }

            return View(viewModel);
        }


        [HttpGet("DeleteWeBloges/{weBlogesId}")]
        public async Task<IActionResult> DeleteWeBloges(int weBlogesId)
        {
            var result = await _adminService.DeleteWeBlogesView(weBlogesId);

            return View(result);
        }

        [HttpPost("DeleteWeBloges/{weBlogesId}"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteWeBloges(CreateWeBlogeViewModel viewModel, int weBlogesId)
        {
            var result = await _adminService.DeleteWeBloges(viewModel, weBlogesId);
            switch (result)
            {
                case CreateWeBlogeResult.Success:
                    return RedirectToAction("ShowAllWeBloge", "Admin");
            }

            return View(viewModel);
        }


        #endregion

        #region Social

        [HttpGet]
        public IActionResult AddSocial()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSocial(AddSocialViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _adminService.AddSocial(viewModel);

                return Redirect("/");
            }

            return View(viewModel);
        }

        #endregion

        #region ContactUs

        [HttpGet]
        public async Task<IActionResult> ShowAllContactUs(int contactUs = 1)
        {
            var result = await _adminService.GetAllContactUs(contactUs);

            int Count = _adminService.ContactUsCount();

            ViewBag.PageID = contactUs;
            ViewBag.PageCount = Count / 7;

            return View(result);
        }

        [HttpGet("ContactUs/{contactId}")]
        public async Task<IActionResult> ContactUsDetail(int contactId) 
        {
            var contact = await _adminService.GetContactUsById(contactId);

            if (contact == null) return NotFound();

            return View(contact);
        }

        #endregion
    }
}
