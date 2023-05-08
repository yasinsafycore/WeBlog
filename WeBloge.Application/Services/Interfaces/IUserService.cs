using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeBloge.Domain.Entities.Account;
using WeBloge.Domain.ViewModels.Account;
using WeBloge.Domain.ViewModels.UserPanel;

namespace WeBloge.Application.Services.Interfaces
{
    public interface IUserService
    {
        #region Register

        Task<RegisterUserResult> Register(RegisterUserViewModel viewModel);

        #endregion

        #region Login

        Task<LoginUserResult> Login(LoginUserViewModel viewModel);

        Task<User> GetUserByEmail(string email);

        #endregion

        #region Activation Email

        Task<bool> ActivateEmail(string activateCode);

        #endregion

        #region ForgotPassword

        Task<ForgotPasswordResult> ForgotPassword(ForgotPasswordViewModel viewModel);

        #endregion

        #region ResetPassword

        Task<ResetPasswordResult> ResetPassword(ResetPasswordViewModel viewModel);
        Task<User> GetActivateEmail(string activateCode);

        #endregion

        #region UserPanel

        Task<User> GetUserById(int id);
        Task<EditProfileViewModel> EditProfileView(int userId);
        Task<EditProfileResult> EditProfile(EditProfileViewModel viewModel, int userId);
        Task<ChangeUserPasswordResult> ChangeUserPassword(ChangeUserPasswordViewModel viewModel, int userId);

        #endregion
    }
}
