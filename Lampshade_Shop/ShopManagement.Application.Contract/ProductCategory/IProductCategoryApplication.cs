using _0_Framework.Application;
using System.Collections.Generic;

namespace ShopManagement.Application.Contract
{
    public interface IProductCategoryApplication
    {
        OperationResult Create(CreateProductCategory command);

        OperationResult Edit(EditProductCategory command);

        List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel);

        EditProductCategory GetDetails(long id);

        List<ProductCategoryViewModel> GetProductCategories();

    }
}
