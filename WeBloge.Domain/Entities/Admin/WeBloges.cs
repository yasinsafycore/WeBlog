using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WeBloge.Domain.Entities.BaseEntities;
using WeBloge.Domain.Entities.WeBloge;

namespace WeBloge.Domain.Entities.Admin
{
    public class WeBloges : BaseEntity
    {
        #region Properties

        public string Img { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Title { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Description { get; set; }

        public int CategoriesId { get; set; }

        #endregion

        #region Relations

        public Categories Categories { get; set; }

        public ICollection<Comment> Comments { get; set; }

        #endregion
    }
}
