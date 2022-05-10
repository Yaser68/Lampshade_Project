using ShopManagement.Application.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductCategoryAgg
{
    public interface IProductCategoryRepository
    {
        void Create(ProductCategory category);

        ProductCategory Get(long id);

        List<ProductCategory> GetAll();

        bool Exists(Expression<Func<ProductCategory, bool>> expression);

        void SaveChanges();

        List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel);

        EditProductCategory GetDetails(long id);


    }
}
