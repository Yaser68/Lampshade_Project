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
    public class ProductCategoryRepository : IProductCategoryRepository
    {

        private readonly ShopContext _context;


        public void Create(ProductCategory category)
        {
            _context.productCategories.Add(category);
        }

        public bool Exists(Expression<Func<ProductCategory, bool>> expression)
        {
            return _context.productCategories.Any(expression);
        }

        public ProductCategory Get(long id)
        {
            return _context.productCategories.Find(id);
        }

        public List<ProductCategory> GetAll()
        {
            return _context.productCategories.ToList();
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

        public void SaveChanges()
        {
            _context.SaveChanges();
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
