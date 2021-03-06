using ShopManagement.Application.Contract.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerDiscount.Application.Contract.CustomerDiscount
{
    public class DefineCustomerDiscount
    {
        public long ProductId { get;  set; }
        public int DiscountRate { get;  set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string DiscountReason { get; set; }

        public List<ProductViewModel> Products { get; set; }

    }
}
