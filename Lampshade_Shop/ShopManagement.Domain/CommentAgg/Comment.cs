using _0_Framework.Domain;
using ShopManagement.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.CommentAgg
{
    public class Comment : EntityBase
    {
        public string Name { get; private set; }
        public string Mail { get; private set; }
        public string Message { get; private set; }
        public bool IsConfirmed { get; private set; }
        public bool IsCanceled { get; private set; }
        public long ProductId { get; private set; }
        public Product  Product { get; private set; }



        public Comment(string name, string mail, string message, long productId)
        {
            Name = name;
            Mail = mail;
            Message = message;
            ProductId = productId;
        }

        public void Confirm()
        {
            IsConfirmed = true;
            IsCanceled = false;
        }

        public void Cancel()
        {
            IsCanceled= true;
            IsConfirmed = false;
        }
    }
}
