using _0_Framework.Domain;

namespace ShopManagement.Application.Contract
{
    public class ProductCategoryViewModel : EntityBase
    {
        public string Name { get; set; }
        public string Picture { get; set; }

        public long ProductsCount { get; set; }

      

    }
}
