﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeBloge.Application.Statics
{
    public static class PathTools
    {
        #region Site

        public static readonly string SiteAddress = "https://localhost:44325";

        #endregion

        #region Ckeditor

        public static readonly string EditorImageServerPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/content/ckeditor/");
        public static readonly string EditorImagePath = "/content/ckeditor/";

        #endregion
    }
}
