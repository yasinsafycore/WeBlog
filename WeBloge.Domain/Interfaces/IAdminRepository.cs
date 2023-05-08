using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeBloge.Domain.Entities.Account;
using WeBloge.Domain.Entities.Admin;
using WeBloge.Domain.Entities.WeBloge;

namespace WeBloge.Domain.Interfaces
{
    public interface IAdminRepository
    {
        #region Writer

        void AddWriter(Writer writer);

        #endregion

        #region Categories

        void AddCategories(Categories categories);

        Task<Categories> GetCategoriesById(int categoriesId);

        Task<List<Categories>> GetAllCategories();

        void UpdateCategories(Categories categories);

        #endregion

        #region WeBloge

        void AddWeBloges(WeBloges weBloges);

        Task<List<WeBloges>> GetAllWeBloges(int weBlogesId);

        Task<WeBloges> GetWeBlogesById(int weBlogesId);

        void UpdateWeBloges(WeBloges weBloges);

        int WeBlogesCount();

        #endregion

        #region Social

        void AddSocial(Social social);

        #endregion

        #region User

        Task<bool> CheckUserHasPermission(int userId, int permissionId);
        Task<User> GetUserById(int id);

        #endregion

        #region ContactUs

        Task<List<ContactUs>> GetAllContactUs(int contactId);
        int ContactUsCount();
        Task<ContactUs> GetContactUsById(int contactId);

        #endregion

        #region General

        Task SaveChange();

        #endregion
    }
}
