using _0_Framework.Application;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract.Product
{
    public  class CreateProduct
    {
        [Required(ErrorMessage =DefultMessage.IsRequired)]
        public string Name { get;  set; }

        [Required(ErrorMessage = DefultMessage.IsRequired)]
        public string Code { get;  set; }

        [Required(ErrorMessage = DefultMessage.IsRequired)]
        public double UnitPrice { get;  set; }

        [Required(ErrorMessage = DefultMessage.IsRequired)]
        public string ShortDescription { get;  set; }
        public string Description { get;  set; }
        public string Picture { get;  set; }

        [Required(ErrorMessage = DefultMessage.IsRequired)]
        public string PictureAlt { get;  set; }

        [Required(ErrorMessage = DefultMessage.IsRequired)]
        public string PictureTitle { get;  set; }
        public string Slug { get;  set; }

        [Required(ErrorMessage = DefultMessage.IsRequired)]
        public string Keywords { get;  set; }

        [Required(ErrorMessage = DefultMessage.IsRequired)]
        public string MetaDescription { get;  set; }

        [Range(1,1000,ErrorMessage =DefultMessage.IsRequired)]
        public long CategoryId { get;  set; }


        public List<ProductCategoryViewModel> Categories { get; set; }

    }
}
