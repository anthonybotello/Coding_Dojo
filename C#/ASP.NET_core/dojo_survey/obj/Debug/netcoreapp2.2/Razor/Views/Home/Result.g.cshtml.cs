#pragma checksum "C:\Users\Anthony\Desktop\c#\ASP.NET_core\dojo_survey\Views\Home\Result.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6a6d1b0e66b664731f3295eb3d375fa5c41a6d5a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Result), @"mvc.1.0.view", @"/Views/Home/Result.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Result.cshtml", typeof(AspNetCore.Views_Home_Result))]
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
#line 1 "C:\Users\Anthony\Desktop\c#\ASP.NET_core\dojo_survey\Views\_ViewImports.cshtml"
using dojo_survey;

#line default
#line hidden
#line 2 "C:\Users\Anthony\Desktop\c#\ASP.NET_core\dojo_survey\Views\_ViewImports.cshtml"
using dojo_survey.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6a6d1b0e66b664731f3295eb3d375fa5c41a6d5a", @"/Views/Home/Result.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f9de887fe8c066377cbfebcb2df4eeef5c348df0", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Result : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Survey>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\Anthony\Desktop\c#\ASP.NET_core\dojo_survey\Views\Home\Result.cshtml"
  
    ViewData["Title"] = "Dojo Survey Index";

#line default
#line hidden
            BeginContext(69, 116, true);
            WriteLiteral("\r\n<h2><u>Submitted Info</u></h2>\r\n<ul class=\"list-group\">\r\n    <li class=\"list-group-item border-0\">\r\n        Name: ");
            EndContext();
            BeginContext(186, 10, false);
#line 9 "C:\Users\Anthony\Desktop\c#\ASP.NET_core\dojo_survey\Views\Home\Result.cshtml"
         Write(Model.Name);

#line default
#line hidden
            EndContext();
            BeginContext(196, 79, true);
            WriteLiteral("\r\n    </li>\r\n    <li class=\"list-group-item border-0\">\r\n        Dojo Location: ");
            EndContext();
            BeginContext(276, 14, false);
#line 12 "C:\Users\Anthony\Desktop\c#\ASP.NET_core\dojo_survey\Views\Home\Result.cshtml"
                  Write(Model.Location);

#line default
#line hidden
            EndContext();
            BeginContext(290, 83, true);
            WriteLiteral("\r\n    </li>\r\n    <li class=\"list-group-item border-0\">\r\n        Favorite Language: ");
            EndContext();
            BeginContext(374, 14, false);
#line 15 "C:\Users\Anthony\Desktop\c#\ASP.NET_core\dojo_survey\Views\Home\Result.cshtml"
                      Write(Model.Language);

#line default
#line hidden
            EndContext();
            BeginContext(388, 73, true);
            WriteLiteral("\r\n    </li>\r\n    <li class=\"list-group-item border-0\">\r\n        Comment: ");
            EndContext();
            BeginContext(462, 13, false);
#line 18 "C:\Users\Anthony\Desktop\c#\ASP.NET_core\dojo_survey\Views\Home\Result.cshtml"
            Write(Model.Comment);

#line default
#line hidden
            EndContext();
            BeginContext(475, 20, true);
            WriteLiteral("\r\n    </li>\r\n</ul>\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Survey> Html { get; private set; }
    }
}
#pragma warning restore 1591
