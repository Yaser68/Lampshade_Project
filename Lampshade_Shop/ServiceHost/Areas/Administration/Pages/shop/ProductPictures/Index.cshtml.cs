using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contract;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Application.Contract.ProductPicture;
using System.Collections.Generic;

namespace ServiceHost.Areas.Administration.Pages.shop.ProductPictures
{
    public class IndexModel : PageModel
    {

        public ProductPictureSearchModel SearchModel;

        public List<ProductPictureViewModel> productPictures;

        public SelectList Products;

        private readonly IProductApplication _productApplication;
        private readonly IProductPictureApplication _productPictureApplication;

        public IndexModel(IProductApplication productApplication, IProductPictureApplication productPictureApplication)
        {
            _productApplication = productApplication;
         
            _productPictureApplication = productPictureApplication;
        }

        public void OnGet(ProductPictureSearchModel searchModel)
        {

            productPictures = _productPictureApplication.Search(searchModel);
            Products = new SelectList(_productApplication.GetProducts(), "Id", "Name");
        }

        public IActionResult OnGetCreate()
        {
            var command = new CreateProductPicture {

                Products = _productApplication.GetProducts()
        };

            return Partial("./Create", command);
        }


        public JsonResult OnPostCreate(CreateProductPicture command)
        {
            var result = _productPictureApplication.Creat(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var productPicture=_productPictureApplication.GetDetails(id);

            productPicture.Products = _productApplication.GetProducts();

            return Partial("Edit", productPicture);
        }

        public JsonResult OnPostEdit(EditProductPicture command)
        {
            var result = _productPictureApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetRemove(long id)
        {
            var result= _productPictureApplication.Remove(id);
            return RedirectToPage("./Index");
        }

        public IActionResult OnGetRestore(long id)
        {
            var result = _productPictureApplication.Restore(id);
            return RedirectToPage("./Index");
        }

    }
}
