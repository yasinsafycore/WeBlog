using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using WeBloge.Application.Services.Interfaces;
using WeBloge.Domain.ViewModels.Account;
using GoogleReCaptcha.V3.Interface;
using WeBloge.Web.ActionFilters;

namespace WeBloge.Web.Controllers
{
    public class AccountController : BaseController
    {
        #region Ctor

        private readonly IUserService _userService;
        private ICaptchaValidator _captchaValidator;
        public AccountController(IUserService userService, ICaptchaValidator captchaValidator)
        {
            _userService = userService;
            _captchaValidator = captchaValidator;
        }

        #endregion

        #region Register

        [HttpGet("register")]
        [RedirectActionFilters]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("register"),ValidateAntiForgeryToken]
        [RedirectActionFilters]
        public async Task<IActionResult> Register(RegisterUserViewModel viewModel)
        {
            #region Captcha

            if (!await _captchaValidator.IsCaptchaPassedAsync(viewModel.Captcha))
            {
                TempData[ErrorMessage] = "اعتبار سنجی Captcha با خطا مواجه شد لطفا مجدد تلاش کنید";
                return View(viewModel);
            }

            #endregion

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var result = await _userService.Register(viewModel);
            switch (result)
            {
                case RegisterUserResult.Success:
                    TempData[SuccessMessage] = "عملیات با موفقیت انجام شد";
                    return RedirectToAction("Login", "Account");
                case RegisterUserResult.EmailExist:
                    TempData[ErrorMessage] = "ایمیل وارد شده از قبل موجود است";
                    break;
            }

            return View(viewModel);
        }

        #endregion

        #region Login

        [HttpGet("login")]
        [RedirectActionFilters]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("login"),ValidateAntiForgeryToken]
        [RedirectActionFilters]
        public async Task<IActionResult> Login(LoginUserViewModel viewModel)
        {
            #region Captcha

            if (!await _captchaValidator.IsCaptchaPassedAsync(viewModel.Captcha))
            {
                TempData[ErrorMessage] = "اعتبار سنجی Captcha با خطا مواجه شد لطفا مجدد تلاش کنید";
                return View(viewModel);
            }

            #endregion

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var result = await _userService.Login(viewModel);
            switch (result)
            {
                case LoginUserResult.UserIsBan:
                    TempData[WarningMessage] = "دسترسی شما به سایت مسدود می باشد";
                    break;
                case LoginUserResult.UserNotFound:
                    TempData[ErrorMessage] = "کاربر مورد نظر یافت نشد";
                    break;
                case LoginUserResult.EmailNotActivated:
                    TempData[WarningMessage] = "برای ورود به حساب کاربری ابتدا ایمیل خود را فعال کنید";
                    break;
                case LoginUserResult.Success:
                    var user = await _userService.GetUserByEmail(viewModel.Email);

                    #region Login User

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    var properties = new AuthenticationProperties { IsPersistent = viewModel.RememberMe };

                    await HttpContext.SignInAsync(principal, properties);

                    #endregion

                    //TempData[SuccessMessage] = "خوش آمدید";

                    return RedirectToAction("Index","Home");

            }

            return View(viewModel);
        }

        #endregion

        #region Logout

        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        #endregion

        #region Activation Email

        [HttpGet("Activate-Email/{activateCode}")]
        [RedirectActionFilters]
        public async Task<IActionResult> ActivationEmail(string activateCode)
        {
            var result = await _userService.ActivateEmail(activateCode);

            if (result)
            {
                TempData[SuccessMessage] = "حساب کاربری شما با موفقیت فعال شد";
            }
            else
            {
                TempData[ErrorMessage] = "فعال سازی حساب کاربری با خطا مواجه شد";
            }

            return RedirectToAction("Login", "Account");
        }

        #endregion

        #region ForgotPassword

        [HttpGet("forgotpassword")]
        [RedirectActionFilters]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost("forgotpassword"),ValidateAntiForgeryToken]
        [RedirectActionFilters]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel viewModel)
        {
            #region Captcha

            if (!await _captchaValidator.IsCaptchaPassedAsync(viewModel.Captcha))
            {
                TempData[ErrorMessage] = "اعتبار سنجی Captcha با خطا مواجه شد لطفا مجدد تلاش کنید";
                return View(viewModel);
            }

            #endregion

            if (ModelState.IsValid)
            {
                var result = await _userService.ForgotPassword(viewModel);
                switch (result)
                {
                    case ForgotPasswordResult.Success:
                        TempData[InfoMessage] = "لینک بازیابی رمز عبور به ایمیل شما ارسال شد";
                        return RedirectToAction("Login", "Account");
                    case ForgotPasswordResult.NotFound:
                        TempData[ErrorMessage] = "کاربری با مشخصات وارد شده یافت نشد";
                        break;
                    case ForgotPasswordResult.UserIsBan:
                        TempData[WarningMessage] = "دسترسی شما به حساب کاربری مسدود می باشد";
                        break;
                }
            }

            return View(viewModel);
        }

        #endregion

        #region ResetPassword

        [HttpGet("Reset-Password/{activateCode}")]
        [RedirectActionFilters]
        public async Task<IActionResult> ResetPassword(string activateCode)
        {
            var user = await _userService.GetActivateEmail(activateCode);
            if (user == null || user.IsDelete || user.IsBan) return NotFound();

            return View(new ResetPasswordViewModel
            {
                EmailActivationCode = user.EmailActivationCode
            });
        }

        [HttpPost("Reset-Password/{activateCode}")]
        [RedirectActionFilters]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel viewModel)
        {
            #region Captcha

            if (!await _captchaValidator.IsCaptchaPassedAsync(viewModel.Captcha))
            {
                TempData[ErrorMessage] = "اعتبار سنجی Captcha با خطا مواجه شد لطفا مجدد تلاش کنید";
                return View(viewModel);
            }

            #endregion

            if (ModelState.IsValid)
            {
                var result = await _userService.ResetPassword(viewModel);
                switch (result)
                {
                    case ResetPasswordResult.Success:
                        TempData[SuccessMessage] = "عملیات با موفقیت انجام شد";
                        return RedirectToAction("Login", "Account");
                    case ResetPasswordResult.UserNotFound:
                        TempData[ErrorMessage] = "کاربر مورد نظر یافت نشد";
                        break;
                    case ResetPasswordResult.UserIsBan:
                        TempData[WarningMessage] = "دسترسی شما به سایت مسدود می باشد";
                        break;
                }
            }

            return View(viewModel);
        }

        #endregion

    }
}
