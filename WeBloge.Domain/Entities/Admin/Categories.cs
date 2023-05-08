using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WeBloge.Domain.Entities.BaseEntities;

namespace WeBloge.Domain.Entities.Admin
{
    public class Categories : BaseEntity
    {
        #region Properties

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Title { get; set; }

        #endregion

        #region Relations

        public ICollection<WeBloges> WeBloges { get; set; }

        #endregion
    }
}
