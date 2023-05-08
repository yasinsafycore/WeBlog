using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeBloge.Application.Extensions
{
    public static class DataExtensions
    {
        public static string GetDataShamsi(this DateTime dateTime)
        {
            var pc = new PersianCalendar();

            return $"{pc.GetYear(dateTime)}/{pc.GetMonth(dateTime).ToString("00")}/{pc.GetDayOfMonth(dateTime).ToString("00")}";
        }
    }
}
