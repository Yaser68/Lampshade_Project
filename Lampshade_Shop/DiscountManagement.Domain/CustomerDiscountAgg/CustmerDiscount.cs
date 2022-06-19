using _0_Framework.Domain;
using System;

namespace DiscountManagement.Domain.CustomerDiscountAgg
{
    public class CustmerDiscount : EntityBase
    {
        public long ProductId { get; private set; }
        public int DiscountRate { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public string DiscountReason { get; private set; }

        public CustmerDiscount(long productId, int discountRate, DateTime startDate,
            DateTime endDate, string discountReason)
        {
            ProductId = productId;
            DiscountRate = discountRate;
            StartDate = startDate;
            EndDate = endDate;
            DiscountReason = discountReason;
        }

        public void Edit(long productId, int discountRate, DateTime startDate,
            DateTime endDate, string discountReason)
        {
            ProductId = productId;
            DiscountRate = discountRate;
            StartDate = startDate;
            EndDate = endDate;
            DiscountReason = discountReason;
        }
    }
}
