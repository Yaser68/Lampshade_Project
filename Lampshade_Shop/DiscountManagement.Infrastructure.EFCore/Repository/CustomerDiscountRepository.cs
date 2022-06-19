using _0_Framework.Infrastructure;
using CustomerDiscount.Application.Contract.CustomerDiscount;
using DiscountManagement.Domain.CustomerDiscountAgg;
using _0_Framework.Application;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Infrastructure.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Infrastructure.EFCore.Repository
{
    public class CustomerDiscountRepository : RepositoryBase<long,CustmerDiscount>, ICustomerDiscountRepository
    {

        private readonly DiscountContext _Context;
        private readonly ShopContext _shopContext;

        public CustomerDiscountRepository(DiscountContext Context,ShopContext shopContext) : base(Context)
        {
            _Context = Context;
            _shopContext = shopContext;
        }

       

        public EditCustomerDiscount GetDetails(long id)
        {
            return _Context.customerDiscounts.Select(x => new EditCustomerDiscount
            {
                Id = x.Id,
                ProductId = x.ProductId,
                DiscountRate = x.DiscountRate,
                StartDate = x.StartDate.ToString(),
                EndDate=x.EndDate.ToString(),
                DiscountReason = x.DiscountReason

            }).FirstOrDefault(x => x.Id == id);
        }

        public List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel)
        {
            var products = _shopContext.products.Select(x => new { x.Id, x.Name }).ToList();
            var query = _Context.customerDiscounts.Select(x => new CustomerDiscountViewModel
            {
                Id = x.Id,
                DiscountRate = x.DiscountRate,
                EndDate = x.EndDate.ToFarsi(),
                EndDateGr = x.EndDate,
                StartDate = x.StartDate.ToFarsi(),
                StartDateGr = x.StartDate,
                ProductId = x.ProductId,
                DiscountReason = x.DiscountReason,
                CreationDate = x.CreationDate
            });

            if (searchModel.ProductId > 0)
                query = query.Where(x => x.ProductId == searchModel.ProductId);

            if (!string.IsNullOrWhiteSpace(searchModel.StartDate))
            {
               
                query = query.Where(x => x.StartDateGr > searchModel.StartDate.ToGeorgianDateTime());
            }

            if (!string.IsNullOrWhiteSpace(searchModel.EndDate))
            {
                
                query = query.Where(x => x.EndDateGr < searchModel.EndDate.ToGeorgianDateTime());
            }

            var discounts = query.OrderByDescending(x => x.Id).ToList();

            discounts.ForEach(discount =>
                discount.Product = products.FirstOrDefault(x => x.Id == discount.ProductId)?.Name);

            return discounts;
        }
    }
}
