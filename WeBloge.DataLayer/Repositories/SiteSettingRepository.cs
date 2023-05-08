using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeBloge.DataLayer.Context;
using WeBloge.Domain.Entities.SiteSetting;
using WeBloge.Domain.Interfaces;

namespace WeBloge.DataLayer.Repositories
{
    public class SiteSettingRepository : ISiteSettingRepository
    {
        #region Ctor

        private WeBlogeDbContext _context;

        public SiteSettingRepository(WeBlogeDbContext context)
        {
            _context = context;
        }

        #endregion

        public async Task<EmailSetting> GetDefaultEmail()
        {
            return await _context.EmailSettings.FirstOrDefaultAsync(s => !s.IsDelete && s.IsDefault);
        }
    }
}
