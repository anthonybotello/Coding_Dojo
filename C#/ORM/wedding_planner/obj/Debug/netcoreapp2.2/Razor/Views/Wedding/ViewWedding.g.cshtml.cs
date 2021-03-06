#pragma checksum "C:\Users\Anthony\Desktop\c#\ORM\wedding_planner\Views\Wedding\ViewWedding.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "42e03c4a355a46e488f54c08f287ebd74be4f5d5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Wedding_ViewWedding), @"mvc.1.0.view", @"/Views/Wedding/ViewWedding.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Wedding/ViewWedding.cshtml", typeof(AspNetCore.Views_Wedding_ViewWedding))]
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
#line 1 "C:\Users\Anthony\Desktop\c#\ORM\wedding_planner\Views\_ViewImports.cshtml"
using wedding_planner;

#line default
#line hidden
#line 2 "C:\Users\Anthony\Desktop\c#\ORM\wedding_planner\Views\_ViewImports.cshtml"
using wedding_planner.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"42e03c4a355a46e488f54c08f287ebd74be4f5d5", @"/Views/Wedding/ViewWedding.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e0aadd694686a14c367f0150bd67bec2e71f0b6a", @"/Views/_ViewImports.cshtml")]
    public class Views_Wedding_ViewWedding : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Wedding>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\Users\Anthony\Desktop\c#\ORM\wedding_planner\Views\Wedding\ViewWedding.cshtml"
    ViewData["Title"] = Model.WedderOne + " & " + Model.WedderTwo;
    string Location = Model.WeddingAddress.StreetAddress.Replace(" ","+") + "+" + Model.WeddingAddress.City + "+" + Model.WeddingAddress.State;

#line default
#line hidden
            BeginContext(240, 72, true);
            WriteLiteral("\r\n<div class=\"row justify-content-between\">\r\n    <div class=\"col-8\"><h2>");
            EndContext();
            BeginContext(313, 15, false);
#line 8 "C:\Users\Anthony\Desktop\c#\ORM\wedding_planner\Views\Wedding\ViewWedding.cshtml"
                      Write(Model.WedderOne);

#line default
#line hidden
            EndContext();
            BeginContext(328, 3, true);
            WriteLiteral(" & ");
            EndContext();
            BeginContext(332, 15, false);
#line 8 "C:\Users\Anthony\Desktop\c#\ORM\wedding_planner\Views\Wedding\ViewWedding.cshtml"
                                         Write(Model.WedderTwo);

#line default
#line hidden
            EndContext();
            BeginContext(347, 295, true);
            WriteLiteral(@"'s Wedding</h2></div>
    <div class=""col-2 text-right align-self-end"">
        <a href=""/dashboard"" class=""btn-sm btn-primary"">Dashboard</a>
        <a href=""/logout"" class=""btn-sm btn-secondary"">Log Out</a>
    </div>
</div>

<div class=""row"">
    <div class=""col"">
        <h4>Date: ");
            EndContext();
            BeginContext(644, 47, false);
#line 17 "C:\Users\Anthony\Desktop\c#\ORM\wedding_planner\Views\Wedding\ViewWedding.cshtml"
              Write(((DateTime)Model.Date).ToString("MMMM d, yyyy"));

#line default
#line hidden
            EndContext();
            BeginContext(692, 147, true);
            WriteLiteral("</h4>\r\n    </div>\r\n</div>\r\n\r\n<div class=\"row mt-3\">\r\n    <h5 class=\"col\">Guests:</h5>\r\n</div>\r\n<div class=\"row\">\r\n    <ul class=\"col list-group\">\r\n");
            EndContext();
#line 26 "C:\Users\Anthony\Desktop\c#\ORM\wedding_planner\Views\Wedding\ViewWedding.cshtml"
         foreach(RSVP guest in Model.Guests)
        {

#line default
#line hidden
            BeginContext(896, 64, true);
            WriteLiteral("            <li class=\"list-group-item border-0 bg-transparent\">");
            EndContext();
            BeginContext(961, 20, false);
#line 28 "C:\Users\Anthony\Desktop\c#\ORM\wedding_planner\Views\Wedding\ViewWedding.cshtml"
                                                           Write(guest.User.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(981, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(983, 19, false);
#line 28 "C:\Users\Anthony\Desktop\c#\ORM\wedding_planner\Views\Wedding\ViewWedding.cshtml"
                                                                                 Write(guest.User.LastName);

#line default
#line hidden
            EndContext();
            BeginContext(1002, 7, true);
            WriteLiteral("</li>\r\n");
            EndContext();
#line 29 "C:\Users\Anthony\Desktop\c#\ORM\wedding_planner\Views\Wedding\ViewWedding.cshtml"
        }

#line default
#line hidden
            BeginContext(1020, 116, true);
            WriteLiteral("    </ul>\r\n    <div class=\"col\">\r\n        <iframe\r\n  width=\"300\"\r\n  height=\"250\"\r\n  frameborder=\"0\" style=\"border:0\"");
            EndContext();
            BeginWriteAttribute("src", "\r\n  src=\"", 1136, "\"", 1249, 3);
            WriteAttributeValue("", 1145, "https://www.google.com/maps/embed/v1/place?key=AIzaSyCdUks3JrPpvZburpVOnTG4fFklz2szjcA", 1145, 86, true);
            WriteAttributeValue("\r\n    ", 1231, "&q=", 1237, 9, true);
#line 37 "C:\Users\Anthony\Desktop\c#\ORM\wedding_planner\Views\Wedding\ViewWedding.cshtml"
WriteAttributeValue("", 1240, Location, 1240, 9, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1250, 58, true);
            WriteLiteral(" allowfullscreen>\r\n</iframe>\r\n        \r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Wedding> Html { get; private set; }
    }
}
#pragma warning restore 1591
