using _0_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Application.Contract.ProductPicture;
using ShopManagement.Domain.ProductPictureAgg;
using System.Collections.Generic;
using System.Linq;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class ProductPictureRepository : RepositoryBase<long, ProductPicture> , IProductPictureRepository
    {
        private readonly ShopContext _context;
        public ProductPictureRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public EditProductPicture GetDetails(long id)
        {
            return _context.productPictures.Select(x => new EditProductPicture
            {

                Id = x.Id,
                ProductId = x.ProductId,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,

            }).FirstOrDefault(x => x.Id == id);
        }

      

        public List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel)
        {
            var query = _context.productPictures
               .Include(x => x.Product)
               .Select(x => new ProductPictureViewModel
               {
                   Id = x.Id,
                   Product = x.Product.Name,
                   CreationDate = x.CreationDate.ToString(),
                   Picture = x.Picture,
                   ProductId = x.ProductId,
                   IsRemoved= x.IsRemoved
               });

            if (searchModel.ProductId != 0)
                query = query.Where(x => x.ProductId == searchModel.ProductId);

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
