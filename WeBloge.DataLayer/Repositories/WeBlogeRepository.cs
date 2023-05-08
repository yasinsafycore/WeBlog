using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeBloge.DataLayer.Context;
using WeBloge.Domain.Entities.Admin;
using WeBloge.Domain.Entities.WeBloge;
using WeBloge.Domain.Interfaces;

namespace WeBloge.DataLayer.Repositories
{
	public class WeBlogeRepository : IWeBlogeRepository
	{
		#region Ctor

		private readonly WeBlogeDbContext _context;

		public WeBlogeRepository(WeBlogeDbContext context)
		{
			_context = context;
		}

        #endregion

        #region Writer

        public async Task<Writer> GetWriter()
        {
            return await _context.Writers.OrderBy(p => -p.Id).FirstOrDefaultAsync();
        }

        #endregion

        #region Categories

        public async Task<List<Categories>> GetAllCategories()
        {
            return await _context.Categories.OrderBy(p => -p.Id).Where(p => !p.IsDelete).ToListAsync();
        }

        #endregion

        #region WeBloge

        public async Task<List<WeBloges>> GetAllWeBloges(int weBlogesId)
        {
            int skip = (weBlogesId - 1) * 6;

            return await _context.WeBloges.Include(p => p.Categories).OrderBy(p => -p.Id).Where(p => !p.IsDelete).Skip(skip).Take(6).ToListAsync();
        }

        public int WeBlogesCount()
        {
            return _context.WeBloges.Where(p => !p.IsDelete).Count();
        }

        public async Task<WeBloges> GetWeBlogesById(int weBlogesId)
        {
            return await _context.WeBloges
                .Include(p => p.Categories)
                .Where(p => !p.IsDelete).FirstOrDefaultAsync(p => p.Id == weBlogesId);
        }

        public async Task<List<WeBloges>> GetLatestPosts()
        {
            return await _context.WeBloges.OrderBy(p => -p.Id).Take(4).Where(p => !p.IsDelete).ToListAsync();
        }

        #endregion

        #region Social

        public async Task<Social> GetSocial()
        {
            return await _context.Socials.OrderBy(p => -p.Id).Where(p => !p.IsDelete).FirstOrDefaultAsync();
        }

        #endregion

        #region Comment

        public void AddComment(Comment comment)
        {
            _context.Comments.Add(comment);
        }

        public async Task<List<Comment>> GetAllComments(int weBlogesId)
        {
            return await _context.Comments.Where(p => p.WeBlogesId == weBlogesId && !p.IsDelete).OrderByDescending(s => s.CreateDate).ToListAsync();
        }

        #endregion

        #region ContactUs

        public void AddContactUs(ContactUs contactUs)
        {
            _context.ContactUs.Add(contactUs);
        }

        #endregion

        #region General

        public async Task SaveChange()
        {
           await _context.SaveChangesAsync();
        }

        #endregion
    }
}
