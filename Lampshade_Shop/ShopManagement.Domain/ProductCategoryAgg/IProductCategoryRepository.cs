using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductCategoryAgg
{
    internal interface IProductCategoryRepository
    {
        void Create(ProductCategory category);

        ProductCategory Get(long id);

        List<ProductCategory> GetAll();


    }
}
