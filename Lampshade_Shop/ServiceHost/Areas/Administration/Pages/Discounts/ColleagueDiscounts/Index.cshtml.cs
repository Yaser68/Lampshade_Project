using CustomerDiscount.Application.Contract.ColleagueDiscount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contract;
using ShopManagement.Application.Contract.Product;
using System.Collections.Generic;

namespace ServiceHost.Areas.Administration.Pages.Discounts.ColleagueDiscount
{
    public class IndexModel : PageModel
    {

        public ColleagueDiscountSearchModel SearchModel;

        public List<ColleaguediscountViewModel> colleagueDiscount;

        public SelectList products;

        private readonly IProductApplication _productApplication;
        private readonly IColleagueDiscountApplication _colleagueDiscountApplication;

        public IndexModel(IProductApplication productApplication, IColleagueDiscountApplication colleagueDiscountApplication)
        {
            _productApplication = productApplication;
            _colleagueDiscountApplication = colleagueDiscountApplication;
        }

        public void OnGet(ColleagueDiscountSearchModel searchModel)
        {

            colleagueDiscount = _colleagueDiscountApplication.Search(searchModel);
            products = new SelectList(_productApplication.GetProducts(), "Id", "Name");

        }

        public IActionResult OnGetCreate()
        {
            var command = new DefineColleagueDiscount
            {

                Products = _productApplication.GetProducts()
            };
            return Partial("./Create", command);
    }
            
        
         
   

       


        public JsonResult OnPostCreate(DefineColleagueDiscount command)
        {
            var result = _colleagueDiscountApplication.Define(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var colleagueDiscount= _colleagueDiscountApplication.GetDetails(id);

            colleagueDiscount.Products = _productApplication.GetProducts();

            return Partial("Edit", colleagueDiscount);
        }

        public JsonResult OnPostEdit(EditColleagueDiscount command)
        {
            var result= _colleagueDiscountApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetRemove(long id)
        {
            var result= _colleagueDiscountApplication.Remove(id);
            return RedirectToPage("./Index");
        }

        public IActionResult OnGetRestore(long id)
        {
            var result = _colleagueDiscountApplication.Restore(id);
            return RedirectToPage("./Index");
        }

    }
}
