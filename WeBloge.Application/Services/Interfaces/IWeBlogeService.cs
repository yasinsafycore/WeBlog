using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeBloge.Domain.Entities.Admin;
using WeBloge.Domain.Entities.WeBloge;
using WeBloge.Domain.ViewModels.WeBloge;

namespace WeBloge.Application.Services.Interfaces
{
	public interface IWeBlogeService
	{
        #region Writer

        Task<Writer> GetWriter();

        #endregion

        #region Categories

        Task<List<Categories>> GetAllCategories();

        #endregion

        #region WeBloge

        Task<List<WeBloges>> GetAllWeBloges(int weBlogesId);

        Task<WeBloges> GetWeBlogesById(int weBlogesId);

        int WeBlogesCount();

        Task<List<WeBloges>> GetLatestPosts();

        #endregion

        #region Social

        Task<Social> GetSocial();

        #endregion

        #region Comment

        Task<bool> CommentWeBloge(CommentViewModel viewModel);

        Task<List<Comment>> GetAllComments(int weBlogesId);

        #endregion

        #region ContactUs

        Task<bool> AddContactUs(ContactUsViewModel viewModel);

        #endregion
    }
}
