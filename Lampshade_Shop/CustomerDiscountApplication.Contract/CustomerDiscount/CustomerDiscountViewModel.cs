using _0_Framework.Domain;
using System;

namespace CustomerDiscount.Application.Contract.CustomerDiscount
{
    public class CustomerDiscountViewModel :EntityBase
    {
       
        public long ProductId { get; set; }
        public string Product { get; set; }
        public int DiscountRate { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public DateTime StartDateGr { get; set; }
        public DateTime EndDateGr { get; set; }
        public string DiscountReason { get; set; }
    }
}
