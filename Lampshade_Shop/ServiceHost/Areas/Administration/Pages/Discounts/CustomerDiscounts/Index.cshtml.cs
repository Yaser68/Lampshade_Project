using CustomerDiscount.Application.Contract.CustomerDiscount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contract.Product;
using System.Collections.Generic;

namespace ServiceHost.Areas.Administration.Pages.Discounts.CustomerDiscounts
{
    public class IndexModel : PageModel
    {

        public CustomerDiscountSearchModel SearchModel;

        public List<CustomerDiscountViewModel> customerDiscount;

        public SelectList products;

        private readonly IProductApplication _productApplication;
        private readonly ICustomerDiscountApplication _CustomerDiscountApplication;

        public IndexModel(IProductApplication productApplication, ICustomerDiscountApplication customerDiscountApplication)
        {
            _productApplication = productApplication;
            _CustomerDiscountApplication = customerDiscountApplication;
        }

        public void OnGet(CustomerDiscountSearchModel searchModel)
        {

            customerDiscount = _CustomerDiscountApplication.Search(searchModel);
            products = new SelectList(_productApplication.GetProducts(), "Id", "Name");
        }

        public IActionResult OnGetCreate()
        {


            var command = new DefineCustomerDiscount {

                Products = _productApplication.GetProducts()
        };

            return Partial("./Create", command);
        }


        public JsonResult OnPostCreate(DefineCustomerDiscount command)
        {
            var result = _CustomerDiscountApplication.Define(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var CustomerDiscount = _CustomerDiscountApplication.GetDetails(id);

            CustomerDiscount.Products = _productApplication.GetProducts();

            return Partial("Edit", CustomerDiscount);
        }

        public JsonResult OnPostEdit(EditCustomerDiscount command)
        {
            var result= _CustomerDiscountApplication.Edit(command);
            return new JsonResult(result);
        }

       

    }
}
