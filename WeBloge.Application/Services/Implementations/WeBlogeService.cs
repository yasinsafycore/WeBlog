using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeBloge.Application.Security;
using WeBloge.Application.Services.Interfaces;
using WeBloge.Domain.Entities.Admin;
using WeBloge.Domain.Entities.WeBloge;
using WeBloge.Domain.Interfaces;
using WeBloge.Domain.ViewModels.WeBloge;

namespace WeBloge.Application.Services.Implementations
{
	public class WeBlogeService : IWeBlogeService
	{
		#region Ctor

		private readonly IWeBlogeRepository _weBlogeRepository;

		public WeBlogeService(IWeBlogeRepository weBlogeRepository)
		{
			_weBlogeRepository = weBlogeRepository;
		}

        #endregion

        #region Writer

        public async Task<Writer> GetWriter()
        {
            return await _weBlogeRepository.GetWriter(); 
        }

        #endregion

        #region Categories

        public async Task<List<Categories>> GetAllCategories()
        {
            return await _weBlogeRepository.GetAllCategories();
        }

        #endregion

        #region WeBloge

        public async Task<List<WeBloges>> GetAllWeBloges(int weBlogesId)
        {
            return await _weBlogeRepository.GetAllWeBloges(weBlogesId);
        }

        public async Task<WeBloges> GetWeBlogesById(int weBlogesId)
        {
            return await _weBlogeRepository.GetWeBlogesById(weBlogesId);
        }

        public int WeBlogesCount()
        {
            return _weBlogeRepository.WeBlogesCount();
        }

        public async Task<List<WeBloges>> GetLatestPosts()
        {
            return await _weBlogeRepository.GetLatestPosts();
        }

        #endregion

        #region Social

        public async Task<Social> GetSocial()
        {
            return await _weBlogeRepository.GetSocial();
        }

        #endregion

        #region Comment

        public async Task<bool> CommentWeBloge(CommentViewModel viewModel)
        {
            var weBloge = await _weBlogeRepository.GetWeBlogesById(viewModel.WeBlogesId);

            if (weBloge == null) return false;

            var comment = new Comment
            {
                Content = viewModel.Comment.SanitizeText(),
                WeBlogesId = viewModel.WeBlogesId
            };
            
            _weBlogeRepository.AddComment(comment);
            await _weBlogeRepository.SaveChange();

            return true;
        }

        public async Task<List<Comment>> GetAllComments(int weBlogesId)
        {
            return await _weBlogeRepository.GetAllComments(weBlogesId);
        }

        #endregion

        #region ContactUs

        public async Task<bool> AddContactUs(ContactUsViewModel viewModel)
        {
            var contactUs = new ContactUs
            {
                Description = viewModel.Description.SanitizeText(),
                FirstName = viewModel.FirstName.SanitizeText(),
                LastName = viewModel.LastName.SanitizeText(),
                Subject = viewModel.Subject.SanitizeText()
            };

            if (contactUs == null) return false;

            _weBlogeRepository.AddContactUs(contactUs);
            await _weBlogeRepository.SaveChange();

            return true;
        }

        #endregion
    }
}
