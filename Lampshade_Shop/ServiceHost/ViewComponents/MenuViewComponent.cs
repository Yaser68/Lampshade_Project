using _01_LampshadeQuery.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ServiceHost.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        public List<ProductCategoryQueryModel> category;
        private IProductCategoryQuery _productCategoryQuery;

        public MenuViewComponent(IProductCategoryQuery productCategoryQuery)
        {
            _productCategoryQuery = productCategoryQuery;
        }

        public IViewComponentResult Invoke()
        {
            category=_productCategoryQuery.GetProductCategories();

            return View(category);
        }
    }
}
