using _01_LampshadeQuery.Contracts.Product;
using _01_LampshadeQuery.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class LastArrivalsViewComponent : ViewComponent
    {
        private readonly _01_LampshadeQuery.Contracts.Product.IProductQuery _productQuery;

        public LastArrivalsViewComponent(_01_LampshadeQuery.Contracts.Product.IProductQuery productQuery)
        {
            _productQuery = productQuery;
        }

        public IViewComponentResult Invoke()
        {
            var products = _productQuery.LastArrivals();
            return View(products);
        }
    }
}
