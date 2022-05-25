using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contract;
using ShopManagement.Application.Contract.Product;
using System.Collections.Generic;

namespace ServiceHost.Areas.Administration.Pages.shop.Products
{
    public class IndexModel : PageModel
    {

        public ProductSearchModel SearchModel;

        public List<ProductViewModel> products;

        public SelectList productCategories;

        private readonly IProductApplication _productApplication;
        private readonly IProductCategoryApplication _productCategoryApplication;

        public IndexModel(IProductApplication productApplication, IProductCategoryApplication productCategoryApplication)
        {
            _productApplication = productApplication;
            _productCategoryApplication = productCategoryApplication;
        }

        public void OnGet(ProductSearchModel searchModel)
        {

            products = _productApplication.Search(searchModel);
            productCategories = new SelectList(_productCategoryApplication.GetProductCategories(), "Id", "Name");
        }

        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateProduct());
        }


        public JsonResult OnPostCreate(CreateProduct command)
        {
            var result = _productApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var productCategory=_productApplication.GetDetails(id);
            return Partial("Edit", productCategory);
        }

        public JsonResult OnPostEdit(EditProduct command)
        {
            var result=_productApplication.Edit(command);
            return new JsonResult(result);
        }
       
    }
}
