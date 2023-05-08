using Core.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeBloge.Application.Security;
using WeBloge.Application.Services.Interfaces;
using WeBloge.Domain.Entities.Admin;
using WeBloge.Domain.Entities.WeBloge;
using WeBloge.Domain.Interfaces;
using WeBloge.Domain.ViewModels.Admin;

namespace WeBloge.Application.Services.Implementations
{
    public class AdminService : IAdminService
    {
        #region Ctor

        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        #endregion

        #region Writer

        public void AddWriter(Writer writer)
        {
            _adminRepository.AddWriter(writer);
        }

        #endregion

        #region Categories

        public async Task<CategoriesResult> Categories(CategoriesViewModel viewModel)
        {
            var result = new Categories
            {
                Title = viewModel.Title.SanitizeText(),
            };

            _adminRepository.AddCategories(result);
            await _adminRepository.SaveChange();

            return CategoriesResult.Success;
        }

        public async Task<UpdateCategoriesViewModel> UpdateCategoriesView(int categoriesId)
        {
            var categories = await _adminRepository.GetCategoriesById(categoriesId);

            var result = new UpdateCategoriesViewModel
            {
                Title = categories.Title.SanitizeText(),
            };

            return result;
        }

        public async Task<UpdateCategoriesResult> UpdateCategories(UpdateCategoriesViewModel viewModel, int categoriesId)
        {
            var categories = await _adminRepository.GetCategoriesById(categoriesId);

            categories.Title = viewModel.Title.SanitizeText();

            _adminRepository.UpdateCategories(categories);
            await _adminRepository.SaveChange();

            return UpdateCategoriesResult.Success;
        }

        public async Task<List<Categories>> GetAllCategories()
        {
            return await _adminRepository.GetAllCategories();
        }

        public async Task<DeleteCategoriesViewModel> DeleteCategoriesView(int categoriesId)
        {
            var categories = await _adminRepository.GetCategoriesById(categoriesId);

            var result = new DeleteCategoriesViewModel
            {
                Title = categories.Title.SanitizeText(),
            };

            return result;
        }

        public async Task<DeleteCategoriesResult> DeleteCategories(DeleteCategoriesViewModel viewModel, int categoriesId)
        {
            var categories = await _adminRepository.GetCategoriesById(categoriesId);

            categories.IsDelete = true;

            _adminRepository.UpdateCategories(categories);
            await _adminRepository.SaveChange();

            return DeleteCategoriesResult.Success;
        }

        #endregion

        #region WeBloge

        public async Task<CreateWeBlogeResult> WeBlogeResult(CreateWeBlogeViewModel viewModel)
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

                WeBloges weBloges = new WeBloges()
                {
                    CategoriesId = viewModel.CategoriesId,
                    Description = viewModel.Description.SanitizeText(),
                    Title = viewModel.Title.SanitizeText(),
                    Img = viewModel.ImgName.SanitizeText(),
                };

                _adminRepository.AddWeBloges(weBloges);
                await _adminRepository.SaveChange();
            }

            if (viewModel.Img == null)
            {
                return CreateWeBlogeResult.NotValidImg;
            }

            return CreateWeBlogeResult.Success;
        }

        public async Task<List<WeBloges>> GetAllWeBloges(int weBlogesId)
        {
            return await _adminRepository.GetAllWeBloges(weBlogesId);
        }

        public async Task<UpdateCreateWeBlogeViewModel> UpdateWeBlogeView(int weBlogesId)
        {
            var weBloge = await _adminRepository.GetWeBlogesById(weBlogesId);

            var result = new UpdateCreateWeBlogeViewModel
            {
                CategoriesId = weBloge.CategoriesId,
                Description = weBloge.Description.SanitizeText(),
                Title = weBloge.Title.SanitizeText()
            };

            return result;
        }

        public async Task<UpdateCreateWeBlogeResult> UpdateWeBloge(UpdateCreateWeBlogeViewModel viewModel, int weBlogesId)
        {

                var weBloge = await _adminRepository.GetWeBlogesById(weBlogesId);

                weBloge.Title = viewModel.Title.SanitizeText();
                weBloge.CategoriesId = viewModel.CategoriesId;
                weBloge.Description = viewModel.Description.SanitizeText();

                _adminRepository.UpdateWeBloges(weBloge);
                await _adminRepository.SaveChange();
            

            return UpdateCreateWeBlogeResult.Success;
        }

        public async Task<UpdateImgWeBlogeViewModel> UpdateImgView(int weBlogesId)
        {
            var weBloge = await _adminRepository.GetWeBlogesById(weBlogesId);

            var result = new UpdateImgWeBlogeViewModel
            {
                ImgName = weBloge.Img.SanitizeText()
            };

            return result;
        }

        public async Task<UpdateImgWeBlogeResult> UpdateImg(UpdateImgWeBlogeViewModel viewModel, int weBlogesId)
        {
            if (viewModel.Img != null)
            {
                var weBloge = await _adminRepository.GetWeBlogesById(weBlogesId);

                string filePath = "";
                viewModel.ImgName = RandomCodeGenerators.CreateFileCode() + Path.GetExtension(viewModel.Img.FileName);
                filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/content/gallery", viewModel.ImgName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    viewModel.Img.CopyTo(stream);
                }

                weBloge.Img = viewModel.ImgName.SanitizeText();

                _adminRepository.UpdateWeBloges(weBloge);
                await _adminRepository.SaveChange();
            }

            return UpdateImgWeBlogeResult.Success;
        }

        public async Task<CreateWeBlogeViewModel> DeleteWeBlogesView(int weBlogesId)
        {
            var weBloge = await _adminRepository.GetWeBlogesById(weBlogesId);

            var result = new CreateWeBlogeViewModel
            {
                Title = weBloge.Title.SanitizeText()
            };

            return result;
        }

        public async Task<CreateWeBlogeResult> DeleteWeBloges(CreateWeBlogeViewModel viewModel, int weBlogesId)
        {
            var weBloge = await _adminRepository.GetWeBlogesById(weBlogesId);

            weBloge.IsDelete = true;

            _adminRepository.UpdateWeBloges(weBloge);
            await _adminRepository.SaveChange();

            return CreateWeBlogeResult.Success;
        }

        public int WeBlogesCount()
        {
           return _adminRepository.WeBlogesCount();
        }

        #endregion

        #region Social

        public async Task<bool> AddSocial(AddSocialViewModel viewModel)
        {
            var result = new Social
            {
                Facebook = viewModel.Facebook.SanitizeText(),
                Twitter = viewModel.Twitter.SanitizeText(),
                Instagram = viewModel.Instagram.SanitizeText(),
                Youtube = viewModel.Youtube.SanitizeText()
            };

            _adminRepository.AddSocial(result);
            await _adminRepository.SaveChange();

            return true;
        }

        #endregion

        #region User

        public async Task<bool> CheckUserPermission(int permissionId, int userId)
        {
            var user = await _adminRepository.GetUserById(userId);

            if (user == null) return false;

            if (user.IsAdmin) return true;

            return await _adminRepository.CheckUserHasPermission(user.Id, permissionId);
        }

        #endregion

        #region ContactUs

        public async Task<List<ContactUs>> GetAllContactUs(int contactId)
        {
            return await _adminRepository.GetAllContactUs(contactId);
        }

        public int ContactUsCount()
        {
            return _adminRepository.ContactUsCount();
        }

        public async Task<ContactUs> GetContactUsById(int contactId)
        {
            return await _adminRepository.GetContactUsById(contactId);
        }

        #endregion

        #region General

        public async Task SaveChange()
        {
            await _adminRepository.SaveChange();
        }

        #endregion
    }
}
