#pragma checksum "F:\ASP.NET CORE\WeBloge\WeBloge.Web\Views\Shared\_Notification.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "43892cd7793a953fb48429437b13612077b7aa38"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Notification), @"mvc.1.0.view", @"/Views/Shared/_Notification.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "F:\ASP.NET CORE\WeBloge\WeBloge.Web\Views\_ViewImports.cshtml"
using WeBloge.Web;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"43892cd7793a953fb48429437b13612077b7aa38", @"/Views/Shared/_Notification.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8264d026be87a64d5e4e6226594d03b3d616122d", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared__Notification : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "F:\ASP.NET CORE\WeBloge\WeBloge.Web\Views\Shared\_Notification.cshtml"
 if (TempData["SuccessMessage"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <script>\r\n        swal({\r\n            title: \"اعلان\",\r\n            text: \"");
#nullable restore
#line 6 "F:\ASP.NET CORE\WeBloge\WeBloge.Web\Views\Shared\_Notification.cshtml"
              Write(TempData["SuccessMessage"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\",\r\n            icon: \"success\",\r\n            button: \"باشه\"\r\n        });\r\n    </script>\r\n");
#nullable restore
#line 11 "F:\ASP.NET CORE\WeBloge\WeBloge.Web\Views\Shared\_Notification.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 13 "F:\ASP.NET CORE\WeBloge\WeBloge.Web\Views\Shared\_Notification.cshtml"
 if (TempData["WarningMessage"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <script>\r\n        swal({\r\n            title: \"اعلان\",\r\n            text: \"");
#nullable restore
#line 18 "F:\ASP.NET CORE\WeBloge\WeBloge.Web\Views\Shared\_Notification.cshtml"
              Write(TempData["WarningMessage"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\",\r\n            icon: \"warning\",\r\n            button: \"باشه\"\r\n        });\r\n    </script>\r\n");
#nullable restore
#line 23 "F:\ASP.NET CORE\WeBloge\WeBloge.Web\Views\Shared\_Notification.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 25 "F:\ASP.NET CORE\WeBloge\WeBloge.Web\Views\Shared\_Notification.cshtml"
 if (TempData["InfoMessage"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <script>\r\n        swal({\r\n            title: \"اعلان\",\r\n            text: \"");
#nullable restore
#line 30 "F:\ASP.NET CORE\WeBloge\WeBloge.Web\Views\Shared\_Notification.cshtml"
              Write(TempData["InfoMessage"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\",\r\n            icon: \"info\",\r\n            button: \"باشه\"\r\n        });\r\n    </script>\r\n");
#nullable restore
#line 35 "F:\ASP.NET CORE\WeBloge\WeBloge.Web\Views\Shared\_Notification.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 37 "F:\ASP.NET CORE\WeBloge\WeBloge.Web\Views\Shared\_Notification.cshtml"
 if (TempData["ErrorMessage"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <script>\r\n        swal({\r\n            title: \"خطا\",\r\n            text: \"");
#nullable restore
#line 42 "F:\ASP.NET CORE\WeBloge\WeBloge.Web\Views\Shared\_Notification.cshtml"
              Write(TempData["ErrorMessage"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\",\r\n            icon: \"error\",\r\n            button: \"باشه\"\r\n        });\r\n    </script>\r\n");
#nullable restore
#line 47 "F:\ASP.NET CORE\WeBloge\WeBloge.Web\Views\Shared\_Notification.cshtml"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591