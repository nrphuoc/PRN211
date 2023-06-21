#pragma checksum "C:\Users\Admin\Downloads\ShopFlower\ShopFlower\Areas\Admin\Views\Store\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "22cdd37e1590ff3d6da6e7060b0549d0bb2fa740"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Store_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Store/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"22cdd37e1590ff3d6da6e7060b0549d0bb2fa740", @"/Areas/Admin/Views/Store/Index.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_Store_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Admin\Downloads\ShopFlower\ShopFlower\Areas\Admin\Views\Store\Index.cshtml"
   
    ViewBag.Title = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";


#line default
#line hidden
#nullable disable
            WriteLiteral(@"<h1>Store Manage</h1>

<p>
    <a href=""/admin/store/create"">Create New</a>
</p>
<table class=""table"">
    <thead>
        <tr>
            <th>
                StoreId
            </th>
            <th>
                Storename
            </th>
            <th>
                Phone
            </th>
            <th>
                Email
            </th>
            <th>
                Address
            </th>
            <th></th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 33 "C:\Users\Admin\Downloads\ShopFlower\ShopFlower\Areas\Admin\Views\Store\Index.cshtml"
         foreach (var store in ViewBag.listStore)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 36 "C:\Users\Admin\Downloads\ShopFlower\ShopFlower\Areas\Admin\Views\Store\Index.cshtml"
               Write(store.StoreId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 37 "C:\Users\Admin\Downloads\ShopFlower\ShopFlower\Areas\Admin\Views\Store\Index.cshtml"
               Write(store.Storename);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 38 "C:\Users\Admin\Downloads\ShopFlower\ShopFlower\Areas\Admin\Views\Store\Index.cshtml"
               Write(store.Phone);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 39 "C:\Users\Admin\Downloads\ShopFlower\ShopFlower\Areas\Admin\Views\Store\Index.cshtml"
               Write(store.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 40 "C:\Users\Admin\Downloads\ShopFlower\ShopFlower\Areas\Admin\Views\Store\Index.cshtml"
               Write(store.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td><a");
            BeginWriteAttribute("href", " href=\"", 901, "\"", 943, 2);
            WriteAttributeValue("", 908, "/admin/store/edit?id=", 908, 21, true);
#nullable restore
#line 41 "C:\Users\Admin\Downloads\ShopFlower\ShopFlower\Areas\Admin\Views\Store\Index.cshtml"
WriteAttributeValue("", 929, store.StoreId, 929, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Edit</a> | <a");
            BeginWriteAttribute("href", " href=\"", 958, "\"", 1002, 2);
            WriteAttributeValue("", 965, "/admin/store/delete?id=", 965, 23, true);
#nullable restore
#line 41 "C:\Users\Admin\Downloads\ShopFlower\ShopFlower\Areas\Admin\Views\Store\Index.cshtml"
WriteAttributeValue("", 988, store.StoreId, 988, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Delete</a></td>\r\n            </tr>\r\n");
#nullable restore
#line 43 "C:\Users\Admin\Downloads\ShopFlower\ShopFlower\Areas\Admin\Views\Store\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n<nav>\r\n");
#nullable restore
#line 47 "C:\Users\Admin\Downloads\ShopFlower\ShopFlower\Areas\Admin\Views\Store\Index.cshtml"
      
        var pre = ViewBag.page - 1;
        var next = ViewBag.page + 1;

    

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 53 "C:\Users\Admin\Downloads\ShopFlower\ShopFlower\Areas\Admin\Views\Store\Index.cshtml"
     if (ViewBag.numberPage > 1)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <ul class=\"pagination pagination-rounded mb-0\">\r\n            <li class=\"page-item\">\r\n                <a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 1346, "\"", 1381, 2);
            WriteAttributeValue("", 1353, "/admin/store/index?page=", 1353, 24, true);
#nullable restore
#line 57 "C:\Users\Admin\Downloads\ShopFlower\ShopFlower\Areas\Admin\Views\Store\Index.cshtml"
WriteAttributeValue("", 1377, pre, 1377, 4, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" aria-label=\"Previous\">\r\n                    <span aria-hidden=\"true\">&laquo;</span>\r\n                    <span class=\"sr-only\">Previous</span>\r\n                </a>\r\n            </li>\r\n");
#nullable restore
#line 62 "C:\Users\Admin\Downloads\ShopFlower\ShopFlower\Areas\Admin\Views\Store\Index.cshtml"
             for (var i = 1; i < ViewBag.numberPage; i++)
            {
                if (i == ViewBag.page)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li class=\"page-item active\"><a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 1770, "\"", 1803, 2);
            WriteAttributeValue("", 1777, "/admin/store/index?page=", 1777, 24, true);
#nullable restore
#line 66 "C:\Users\Admin\Downloads\ShopFlower\ShopFlower\Areas\Admin\Views\Store\Index.cshtml"
WriteAttributeValue("", 1801, i, 1801, 2, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 66 "C:\Users\Admin\Downloads\ShopFlower\ShopFlower\Areas\Admin\Views\Store\Index.cshtml"
                                                                                                   Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 67 "C:\Users\Admin\Downloads\ShopFlower\ShopFlower\Areas\Admin\Views\Store\Index.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li class=\"page-item\"><a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 1940, "\"", 1973, 2);
            WriteAttributeValue("", 1947, "/admin/store/index?page=", 1947, 24, true);
#nullable restore
#line 70 "C:\Users\Admin\Downloads\ShopFlower\ShopFlower\Areas\Admin\Views\Store\Index.cshtml"
WriteAttributeValue("", 1971, i, 1971, 2, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 70 "C:\Users\Admin\Downloads\ShopFlower\ShopFlower\Areas\Admin\Views\Store\Index.cshtml"
                                                                                            Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 71 "C:\Users\Admin\Downloads\ShopFlower\ShopFlower\Areas\Admin\Views\Store\Index.cshtml"
                }

            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li class=\"page-item\">\r\n                <a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 2096, "\"", 2132, 2);
            WriteAttributeValue("", 2103, "/admin/store/index?page=", 2103, 24, true);
#nullable restore
#line 75 "C:\Users\Admin\Downloads\ShopFlower\ShopFlower\Areas\Admin\Views\Store\Index.cshtml"
WriteAttributeValue("", 2127, next, 2127, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" aria-label=\"Next\">\r\n                    <span aria-hidden=\"true\">&raquo;</span>\r\n                    <span class=\"sr-only\">Next</span>\r\n                </a>\r\n            </li>\r\n        </ul>\r\n");
#nullable restore
#line 81 "C:\Users\Admin\Downloads\ShopFlower\ShopFlower\Areas\Admin\Views\Store\Index.cshtml"


    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</nav>\r\n");
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
