#pragma checksum "F:\asp.net\Razor\Razor\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5cb445f227ded5bbe5e77ae07fa1d62f3399a2b8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 1 "F:\asp.net\Razor\Razor\Views\_ViewImports.cshtml"
using Razor.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5cb445f227ded5bbe5e77ae07fa1d62f3399a2b8", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"80a4874ecc1e8beb5fd6e6f38818dc1efaf4f829", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Product[]>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(18, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "F:\asp.net\Razor\Razor\Views\Home\Index.cshtml"
   
    ViewBag.Title = "Product Name";

#line default
#line hidden
            BeginContext(65, 99, true);
            WriteLiteral("\r\n    <table>\r\n        <tr>\r\n            <th>Name</th>\r\n            <th>Price</th>\r\n        </tr>\r\n");
            EndContext();
#line 12 "F:\asp.net\Razor\Razor\Views\Home\Index.cshtml"
         foreach (Product product in Model)
        {

#line default
#line hidden
            BeginContext(220, 38, true);
            WriteLiteral("            <tr>\r\n                <td>");
            EndContext();
            BeginContext(259, 12, false);
#line 15 "F:\asp.net\Razor\Razor\Views\Home\Index.cshtml"
               Write(product.Name);

#line default
#line hidden
            EndContext();
            BeginContext(271, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(300, 21, false);
#line 16 "F:\asp.net\Razor\Razor\Views\Home\Index.cshtml"
                Write($"{product.Price:c2}");

#line default
#line hidden
            EndContext();
            BeginContext(322, 26, true);
            WriteLiteral("</td>\r\n            </tr>\r\n");
            EndContext();
#line 18 "F:\asp.net\Razor\Razor\Views\Home\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(359, 12, true);
            WriteLiteral("    </table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Product[]> Html { get; private set; }
    }
}
#pragma warning restore 1591
