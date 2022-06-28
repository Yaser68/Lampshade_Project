using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contract;
using ShopManagement.Application.Contract.Comment;
using ShopManagement.Application.Contract.Product;
using ShopManagement.Application.Contract.ProductPicture;
using ShopManagement.Application.Contract.Slide;
using System.Collections.Generic;

namespace ServiceHost.Areas.Administration.Pages.shop.Comments
{
    public class IndexModel : PageModel
    {

      

        public List<CommentViewModel> Comments;

        public CommentSearchModel SearchModel;

        private readonly ICommentApplication _commentApplication;
        

        public IndexModel(ICommentApplication commentApplication)
        {
            _commentApplication = commentApplication;  
        }

        public void OnGet(CommentSearchModel searchModel)
        {

            Comments = _commentApplication.Search(searchModel);
            
        }


        public IActionResult OnGetConfirm(long id)
        {
            var result= _commentApplication.Confirm(id);
            return RedirectToPage("./Index");
        }

        public IActionResult OnGetCancel(long id)
        {
            var result = _commentApplication.Cancel(id);
            return RedirectToPage("./Index");
        }

    }
}
