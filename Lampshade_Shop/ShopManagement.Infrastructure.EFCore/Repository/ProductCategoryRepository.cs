using _0_Framework.Infrastructure;
using ShopManagement.Application.Contract;
using ShopManagement.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class ProductCategoryRepository : RepositoryBase<long, ProductCategory>, IProductCategoryRepository
    {

        private readonly ShopContext _context;

        public ProductCategoryRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public List<ProductCategoryViewModel> GetProductCategories()
        {
            return _context.productCategories.Select(x => new ProductCategoryViewModel
{
                Id= x.Id,
                Name= x.Name
            }).ToList();
           
        }

        public EditProductCategory GetDetails(long id)
        {
            return _context.productCategories.Select(x => new EditProductCategory()
            {

                Id = x.Id,
                Name = x.Name,
                Description=x.Description,
                Picture=x.Picture,
                PictureAlt=x.PictureAlt,
                PictureTitle=x.PictureTitle,
                Keywords=x.Keywords,
                MetaDescription=x.MetaDescription,
                Slug=x.Slug



        }).FirstOrDefault(x => x.Id == id);
    }

       

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
        {
            var query = _context.productCategories.Select(x => new ProductCategoryViewModel
            {
                Id=x.Id,
                Name=x.Name,
                Picture=x.Picture,
                CreationDate = x.CreationDate
               
            });
             

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
