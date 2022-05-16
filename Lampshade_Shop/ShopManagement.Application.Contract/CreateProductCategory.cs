﻿using _0_Framework.Application;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contract
{
    public class CreateProductCategory
    {

        [Required(ErrorMessage =DefultMessage.IsRequired)]
        public string Name { get;  set; }
        public string Description { get;  set; }
        public string Picture { get;  set; }
       
        public string PictureAlt { get;  set; }
        public string PictureTitle { get;  set; }
        
        [Required(ErrorMessage = DefultMessage.IsRequired)]
        public string Keywords { get;  set; }

        [Required(ErrorMessage = DefultMessage.IsRequired)]
        public string MetaDescription { get;  set; }

        [Required(ErrorMessage = DefultMessage.IsRequired)]
        public string Slug { get;  set; }

    }
}
