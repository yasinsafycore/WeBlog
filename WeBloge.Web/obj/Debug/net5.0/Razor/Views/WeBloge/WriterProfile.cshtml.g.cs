#pragma checksum "F:\ASP.NET CORE\WeBloge\WeBloge.Web\Views\WeBloge\WriterProfile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "42a7c5660899a97bef94b876832cc20c9777fec8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_WeBloge_WriterProfile), @"mvc.1.0.view", @"/Views/WeBloge/WriterProfile.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"42a7c5660899a97bef94b876832cc20c9777fec8", @"/Views/WeBloge/WriterProfile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8264d026be87a64d5e4e6226594d03b3d616122d", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_WeBloge_WriterProfile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WeBloge.Domain.Entities.Admin.Writer>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "F:\ASP.NET CORE\WeBloge\WeBloge.Web\Views\WeBloge\WriterProfile.cshtml"
  
    ViewData["Title"] = "نویسنده";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!--author-->\r\n<section class=\"section author full-space mb-40 pt-55\">\r\n    <div class=\"container-fluid\">\r\n        <div class=\"row\">\r\n            <div class=\"col-lg-12\">\r\n                \r\n                    ");
#nullable restore
#line 14 "F:\ASP.NET CORE\WeBloge\WeBloge.Web\Views\WeBloge\WriterProfile.cshtml"
               Write(await Component.InvokeAsync("WriterProfile"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                \r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WeBloge.Domain.Entities.Admin.Writer> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
