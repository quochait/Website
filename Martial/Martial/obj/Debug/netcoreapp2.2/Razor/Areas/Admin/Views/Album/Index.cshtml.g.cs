#pragma checksum "G:\asp.net\Martial\Martial\Areas\Admin\Views\Album\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "19264a217d5e18704d844d76308106f87644ace5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Album_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Album/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Album/Index.cshtml", typeof(AspNetCore.Areas_Admin_Views_Album_Index))]
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
#line 1 "G:\asp.net\Martial\Martial\Areas\Admin\Views\_ViewImports.cshtml"
using Martial;

#line default
#line hidden
#line 2 "G:\asp.net\Martial\Martial\Areas\Admin\Views\_ViewImports.cshtml"
using Martial.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"19264a217d5e18704d844d76308106f87644ace5", @"/Areas/Admin/Views/Album/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"657fdfec0ec1cd254b9b52dd92b598132662ce70", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Album_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Martial.Models.Albums>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Album", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info text-light"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_TableButtonPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(45, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "G:\asp.net\Martial\Martial\Areas\Admin\Views\Album\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(135, 155, true);
            WriteLiteral("\r\n<div class=\"row mb-3\">\r\n    <div class=\"col-6\">\r\n        <h2 class=\"text-info\">Albums List</h2>\r\n    </div>\r\n    <div class=\"text-right col-6\">\r\n        ");
            EndContext();
            BeginContext(290, 148, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "19264a217d5e18704d844d76308106f87644ace55511", async() => {
                BeginContext(385, 49, true);
                WriteLiteral("&nbsp;<i class=\"fas fa-plus\"></i> New Album&nbsp;");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(438, 26, true);
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n\r\n");
            EndContext();
#line 19 "G:\asp.net\Martial\Martial\Areas\Admin\Views\Album\Index.cshtml"
 if (Model.Count() > 0)
{

#line default
#line hidden
            BeginContext(492, 109, true);
            WriteLiteral("    <table class=\"table table-striped border\">\r\n        <tr class=\"table-info text-center\">\r\n            <th>");
            EndContext();
            BeginContext(602, 32, false);
#line 23 "G:\asp.net\Martial\Martial\Areas\Admin\Views\Album\Index.cshtml"
           Write(Html.DisplayNameFor(m => m.Name));

#line default
#line hidden
            EndContext();
            BeginContext(634, 23, true);
            WriteLiteral("</th>\r\n            <th>");
            EndContext();
            BeginContext(658, 40, false);
#line 24 "G:\asp.net\Martial\Martial\Areas\Admin\Views\Album\Index.cshtml"
           Write(Html.DisplayNameFor(m => m.Descriptions));

#line default
#line hidden
            EndContext();
            BeginContext(698, 23, true);
            WriteLiteral("</th>\r\n            <th>");
            EndContext();
            BeginContext(722, 39, false);
#line 25 "G:\asp.net\Martial\Martial\Areas\Admin\Views\Album\Index.cshtml"
           Write(Html.DisplayNameFor(m => m.CreatedDate));

#line default
#line hidden
            EndContext();
            BeginContext(761, 78, true);
            WriteLiteral("</th>\r\n            <th>Images</th>\r\n            <th></th>\r\n        </tr>\r\n\r\n\r\n");
            EndContext();
#line 31 "G:\asp.net\Martial\Martial\Areas\Admin\Views\Album\Index.cshtml"
         foreach (var album in Model)
        {

#line default
#line hidden
            BeginContext(889, 104, true);
            WriteLiteral("            <tr>\r\n\r\n                <td class=\"align-middle text-center\"><strong class=\"text-uppercase\">");
            EndContext();
            BeginContext(994, 10, false);
#line 35 "G:\asp.net\Martial\Martial\Areas\Admin\Views\Album\Index.cshtml"
                                                                               Write(album.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1004, 85, true);
            WriteLiteral("</strong></td>\r\n                <td class=\"align-middle\" style=\"max-width: 650px;\">\r\n");
            EndContext();
#line 37 "G:\asp.net\Martial\Martial\Areas\Admin\Views\Album\Index.cshtml"
                     if (album.Descriptions != null && album.Descriptions.Length > 100)
                    {

#line default
#line hidden
            BeginContext(1201, 30, true);
            WriteLiteral("                        <span>");
            EndContext();
            BeginContext(1232, 36, false);
#line 39 "G:\asp.net\Martial\Martial\Areas\Admin\Views\Album\Index.cshtml"
                         Write(album.Descriptions.Substring(0, 100));

#line default
#line hidden
            EndContext();
            BeginContext(1268, 12, true);
            WriteLiteral("...</span>\r\n");
            EndContext();
#line 40 "G:\asp.net\Martial\Martial\Areas\Admin\Views\Album\Index.cshtml"
                    }
                    else
                    {
                        

#line default
#line hidden
            BeginContext(1377, 18, false);
#line 43 "G:\asp.net\Martial\Martial\Areas\Admin\Views\Album\Index.cshtml"
                   Write(album.Descriptions);

#line default
#line hidden
            EndContext();
#line 43 "G:\asp.net\Martial\Martial\Areas\Admin\Views\Album\Index.cshtml"
                                           
                    }

#line default
#line hidden
            BeginContext(1420, 23, true);
            WriteLiteral("                </td>\r\n");
            EndContext();
            BeginContext(1522, 41, true);
            WriteLiteral("                <td class=\"align-middle\">");
            EndContext();
            BeginContext(1564, 48, false);
#line 47 "G:\asp.net\Martial\Martial\Areas\Admin\Views\Album\Index.cshtml"
                                    Write(album.CreatedDate.ToString("dddd, dd MMMM yyyy"));

#line default
#line hidden
            EndContext();
            BeginContext(1612, 62, true);
            WriteLiteral("</td>\r\n                <td class=\"align-middle text-center\">\r\n");
            EndContext();
#line 49 "G:\asp.net\Martial\Martial\Areas\Admin\Views\Album\Index.cshtml"
                     if (album.Pictures.Count() > 0)
                    {

#line default
#line hidden
            BeginContext(1751, 38, true);
            WriteLiteral("                        <span><strong>");
            EndContext();
            BeginContext(1790, 22, false);
#line 51 "G:\asp.net\Martial\Martial\Areas\Admin\Views\Album\Index.cshtml"
                                 Write(album.Pictures.Count());

#line default
#line hidden
            EndContext();
            BeginContext(1812, 25, true);
            WriteLiteral("</strong> images</span>\r\n");
            EndContext();
#line 52 "G:\asp.net\Martial\Martial\Areas\Admin\Views\Album\Index.cshtml"
                    }
                    else
                    {

#line default
#line hidden
            BeginContext(1909, 50, true);
            WriteLiteral("                        <i>Don\'t have images</i>\r\n");
            EndContext();
#line 56 "G:\asp.net\Martial\Martial\Areas\Admin\Views\Album\Index.cshtml"
                    }

#line default
#line hidden
            BeginContext(1982, 86, true);
            WriteLiteral("                </td>\r\n                <td class=\"align-middle\">\r\n                    ");
            EndContext();
            BeginContext(2068, 56, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "19264a217d5e18704d844d76308106f87644ace513167", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
#line 59 "G:\asp.net\Martial\Martial\Areas\Admin\Views\Album\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = album.Id;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2124, 44, true);
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 62 "G:\asp.net\Martial\Martial\Areas\Admin\Views\Album\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(2179, 14, true);
            WriteLiteral("    </table>\r\n");
            EndContext();
#line 64 "G:\asp.net\Martial\Martial\Areas\Admin\Views\Album\Index.cshtml"
}
else
{

#line default
#line hidden
            BeginContext(2205, 72, true);
            WriteLiteral("    <div><h3 class=\"text-warning\"><i>Don\'t have albums.</i></h3></div>\r\n");
            EndContext();
#line 68 "G:\asp.net\Martial\Martial\Areas\Admin\Views\Album\Index.cshtml"
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Martial.Models.Albums>> Html { get; private set; }
    }
}
#pragma warning restore 1591
