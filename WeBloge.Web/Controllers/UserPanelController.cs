using Core.Classes;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;
using WeBloge.Application.Extensions;
using WeBloge.Application.Services.Interfaces;
using WeBloge.Domain.Entities.Account;
using WeBloge.Domain.Interfaces;
using WeBloge.Domain.ViewModels.UserPanel;

namespace WeBloge.Web.Controllers
{
    [Authorize]
    public class UserPanelController : BaseController
    {
        #region Ctor

        private readonly IUserService _userService;
        public UserPanelController(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

        #region EditProfile

        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            var result = await _userService.EditProfileView(HttpContext.User.GetUserId());

            return View(result);
        }

        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfile(EditProfileViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.EditProfile(viewModel, HttpContext.User.GetUserId());
                switch (result)
                {
                    case EditProfileResult.Success:
                        TempData[SuccessMessage] = "عملیات با موفقیت انجام شد";
                        return View(viewModel);
                }
            }

            return View(viewModel);
        }

        #endregion

        #region ChangePassword

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangeUserPasswordViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.ChangeUserPassword(viewModel, HttpContext.User.GetUserId());
                switch (result)
                {
                    case ChangeUserPasswordResult.Success:
                        TempData[SuccessMessage] = "عملیات با موفقیت انجام شد";
                        await HttpContext.SignOutAsync();
                        return RedirectToAction("Login", "Account");
                    case ChangeUserPasswordResult.Failed:
                        ModelState.AddModelError("OldPassword", "کلمه عبور وارد شده اشتباه است");
                        break;
                    case ChangeUserPasswordResult.EqualPassword:
                        TempData[WarningMessage] = "رمز عبور جدید با قبلی نمی تواند برابر باشد";
                        break;
                }
            }

            return View(viewModel);
        }

        #endregion
    }
}
