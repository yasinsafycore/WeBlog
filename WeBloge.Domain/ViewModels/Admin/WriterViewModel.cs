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
	public class WriterViewModel
	{
		[Display(Name = "تصویر")]
		public IFormFile Img { get; set; }

		public string ImgName { get; set; }

		[Display(Name = "نام")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
		public string FirstName { get; set; }

		[Display(Name = "نام خانوادگی")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
		public string LastName { get; set; }

		[Display(Name = "توضیحات")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		public string Description { get; set; }
	}
}
