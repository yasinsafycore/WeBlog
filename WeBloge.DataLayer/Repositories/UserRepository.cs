using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeBloge.DataLayer.Context;
using WeBloge.Domain.Entities.Account;
using WeBloge.Domain.Interfaces;

namespace WeBloge.DataLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        #region Ctor

        private readonly WeBlogeDbContext _context;

        public UserRepository(WeBlogeDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Register

        public async Task<bool> IsEmailExist(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

        public void AddUser(User user)
        {
            _context.Add(user);
        }

        #endregion

        #region Login

        public async Task<User> GetUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(p => p.Email == email);
        }

        #endregion

        #region Activation Email

        public async Task<User> GetActivateEmail(string activateCode)
        {
            return await _context.Users.SingleOrDefaultAsync(p => p.EmailActivationCode == activateCode);
        }

        #endregion

        #region UserPanel

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.SingleOrDefaultAsync(p => p.Id == id);
        }

        #endregion

        #region General

        public void UpdateUser(User user)
        {
            _context.Update(user);
        }

        public void SaveChange()
        {
            _context.SaveChanges();
        }

        #endregion

    }
}
