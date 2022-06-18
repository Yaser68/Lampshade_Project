using _01_LampshadeQuery.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class ProductCategoryViewComponent : ViewComponent
    {

        private readonly IProductCategoryQuery _productCategories;

        public ProductCategoryViewComponent(IProductCategoryQuery productCategories)
        {
            _productCategories = productCategories;
        }

        public IViewComponentResult Invoke()
        {

            var productCategories=_productCategories.GetProductCategories();

            return View(productCategories);
        }

    }
}
