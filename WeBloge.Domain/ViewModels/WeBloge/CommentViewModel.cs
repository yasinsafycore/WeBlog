using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WeBloge.Domain.ViewModels.WeBloge
{
    public class CommentViewModel
    {
        public string Comment { get; set; }

        public int WeBlogesId { get; set; }
    }
}
