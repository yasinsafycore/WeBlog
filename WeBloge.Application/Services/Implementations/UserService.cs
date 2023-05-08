using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeBloge.Application.Generators;
using WeBloge.Application.Security;
using WeBloge.Application.Services.Interfaces;
using WeBloge.Application.Statics;
using WeBloge.Domain.Entities.Account;
using WeBloge.Domain.Interfaces;
using WeBloge.Domain.ViewModels.Account;
using WeBloge.Domain.ViewModels.UserPanel;

namespace WeBloge.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        #region Ctor

        private readonly IUserRepository _userRepository;
        private IEmailService _emailService;

        public UserService(IUserRepository userRepository, IEmailService emailService)
        {
            _userRepository = userRepository;
            _emailService = emailService;
        }

        #endregion

        #region Register

        public async Task<RegisterUserResult> Register(RegisterUserViewModel viewModel)
        {
            if (await _userRepository.IsEmailExist(viewModel.Email.Trim().SanitizeText()))
            {
                return RegisterUserResult.EmailExist;
            }

            var password = PasswordHelper.EncodePasswordMd5(viewModel.Password.SanitizeText());

            var user = new User
            {
                Email = viewModel.Email.Trim().SanitizeText(),
                EmailActivationCode = CodeGenerators.CreateActivationCode(),
                IsEmailActive = false,
                Password = password,
            };

             _userRepository.AddUser(user);
             _userRepository.SaveChange();

            //Email Send
            #region Send Activation Email

            var body = $@"
                <div> برای فعالسازی حساب کاربری خود روی لینک زیر کلیک کنید . </div>
                <a href='{PathTools.SiteAddress}/Activate-Email/{user.EmailActivationCode}'>فعالسازی حساب کاربری</a>
                ";

            await _emailService.SendEmail(user.Email, "فعالسازی حساب کاربری", body);

            #endregion

            return RegisterUserResult.Success;
        }

        #endregion

        #region Login

        public async Task<LoginUserResult> Login(LoginUserViewModel viewModel)
        {
            var user = await _userRepository.GetUserByEmail(viewModel.Email.Trim().SanitizeText());

            var password = PasswordHelper.EncodePasswordMd5(viewModel.Password.SanitizeText());

            if (user == null) return LoginUserResult.UserNotFound;
            if (user.IsBan) return LoginUserResult.UserIsBan;
            if (user.IsDelete) return LoginUserResult.UserNotFound;
            if (!user.IsEmailActive) return LoginUserResult.EmailNotActivated;
            if (user.Password != password) return LoginUserResult.UserNotFound;

            return LoginUserResult.Success;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _userRepository.GetUserByEmail(email);
        }

        #endregion

        #region Activation Email

        public async Task<bool> ActivateEmail(string activateCode)
        {
            var user = await _userRepository.GetActivateEmail(activateCode);

            if (user == null) return false;
            if (user.IsDelete || user.IsBan) return false;

            user.IsEmailActive = true;
            user.EmailActivationCode = CodeGenerators.CreateActivationCode();

             _userRepository.UpdateUser(user);
             _userRepository.SaveChange();

            return true;
        }

        #endregion

        #region ForgotPassword

        public async Task<ForgotPasswordResult> ForgotPassword(ForgotPasswordViewModel viewModel)
        {
            var user = await _userRepository.GetUserByEmail(viewModel.Email.Trim().SanitizeText());

            if (user == null || user.IsDelete) return ForgotPasswordResult.NotFound;
            if (user.IsBan) return ForgotPasswordResult.UserIsBan;

            //Email Send
            #region Send Activation Email

            var body = $@"
                <div> برای فراموشی کلمه عبور روی لینک زیر کلیک کنید . </div>
                <a href='{PathTools.SiteAddress}/Reset-Password/{user.EmailActivationCode}'>فراموشی کلمه عبور</a>
                ";

            await _emailService.SendEmail(user.Email, "فراموشی کلمه عبور", body);

            #endregion

            return ForgotPasswordResult.Success;
        }

        #endregion

        #region ResetPassword

        public async Task<ResetPasswordResult> ResetPassword(ResetPasswordViewModel viewModel)
        {
            var user = await _userRepository.GetActivateEmail(viewModel.EmailActivationCode.SanitizeText());
            var password = PasswordHelper.EncodePasswordMd5(viewModel.Password.SanitizeText());

            if (user == null || user.IsDelete) return ResetPasswordResult.UserNotFound;
            if (user.IsBan) return ResetPasswordResult.UserIsBan;

            user.EmailActivationCode = CodeGenerators.CreateActivationCode();
            user.IsEmailActive = true;
            user.Password = password;

             _userRepository.UpdateUser(user);
             _userRepository.SaveChange();

            return ResetPasswordResult.Success;
        }

        public Task<User> GetActivateEmail(string activateCode)
        {
            return _userRepository.GetActivateEmail(activateCode.SanitizeText());
        }

        #endregion

        #region UserPanel

        public async Task<User> GetUserById(int id)
        {
            return await _userRepository.GetUserById(id);
        }

        public async Task<EditProfileViewModel> EditProfileView(int userId)
        {
            var user = await _userRepository.GetUserById(userId);

            var result = new EditProfileViewModel
            {
                Description = user.Description.SanitizeText(),
                FirstName = user.FirstName.SanitizeText(),
                LastName = user.LastName.SanitizeText(),
                PhoneNumber = user.PhoneNumber.SanitizeText()
            };

            return result;
        }

        public async Task<EditProfileResult> EditProfile(EditProfileViewModel viewModel, int userId)
        {
            var user = await _userRepository.GetUserById(userId);

            user.PhoneNumber = viewModel.PhoneNumber.SanitizeText();
            user.FirstName = viewModel.FirstName.SanitizeText();
            user.LastName = viewModel.LastName.SanitizeText();
            user.Description = viewModel.Description.SanitizeText();

             _userRepository.UpdateUser(user);
             _userRepository.SaveChange();

            return EditProfileResult.Success;
        }

        public async Task<ChangeUserPasswordResult> ChangeUserPassword(ChangeUserPasswordViewModel viewModel, int userId)
        {
            var user = await _userRepository.GetUserById(userId);

            var oldPassword = PasswordHelper.EncodePasswordMd5(viewModel.OldPassword.SanitizeText());

            if (oldPassword != user.Password) return ChangeUserPasswordResult.Failed;

            var password = PasswordHelper.EncodePasswordMd5(viewModel.Password.SanitizeText());

            if (oldPassword == password) return ChangeUserPasswordResult.EqualPassword;

            user.Password = password;
            
             _userRepository.UpdateUser(user);
             _userRepository.SaveChange();

            return ChangeUserPasswordResult.Success;
        }

        #endregion
    }
}
