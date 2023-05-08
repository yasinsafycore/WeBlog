using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeBloge.Domain.Entities.Account;
using WeBloge.Domain.Entities.Admin;
using WeBloge.Domain.Entities.SiteSetting;
using WeBloge.Domain.Entities.WeBloge;

namespace WeBloge.DataLayer.Context
{
    public class WeBlogeDbContext : DbContext
    {
        #region Ctor

        public WeBlogeDbContext(DbContextOptions<WeBlogeDbContext> options) : base(options)
        {

        }

        #endregion

        #region DBSet

        public DbSet<User> Users { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<UserPermission> UserPermissions { get; set; }
        public DbSet<EmailSetting> EmailSettings { get; set; }
		public DbSet<Writer> Writers { get; set; }
        public DbSet<WeBloges> WeBloges { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Social> Socials { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relation in modelBuilder.Model.GetEntityTypes().SelectMany(s => s.GetForeignKeys()))
            {
                relation.DeleteBehavior = DeleteBehavior.Restrict;
            }

            #region Seed Data

            var date = DateTime.MinValue;

            modelBuilder.Entity<EmailSetting>().HasData(new EmailSetting()
            {
                CreateDate = date,
                DisplayName = "Webloge",
                EnableSSL = true,

                //Email
                From = "",
                Id = 1,
                IsDefault = true,
                IsDelete = false,

                //emailPassword
                Password = "",
                Port = 587,
                SMTP = "smtp.gmail.com"
            });

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
