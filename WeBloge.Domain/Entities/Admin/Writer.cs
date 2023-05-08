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
	public class Writer : BaseEntity
	{
		#region Properties

		public string Img { get; set; }

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

        #endregion

    }
}
