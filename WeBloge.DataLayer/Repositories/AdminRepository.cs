using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeBloge.DataLayer.Context;
using WeBloge.Domain.Entities.Account;
using WeBloge.Domain.Entities.Admin;
using WeBloge.Domain.Entities.WeBloge;
using WeBloge.Domain.Interfaces;

namespace WeBloge.DataLayer.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        #region Ctor

        private readonly WeBlogeDbContext _context;

        public AdminRepository(WeBlogeDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Writer

        public void AddWriter(Writer writer)
        {
           _context.Writers.Add(writer);
        }

        #endregion

        #region Categories

        public void AddCategories(Categories categories)
        {
            _context.Categories.Add(categories);
        }

        public async Task<List<Categories>> GetAllCategories()
        {
            return await _context.Categories.OrderBy(p => -p.Id).Where(p => !p.IsDelete).ToListAsync();
        }

        public async Task<Categories> GetCategoriesById(int categoriesId)
        {
            return await _context.Categories.Where(p => !p.IsDelete).SingleOrDefaultAsync(p => p.Id == categoriesId);
        }

        public void UpdateCategories(Categories categories)
        {
            _context.Categories.Update(categories);
        }

        #endregion

        #region WeBloge

        public void AddWeBloges(WeBloges weBloges)
        {
            _context.WeBloges.Add(weBloges);
        }

        public async Task<List<WeBloges>> GetAllWeBloges(int weBlogesId)
        {
            int skip = (weBlogesId - 1) * 6;

            return await _context.WeBloges.OrderBy(p => -p.Id).Where(p => !p.IsDelete).Skip(skip).Take(6).ToListAsync();
        }

        public async Task<WeBloges> GetWeBlogesById(int weBlogesId)
        {
            return await _context.WeBloges.Where(p => !p.IsDelete).SingleOrDefaultAsync(p => p.Id == weBlogesId);
        }

        public void UpdateWeBloges(WeBloges weBloges)
        {
            _context.WeBloges.Update(weBloges);
        }

        public int WeBlogesCount()
        {
           return _context.WeBloges.Where(p => !p.IsDelete).Count();
        }

        #endregion

        #region Social

        public void AddSocial(Social social)
        {
            _context.Socials.Add(social);
        }

        public void UpdateSocial(Social social)
        {
            _context.Socials.Update(social);
        }

        #endregion

        #region User

        public async Task<bool> CheckUserHasPermission(int userId, int permissionId)
        {
            return await _context.UserPermissions
                .AnyAsync(s => s.UserId == userId && s.PermissionId == permissionId);
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(s => !s.IsDelete && s.Id == id);
        }

        #endregion

        #region ContactUs

        public async Task<List<ContactUs>> GetAllContactUs(int contactId)
        {
            int skip = (contactId - 1) * 6;

            return await _context.ContactUs.OrderBy(p => -p.Id).Where(p => !p.IsDelete).Skip(skip).Take(6).ToListAsync();
        }

        public int ContactUsCount()
        {
           return _context.ContactUs.Where(p => !p.IsDelete).Count();
        }

        public async Task<ContactUs> GetContactUsById(int contactId)
        {
            return await _context.ContactUs.SingleOrDefaultAsync(p => p.Id == contactId && !p.IsDelete);
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
