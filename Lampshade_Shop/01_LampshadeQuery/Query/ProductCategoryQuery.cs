using _0_Framework.Application;
using _01_LampshadeQuery.Contracts.Product;
using _01_LampshadeQuery.Contracts.ProductCategory;
using DiscountManagement.Infrastructure.EFCore;
using InventoryManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Infrastructure.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_LampshadeQuery.Query
{
    public class ProductCategoryQuery : Contracts.ProductCategory.IProductCategoryQuery
    {
        private readonly ShopContext _shopContext;
        private readonly InventoryContext _inventoryContext;
        private readonly DiscountContext _discountContext;

        public ProductCategoryQuery(ShopContext shopContext, InventoryContext inventoryContext, DiscountContext discountContext)
        {
            _shopContext = shopContext;
            _inventoryContext = inventoryContext;
            _discountContext = discountContext;
        }

        public List<ProductCategoryQueryModel> GetProductCategories()
        {


            return  _shopContext.productCategories.Select(x => new ProductCategoryQueryModel
            {
                Name= x.Name,
                Picture= x.Picture,
                Description= x.Description,
                PictureAlt= x.PictureAlt,
                PictureTitle= x.PictureTitle,
                Slug= x.Slug,
                Keywords=x.Keywords,
                MetaDescription= x.MetaDescription

            }).ToList();  

            


           
        }

        public List<ProductCategoryQueryModel> GetProductCategoriesWithProducts()
        {
            var discount = _discountContext.customerDiscounts.Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
                .Select(x => new { x.ProductId, x.DiscountRate}).ToList();

            var inventory = _inventoryContext.inventory.Select(x => new { x.ProductId, x.UnitPrice }).ToList();

            var categories = _shopContext.productCategories.Include(x => x.Products).ThenInclude(x => x.Category).
                Select(x => new ProductCategoryQueryModel
                {
                    Id=x.Id,
                    Name=x.Name,
                    Products=MapProducts(x.Products)
                }).ToList();

            foreach (var category in categories)
            {
                foreach (var product in category.Products)
                {
                    var productInventory = inventory.FirstOrDefault(x => x.ProductId == product.Id);

                    if(productInventory != null) 
                    {
                        var price = productInventory.UnitPrice;
                        product.UnitPrice = price.ToMoney();

                        var productDiscount = discount.FirstOrDefault(x => x.ProductId == product.Id);
                      
                        if (productDiscount !=null)
                        {
                            var discountRate=productDiscount.DiscountRate;
                            product.DiscountRate = discountRate.ToString();

                            product.DiscountFlag = discountRate>0;
                            
                            var discountPrice = Math.Round((price * discountRate) / 100);
                            product.UnitPriceWithDiscount = (price - discountPrice).ToMoney();
                        }
                    }

                    
                 
                }
            }

            return categories;
        }

        private static List<ProductQueryModel> MapProducts(List<Product> products)
        {
            return products.Select(product => new ProductQueryModel
            {
                Id = product.Id,
                Name = product.Name,
                Picture = product.Picture,
                PictureAlt = product.PictureAlt,
                PictureTitle = product.PictureTitle,
                Category = product.Category.Name,
                Slug = product.Slug
           
            }).ToList();

        }

        public ProductCategoryQueryModel GetProductCategoriesWithProducts(string slug)
        {
            var discount = _discountContext.customerDiscounts.Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
                 .Select(x => new { x.ProductId, x.DiscountRate, x.EndDate }).ToList();

            var inventory = _inventoryContext.inventory.Select(x => new { x.ProductId, x.UnitPrice }).ToList();

            var category = _shopContext.productCategories.Include(x => x.Products).ThenInclude(x => x.Category).
                Select(x => new ProductCategoryQueryModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Products = MapProducts(x.Products),
                    Slug=x.Slug,
                    Description=x.Description,
                    MetaDescription=x.MetaDescription,
                    Keywords=x.Keywords
                }).FirstOrDefault(x=>x.Slug==slug);

           
                foreach (var product in category.Products)
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
                           product.DiscountExpire = productDiscount.EndDate.ToDiscountFormat();
                           product.DiscountFlag = discountRate > 0;
                        
                            var discountPrice = Math.Round((price * discountRate) / 100);
                            product.UnitPriceWithDiscount = (price - discountPrice).ToMoney();
                        }
                    }



                
            }

            return category;
        }
    }
}
