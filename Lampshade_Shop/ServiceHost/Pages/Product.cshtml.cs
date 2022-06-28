using _01_LampshadeQuery.Contracts.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contract.Comment;

namespace ServiceHost.Pages
{
    public class ProductModel : PageModel
    {
        public ProductQueryModel Product;
        
        private readonly IProductQuery _productQuery;
      
        private readonly ICommentApplication _commentApplication;

        public ProductModel(IProductQuery productQuery, ICommentApplication commentApplication)
        {
            _productQuery = productQuery;
            _commentApplication = commentApplication;
        }

        public void OnGet(string id)
        {
           Product=_productQuery.GetDetails(id);
            

        }

        public IActionResult OnPost(AddComment comment, string slug)
        {
            var result = _commentApplication.Add(comment);
            return RedirectToPage("/Product", slug);

        }
    }
}
