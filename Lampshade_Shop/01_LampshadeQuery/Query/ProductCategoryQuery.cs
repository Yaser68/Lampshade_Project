using _01_LampshadeQuery.Contracts.ProductCategory;
using ShopManagement.Infrastructure.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_LampshadeQuery.Query
{
    public class ProductCategoryQuery : IProductCategoryQuery
    {
        private readonly ShopContext _shopContext;

        public ProductCategoryQuery(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public List<ProductCategoryQueryModel> GetProductCategories()
        {
            return _shopContext.productCategories.Select(x => new ProductCategoryQueryModel
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
    }
}
