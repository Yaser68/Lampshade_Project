using _01_LampshadeQuery.Contracts.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using DiscountManagement.Infrastructure.EFCore;
using InventoryManagement.Infrastructure.EFCore;
using ShopManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.ProductPictureAgg;
using ShopManagement.Domain.CommentAgg;

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

        public ProductQueryModel GetDetails(string slug)
        {

            var discount = _discountContext.customerDiscounts.Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
            .Select(x => new { x.ProductId, x.DiscountRate, x.EndDate }).ToList();

            var inventory = _inventoryContext.inventory.Select(x => new { x.ProductId, x.UnitPrice, x.InStock }).ToList();


            var Product = _shopContext.products.Include(x => x.Category)
                .Include(x => x.ProductPictures)
                .Select(x => new ProductQueryModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    Slug = x.Slug,
                    Category = x.Category.Name,
                    CategorySlug = x.Category.Slug,
                    Description = x.Description,
                    Keywords = x.Keywords,
                    MetaDescription = x.MetaDescription,
                    Code = x.Code,
                    Comments = MapComments(x.Comments),
                    ProductPictures = MapProductPictures(x.ProductPictures)



                }).FirstOrDefault(x => x.Slug == slug);

            
            
                var productInventory = inventory.FirstOrDefault(x => x.ProductId == Product.Id);

                if (productInventory != null)
                {
                Product.IsInStock = productInventory.InStock;
                    var price = productInventory.UnitPrice;
                   Product.UnitPrice = price.ToMoney();

                    var productDiscount = discount.FirstOrDefault(x => x.ProductId == Product.Id);

                    if (productDiscount != null)
                    {
                    Product.DiscountExpire = productDiscount.EndDate.ToDiscountFormat();
                        var discountRate = productDiscount.DiscountRate;
                        Product.DiscountRate = discountRate.ToString();

                    Product.DiscountFlag = discountRate > 0;

                        var discountPrice = Math.Round((price * discountRate) / 100);
                    Product.UnitPriceWithDiscount = (price - discountPrice).ToMoney();
                    }
                }

            return Product;

        }

        private static List<CommentQueryModel> MapComments(List<Comment> comments)
        {
            return comments.Where(x=>x.IsConfirmed==true).Select(x => new CommentQueryModel
            {
               Id=x.Id,
               Name=x.Name,
               Message=x.Message
            }).ToList();
        }

        private static List<ProductPictureQueryModel> MapProductPictures(List<ProductPicture> productPictures)
        {
            return productPictures.Select(x => new ProductPictureQueryModel 
            {
                ProductId=x.ProductId,
                Picture=x.Picture,
                PictureAlt=x.PictureAlt,
                PictureTitle=x.PictureTitle,
                IsRemoved=x.IsRemoved
            }).Where(x => !x.IsRemoved).ToList();
        }

        public List<ProductQueryModel> LastArrivals()
        {
            var Products = _shopContext.products.Select(x => new ProductQueryModel
            {
                Id = x.Id,
                Name = x.Name,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Slug = x.Slug,
                Category = x.Category.Name

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

        public List<ProductQueryModel> Search(string value)
        {
            var discount = _discountContext.customerDiscounts.Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
               .Select(x => new { x.ProductId, x.DiscountRate }).ToList();

            var inventory = _inventoryContext.inventory.Select(x => new { x.ProductId, x.UnitPrice }).ToList();

            var query = _shopContext.products.Include(x => x.Category).Select(product => new ProductQueryModel
            {
                Id = product.Id,
                Name = product.Name,
                Picture = product.Picture,
                PictureAlt = product.PictureAlt,
                PictureTitle = product.PictureTitle,
                Category = product.Category.Name,
                ShortDescription=product.ShortDescription,
                Slug = product.Slug

            }).AsNoTracking();


            if (!string.IsNullOrWhiteSpace(value))
                query = query.Where(x => x.Name.Contains(value) || x.ShortDescription.Contains(value));

            var products = query.OrderByDescending(x => x.Id).ToList();

            
                foreach (var product in products)
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

            return products;
        }

       
    }
}
