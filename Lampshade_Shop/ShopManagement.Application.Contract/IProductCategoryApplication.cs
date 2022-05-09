using ShopManagement.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract
{
    public interface IProductCategoryApplication
    {
        void Create(CreateProductCategory command);

        void Edit(EditProductCategory command);

        List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel);

        ProductCategory GetDetails(long id);

    }
}
