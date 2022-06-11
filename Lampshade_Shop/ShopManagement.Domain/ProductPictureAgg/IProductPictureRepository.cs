using _0_Framework.Domain;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Application.Contract.ProductPicture;
using ShopManagement.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductPictureAgg
{
    public interface IProductPictureRepository : IRepository<long, ProductPicture>
    {
        EditProductPicture GetDetails(long id);

        List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel);

       
    }
}
