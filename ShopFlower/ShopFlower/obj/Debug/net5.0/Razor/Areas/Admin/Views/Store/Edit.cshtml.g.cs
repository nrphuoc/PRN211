#pragma checksum "C:\Users\Admin\Downloads\ShopFlower\ShopFlower\Areas\Admin\Views\Store\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "14be02b3c7e2c3d64918a831f7270ff67818e213"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Store_Edit), @"mvc.1.0.view", @"/Areas/Admin/Views/Store/Edit.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"14be02b3c7e2c3d64918a831f7270ff67818e213", @"/Areas/Admin/Views/Store/Edit.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_Store_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ShopFlower.Models.Store>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Admin\Downloads\ShopFlower\ShopFlower\Areas\Admin\Views\Store\Edit.cshtml"
  
    ViewData["Title"] = "Store Manage";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>Edit</h1>

<h4>Store</h4>
<hr />
<div class=""row"">
    <div class=""col-md-4"">
        <form asp-action=""Edit"" method=""post"">
            <div asp-validation-summary=""ModelOnly"" class=""text-danger""></div>
            <input type=""hidden"" asp-for=""StoreId"" name=""id""");
            BeginWriteAttribute("value", " value=\"", 407, "\"", 437, 1);
#nullable restore
#line 16 "C:\Users\Admin\Downloads\ShopFlower\ShopFlower\Areas\Admin\Views\Store\Edit.cshtml"
WriteAttributeValue("", 415, ViewBag.store.StoreId, 415, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n            <div class=\"form-group\">\r\n                <label asp-for=\"Storename\" class=\"control-label\">Storename</label>\r\n                <input asp-for=\"Storename\" class=\"form-control\" name=\"name\"");
            BeginWriteAttribute("value", " value=\"", 640, "\"", 672, 1);
#nullable restore
#line 19 "C:\Users\Admin\Downloads\ShopFlower\ShopFlower\Areas\Admin\Views\Store\Edit.cshtml"
WriteAttributeValue("", 648, ViewBag.store.Storename, 648, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" />
                <span asp-validation-for=""Storename"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""Phone"" class=""control-label"">Phone</label>
                <input asp-for=""Phone"" class=""form-control"" name=""phone""");
            BeginWriteAttribute("value", " value=\"", 966, "\"", 994, 1);
#nullable restore
#line 24 "C:\Users\Admin\Downloads\ShopFlower\ShopFlower\Areas\Admin\Views\Store\Edit.cshtml"
WriteAttributeValue("", 974, ViewBag.store.Phone, 974, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@"/>
                <span asp-validation-for=""Phone"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""Email"" class=""control-label"">Email</label>
                <input asp-for=""Email"" class=""form-control"" name=""email""");
            BeginWriteAttribute("value", " value=\"", 1283, "\"", 1311, 1);
#nullable restore
#line 29 "C:\Users\Admin\Downloads\ShopFlower\ShopFlower\Areas\Admin\Views\Store\Edit.cshtml"
WriteAttributeValue("", 1291, ViewBag.store.Email, 1291, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" />
                <span asp-validation-for=""Email"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""Address"" class=""control-label"">Address</label>
                <input asp-for=""Address"" class=""form-control"" name=""address""");
            BeginWriteAttribute("value", " value=\"", 1609, "\"", 1639, 1);
#nullable restore
#line 34 "C:\Users\Admin\Downloads\ShopFlower\ShopFlower\Areas\Admin\Views\Store\Edit.cshtml"
WriteAttributeValue("", 1617, ViewBag.store.Address, 1617, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" />
                <span asp-validation-for=""Address"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <input type=""submit"" value=""Save"" class=""btn btn-primary"" />
            </div>
        </form>
    </div>
</div>

<div>
    <a href=""/admin/store/index"">Back to List</a>
</div>

");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 49 "C:\Users\Admin\Downloads\ShopFlower\ShopFlower\Areas\Admin\Views\Store\Edit.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ShopFlower.Models.Store> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
