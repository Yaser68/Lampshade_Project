using _0_Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract.ProductPicture
{
    public  interface IProductPictureApplication
    {

        OperationResult Creat(CreateProductPicture command);
        OperationResult Edit(EditProductPicture command);

        EditProductPicture GetDetails(long id);
        List<ProductPictureViewModel> Search(ProductPictureSearchModel command);

        OperationResult Remove(long id);
        OperationResult Restore(long id);

    }
}
