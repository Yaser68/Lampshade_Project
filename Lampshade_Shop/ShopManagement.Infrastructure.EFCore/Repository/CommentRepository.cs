using _0_Framework.Application;
using _0_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contract.Comment;
using ShopManagement.Domain.CommentAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class CommentRepository : RepositoryBase<long, Comment>, ICommentRepository
    {

        private readonly ShopContext _shopContext;

        public CommentRepository(ShopContext context) : base(context)
        {
            _shopContext = context;
        }

       

        public List<CommentViewModel> Search(CommentSearchModel searchModel)
        {
            var query = _shopContext.comments.Select(x => new CommentViewModel
            {
                Id=x.Id,
                Name = x.Name,
                Mail = x.Mail,
                IsCanceled = x.IsCanceled,
                IsConfirmed = x.IsConfirmed,
                ProductId = x.ProductId,
                Message = x.Message,
                ProductName = x.Product.Name,
                CommentDate=x.CreationDate.ToFarsi()


            }) ;

            if(!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            if (!string.IsNullOrWhiteSpace(searchModel.Mail))
                query = query.Where(x => x.Mail.Contains(searchModel.Mail));

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
