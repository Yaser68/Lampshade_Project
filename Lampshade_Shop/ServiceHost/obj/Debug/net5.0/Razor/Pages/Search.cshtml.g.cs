#pragma checksum "D:\atom\Lampshade\Code\Lampshade_Shop\ServiceHost\Pages\Search.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "56180f4dba0b3c73c622287347b2acb9df06fb23"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ServiceHost.Pages.Pages_Search), @"mvc.1.0.razor-page", @"/Pages/Search.cshtml")]
namespace ServiceHost.Pages
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
#line 1 "D:\atom\Lampshade\Code\Lampshade_Shop\ServiceHost\Pages\_ViewImports.cshtml"
using ServiceHost;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"56180f4dba0b3c73c622287347b2acb9df06fb23", @"/Pages/Search.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"49bdd27e8b016acb3c031a38b8da4d14315ca499", @"/Pages/_ViewImports.cshtml")]
    #nullable restore
    public class Pages_Search : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/ProductDetails", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div class=""breadcrumb-area section-space--half"">
    <div class=""container wide"">
        <div class=""row"">
            <div class=""col-lg-12"">
                <!--=======  breadcrumb wrpapper  =======-->
                <div class=""breadcrumb-wrapper breadcrumb-bg"">
                    <!--=======  breadcrumb content  =======-->
                    <div class=""breadcrumb-content"">
                        <h2 class=""breadcrumb-content__title"">جستجو برای : ");
#nullable restore
#line 14 "D:\atom\Lampshade\Code\Lampshade_Shop\ServiceHost\Pages\Search.cshtml"
                                                                      Write(Model.Value);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h2>
                       
                    </div>
                    <!--=======  End of breadcrumb content  =======-->
                </div>
                <!--=======  End of breadcrumb wrpapper  =======-->
            </div>
        </div>
    </div>
</div>
<!--====================  End of breadcrumb area  ====================-->
<div class=""page-content-area"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg-12"">
                <!--=======  shop page wrapper  =======-->
                <div class=""page-wrapper"">
                    <div class=""page-content-wrapper"">
                        <div class=""row"">
                            <div class=""col-lg-12"">
                                <!--=======  shop page header  =======-->
                                <div class=""shop-header"">
                                    <div class=""shop-header__left"">
                                       
                                    </div>");
            WriteLiteral(@"

                                    
                                </div>
                                <!--=======  End of shop page header  =======-->
                            </div>

                            <div class=""col-lg-12"">
                                <!--=======  shop page content  =======-->
                                <div class=""shop-page-content"">

                                    <div class=""row shop-product-wrap grid three-column"">

");
#nullable restore
#line 51 "D:\atom\Lampshade\Code\Lampshade_Shop\ServiceHost\Pages\Search.cshtml"
                                         foreach(var product in Model.products)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                            <div class=""col-12 col-lg-4 col-md-4 col-sm-6"">
                                                <!--=======  product grid view  =======-->
                                            <div class=""single-grid-product grid-view-product"">
                                                    <div class=""single-grid-product__image"">
                                                        <div class=""single-grid-product__label"">
");
#nullable restore
#line 58 "D:\atom\Lampshade\Code\Lampshade_Shop\ServiceHost\Pages\Search.cshtml"
                                                             if (product.DiscountFlag)
                                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                               <span class=\"sale\">");
#nullable restore
#line 60 "D:\atom\Lampshade\Code\Lampshade_Shop\ServiceHost\Pages\Search.cshtml"
                                                                             Write(product.DiscountRate);

#line default
#line hidden
#nullable disable
            WriteLiteral("%-</span>\r\n                                                               <span class=\"new\">تخفیف</span> \r\n");
#nullable restore
#line 62 "D:\atom\Lampshade\Code\Lampshade_Shop\ServiceHost\Pages\Search.cshtml"
                                                            }      

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    </div>\r\n                                                    <a href=\"single-product.html\">\r\n                                                        <img");
            BeginWriteAttribute("src", " src=\"", 3282, "\"", 3304, 1);
#nullable restore
#line 65 "D:\atom\Lampshade\Code\Lampshade_Shop\ServiceHost\Pages\Search.cshtml"
WriteAttributeValue("", 3288, product.Picture, 3288, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"img-fluid\"");
            BeginWriteAttribute("alt", "\r\n                                                            alt=\"", 3323, "\"", 3409, 1);
#nullable restore
#line 66 "D:\atom\Lampshade\Code\Lampshade_Shop\ServiceHost\Pages\Search.cshtml"
WriteAttributeValue("", 3390, product.PictureAlt, 3390, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("title", " title=\"", 3410, "\"", 3439, 1);
#nullable restore
#line 66 "D:\atom\Lampshade\Code\Lampshade_Shop\ServiceHost\Pages\Search.cshtml"
WriteAttributeValue("", 3418, product.PictureTitle, 3418, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@"> 
                                                    </a>

                                                    <div class=""hover-icons"">
                                                        <a href=""javascript:void(0)"">
                                                            <i class=""ion-bag""></i>
                                                        </a>
                                                        <a href=""javascript:void(0)"" data-toggle=""modal""
                                                            data-target=""#quick-view-modal-container"">
                                                            <i class=""ion-android-open""></i>
                                                        </a>
                                                    </div>
                                                </div>
                                                <div class=""single-grid-product__content"">
                                                    <div class=""single-gr");
            WriteLiteral(@"id-product__category-rating"">
                                                        <span class=""category"">
                                                            <a href=""shop-left-sidebar.html"">Decor</a>
                                                        </span>
                                                        <span class=""rating"">
                                                            <i class=""ion-android-star active""></i>
                                                            <i class=""ion-android-star active""></i>
                                                            <i class=""ion-android-star active""></i>
                                                            <i class=""ion-android-star active""></i>
                                                            <i class=""ion-android-star-outline""></i>
                                                        </span>
                                                    </div>

                               ");
            WriteLiteral("                     <h3 class=\"single-grid-product__title\">\r\n                                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "56180f4dba0b3c73c622287347b2acb9df06fb2311008", async() => {
#nullable restore
#line 94 "D:\atom\Lampshade\Code\Lampshade_Shop\ServiceHost\Pages\Search.cshtml"
                                                                                 Write(product.Name);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                    </h3>\r\n                                                    <p class=\"single-grid-product__price\">\r\n\r\n");
#nullable restore
#line 98 "D:\atom\Lampshade\Code\Lampshade_Shop\ServiceHost\Pages\Search.cshtml"
                                                             if (product.DiscountFlag)
                                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                              <span class=\"discounted-price\">");
#nullable restore
#line 100 "D:\atom\Lampshade\Code\Lampshade_Shop\ServiceHost\Pages\Search.cshtml"
                                                                                        Write(product.UnitPriceWithDiscount);

#line default
#line hidden
#nullable disable
            WriteLiteral(" تومان</span> <span\r\n                                                            class=\"main-price discounted\">");
#nullable restore
#line 101 "D:\atom\Lampshade\Code\Lampshade_Shop\ServiceHost\Pages\Search.cshtml"
                                                                                     Write(product.UnitPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral(" تومان</span>\r\n");
#nullable restore
#line 102 "D:\atom\Lampshade\Code\Lampshade_Shop\ServiceHost\Pages\Search.cshtml"
                                                            }

                                                            else
                                                            { 

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                               <span class=\"main-price \">");
#nullable restore
#line 106 "D:\atom\Lampshade\Code\Lampshade_Shop\ServiceHost\Pages\Search.cshtml"
                                                                                    Write(product.UnitPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral(" تومان</span>     \r\n");
#nullable restore
#line 107 "D:\atom\Lampshade\Code\Lampshade_Shop\ServiceHost\Pages\Search.cshtml"
                                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                        \r\n                                                    </p>\r\n                                                    \r\n");
#nullable restore
#line 112 "D:\atom\Lampshade\Code\Lampshade_Shop\ServiceHost\Pages\Search.cshtml"
                                                         if (product.DiscountFlag)
                                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                              <div class=\"product-countdown\" data-countdown=\"");
#nullable restore
#line 114 "D:\atom\Lampshade\Code\Lampshade_Shop\ServiceHost\Pages\Search.cshtml"
                                                                                                        Write(product.DiscountExpire);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"></div>\r\n");
#nullable restore
#line 115 "D:\atom\Lampshade\Code\Lampshade_Shop\ServiceHost\Pages\Search.cshtml"
                                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                                      
                                                </div>
                                            </div>
                                            <!--=======  End of product grid view  =======-->
                                        </div> 
");
#nullable restore
#line 121 "D:\atom\Lampshade\Code\Lampshade_Shop\ServiceHost\Pages\Search.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                        
                                       

                                    </div>

                                </div>

                                <!--=======  pagination area =======-->
                                <div class=""pagination-area"">
                                    
                                    <div class=""pagination-area__right"">
                                        <ul class=""pagination-section"">
                                            <li>
                                                <a class=""active"" href=""#"">1</a>
                                            </li>
                                            <li>
                                                <a href=""#"">2</a>
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                                <!--=======  End");
            WriteLiteral(@" of pagination area  =======-->
                                <!--=======  End of shop page content  =======-->
                            </div>
                        </div>
                    </div>
                </div>
                <!--=======  End of shop page wrapper  =======-->
            </div>
        </div>
    </div>
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ServiceHost.Pages.SearchModel> Html { get; private set; } = default!;
        #nullable disable
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ServiceHost.Pages.SearchModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ServiceHost.Pages.SearchModel>)PageContext?.ViewData;
        public ServiceHost.Pages.SearchModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
