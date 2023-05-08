using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WeBloge.Domain.ViewModels.Admin
{
    public class CreateWeBlogeViewModel
    {
        #region Properties

        [Display(Name = "تصویر")]
        public IFormFile Img { get; set; }

        public string ImgName { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Title { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Description { get; set; }

        [Display(Name = "دسته بندی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int CategoriesId { get; set; }

        #endregion
    }
    public enum CreateWeBlogeResult
    {
        Success,
        NotValidImg
    }

    //---------------------------------------------------------


    public class UpdateCreateWeBlogeViewModel
    {
        #region Properties

        [Display(Name = "تصویر")]
        public IFormFile Img { get; set; }

        public string ImgName { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Title { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Description { get; set; }

        [Display(Name = "دسته بندی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int CategoriesId { get; set; }

        #endregion
    }
    public enum UpdateCreateWeBlogeResult
    {
        Success,
    }

    //----------------------------------------------------------

    public class UpdateImgWeBlogeViewModel
    {
        #region Properties

        [Display(Name = "تصویر")]
        public IFormFile Img { get; set; }

        public string ImgName { get; set; }

        #endregion
    }
    public enum UpdateImgWeBlogeResult
    {
        Success,
        NotValidImg
    }

}
