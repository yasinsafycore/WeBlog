using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeBloge.Domain.Entities.Admin;
using WeBloge.Domain.Entities.WeBloge;
using WeBloge.Domain.ViewModels.Admin;

namespace WeBloge.Application.Services.Interfaces
{
    public interface IAdminService
    {
        #region Writer

        void AddWriter(Writer writer);

        #endregion

        #region Categories

        Task<CategoriesResult> Categories(CategoriesViewModel viewModel);

        Task<UpdateCategoriesViewModel> UpdateCategoriesView(int categoriesId);

        Task<UpdateCategoriesResult> UpdateCategories(UpdateCategoriesViewModel viewModel, int categoriesId);
       
        Task<List<Categories>> GetAllCategories();

        Task<DeleteCategoriesViewModel> DeleteCategoriesView(int categoriesId);

        Task<DeleteCategoriesResult> DeleteCategories(DeleteCategoriesViewModel viewModel, int categoriesId);

        #endregion

        #region WeBloge

        Task<CreateWeBlogeResult> WeBlogeResult(CreateWeBlogeViewModel viewModel);

        Task<List<WeBloges>> GetAllWeBloges(int weBlogesId);

        Task<UpdateCreateWeBlogeViewModel> UpdateWeBlogeView(int weBlogesId);

        Task<UpdateCreateWeBlogeResult> UpdateWeBloge(UpdateCreateWeBlogeViewModel viewModel, int weBlogesId);

        Task<UpdateImgWeBlogeViewModel> UpdateImgView(int weBlogesId);

        Task<UpdateImgWeBlogeResult> UpdateImg(UpdateImgWeBlogeViewModel viewModel, int weBlogesId);

        Task<CreateWeBlogeViewModel> DeleteWeBlogesView(int weBlogesId);

        Task<CreateWeBlogeResult> DeleteWeBloges(CreateWeBlogeViewModel viewModel, int weBlogesId);

        int WeBlogesCount();

        #endregion

        #region Social

        Task<bool> AddSocial(AddSocialViewModel viewModel);

        #endregion

        #region User

        Task<bool> CheckUserPermission(int permissionId, int userId);


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
