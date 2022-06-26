using _01_LampshadeQuery.Contracts.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using DiscountManagement.Infrastructure.EFCore;
using InventoryManagement.Infrastructure.EFCore;
using ShopManagement.Infrastructure.EFCore;

namespace _01_LampshadeQuery.Query
{
    public class ProductQuery : IProductQuery
    {
        private readonly ShopContext _shopContext;
        private readonly InventoryContext _inventoryContext;
        private readonly DiscountContext _discountContext;

        public ProductQuery(ShopContext shopContext, InventoryContext inventoryContext, DiscountContext discountContext)
        {
            _shopContext = shopContext;
            _inventoryContext = inventoryContext;
            _discountContext = discountContext;
        }

       
        public List<ProductQueryModel> LastArrivals()
        {
            var Products = _shopContext.products.Select(x => new ProductQueryModel
            {
              Id = x.Id,
              Name = x.Name,
              Picture=x.Picture,
              PictureAlt=x.PictureAlt,
              PictureTitle=x.PictureTitle,
              Slug=x.Slug,
              Category=x.Category.Name

            }).OrderByDescending(x => x.Id).Take(6).ToList();

            var discount = _discountContext.customerDiscounts.Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
            .Select(x => new { x.ProductId, x.DiscountRate }).ToList();

            var inventory = _inventoryContext.inventory.Select(x => new { x.ProductId, x.UnitPrice }).ToList();

            foreach (var product in Products)
            {
                var productInventory = inventory.FirstOrDefault(x => x.ProductId == product.Id);

                if (productInventory != null)
                {
                    var price = productInventory.UnitPrice;
                    product.UnitPrice = price.ToMoney();

                    var productDiscount = discount.FirstOrDefault(x => x.ProductId == product.Id);

                    if (productDiscount != null)
                    {
                        var discountRate = productDiscount.DiscountRate;
                        product.DiscountRate = discountRate.ToString();

                        product.DiscountFlag = discountRate > 0;

                        var discountPrice = Math.Round((price * discountRate) / 100);
                        product.UnitPriceWithDiscount = (price - discountPrice).ToMoney();
                    }
                }



            }


            return Products;
        }
    }
}
