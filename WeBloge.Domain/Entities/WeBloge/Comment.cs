using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WeBloge.Domain.Entities.Account;
using WeBloge.Domain.Entities.Admin;
using WeBloge.Domain.Entities.BaseEntities;

namespace WeBloge.Domain.Entities.WeBloge
{
    public class Comment : BaseEntity
    {
        #region Properties

        [Display(Name = "پاسخ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Content { get; set; }

        public int WeBlogesId { get; set; }

        #endregion

        #region Relations

        public WeBloges WeBloges { get; set; }

        #endregion
    }
}
