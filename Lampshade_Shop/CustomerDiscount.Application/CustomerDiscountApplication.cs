using _0_Framework.Application;
using CustomerDiscount.Application.Contract.CustomerDiscount;
using DiscountManagement.Domain.CustomerDiscountAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerDiscount.Application
{
    public class CustomerDiscountApplication : ICustomerDiscountApplication
    {

        private readonly ICustomerDiscountRepository _customerDiscountRepository;

        public CustomerDiscountApplication(ICustomerDiscountRepository customerDiscountRepository)
        {
            _customerDiscountRepository = customerDiscountRepository;
        }

        public OperationResult Define(DefineCustomerDiscount command)
        {
            var operation=new OperationResult();

            if (_customerDiscountRepository.Exists(x => x.ProductId == command.ProductId && x.DiscountRate == command.DiscountRate))
                return operation.Failed(DefultMessage.DuplicatedMessage);

            var startDate = command.StartDate.ToGeorgianDateTime();
            var endDate = command.EndDate.ToGeorgianDateTime();

            var customerDiscount = new CustmerDiscount(command.ProductId, command.DiscountRate,startDate,
                endDate,command.DiscountReason);
            _customerDiscountRepository.Create(customerDiscount);
            _customerDiscountRepository.SaveChanges();
            return operation.Succedded();

        }

        public OperationResult Edit(EditCustomerDiscount command)
        {
            var operation = new OperationResult();

            var customerDiscount = _customerDiscountRepository.Get(command.Id);

            if(customerDiscount == null)
                return operation.Failed(DefultMessage.NotFoundMessage);

            if (_customerDiscountRepository.Exists(x => x.ProductId == command.ProductId
           && x.DiscountRate == command.DiscountRate && x.Id != command.Id))
                return operation.Failed(DefultMessage.DuplicatedMessage);


            var startDate = command.StartDate.ToGeorgianDateTime();
            var endDate = command.EndDate.ToGeorgianDateTime();

            customerDiscount.Edit(command.ProductId, command.DiscountRate, startDate,
                endDate, command.DiscountReason);
            _customerDiscountRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditCustomerDiscount GetDetails(long id)
        {
            return _customerDiscountRepository.GetDetails(id);
        }

        public List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel)
        {
            return _customerDiscountRepository.Search(searchModel);
        }
    }
}
