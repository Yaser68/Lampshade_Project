﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ShopManagement.Application.Contract.Product
{
    public class ProductViewModel
    {
        public long  Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
  
        public string Picture { get; set; }
        public DateTime CreationDate { get; set; }
        public string Category { get; set; }
        public long CategoryId { get; set; }

   
    }
}
