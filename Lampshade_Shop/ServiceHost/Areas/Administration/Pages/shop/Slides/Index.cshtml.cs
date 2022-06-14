using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contract;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Application.Contract.ProductPicture;
using ShopManagement.Application.Contract.Slide;
using System.Collections.Generic;

namespace ServiceHost.Areas.Administration.Pages.shop.Slides
{
    public class IndexModel : PageModel
    {

      

        public List<SlideViewModel> Slides;

        

        private readonly ISlideApplication _slideApplication;
        

        public IndexModel(ISlideApplication slideApplication)
        {
            _slideApplication = slideApplication;  
        }

        public void OnGet()
        {

            Slides = _slideApplication.GetList();
            
        }

        public IActionResult OnGetCreate()
        {
            var command = new CreateSlide ();

            return Partial("./Create", command);
        }


        public JsonResult OnPostCreate(CreateSlide command)
        {
            var result = _slideApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var slide=_slideApplication.GetDetails(id);

            

            return Partial("Edit", slide);
        }

        public JsonResult OnPostEdit(EditSlide command)
        {
            var result = _slideApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetRemove(long id)
        {
            var result= _slideApplication.Remove(id);
            return RedirectToPage("./Index");
        }

        public IActionResult OnGetRestore(long id)
        {
            var result = _slideApplication.Restore(id);
            return RedirectToPage("./Index");
        }

    }
}
