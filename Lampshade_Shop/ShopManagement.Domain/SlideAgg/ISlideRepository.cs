﻿using _0_Framework.Domain;
using ShopManagement.Application.Contract.Slide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.SlideAgg
{
    public interface ISlideRepository : IRepository<long, Slide>
    {
       EditSlide GetDetails(long id);
        List<SlideViewModel> GetList();
    }
}
