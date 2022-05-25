using _0_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class ProductRepository : RepositoryBase<long, Product>, IProductRepository
    {

        private readonly ShopContext _context;

        public ProductRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public EditProduct GetDetails(long id)
        {
            return _context.products.Select(x=> new EditProduct { 
            
                Id=x.Id,
                Name=x.Name,
                Code=x.Code,
                ShortDescription=x.ShortDescription,
                Slug=x.Slug,
                Description=x.Description,
                Picture=x.Picture,
                PictureAlt=x.PictureAlt,
                PictureTitle=x.PictureTitle,
                UnitPrice=x.UnitPrice,
                Keywords=x.Keywords,
                MetaDescription=x.MetaDescription,



            
            }).FirstOrDefault(x=>x.Id==id);
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            var query = _context.products.Include(x => x.Category).Select(x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Picture = x.Picture,
                Code = x.Code,
                UnitPrice = x.UnitPrice,
                CreationDate = x.CreationDate,
                Category = x.Category.Name,
                CategoryId = x.CategoryId

            }) ;


            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            if (!string.IsNullOrWhiteSpace(searchModel.Code))
                query = query.Where(x => x.Code.Contains(searchModel.Code));

            if (searchModel.CategoryId != 0)
                query = query.Where(x => x.CategoryId == searchModel.CategoryId);

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
