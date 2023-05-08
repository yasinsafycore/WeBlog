using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeBloge.Domain.Entities.Account;

namespace WeBloge.Domain.Interfaces
{
    public interface IUserRepository
    {
        #region Register

        Task<bool> IsEmailExist(string email);
        void AddUser(User user);

        #endregion

        #region Login

        Task<User> GetUserByEmail(string email);

        #endregion

        #region Activation Email

        Task<User> GetActivateEmail(string activateCode);

        #endregion

        #region UserPanel

        Task<User> GetUserById(int id);

        #endregion

        #region General

        void UpdateUser(User user);
        void SaveChange();

        #endregion

    }
}
