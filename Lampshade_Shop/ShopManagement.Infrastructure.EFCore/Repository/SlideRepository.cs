using _0_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contract.Slide;
using ShopManagement.Domain.SlideAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class SlideRepository : RepositoryBase<long, Slide>, ISlideRepository 
    {

        private readonly ShopContext _Context;
        public SlideRepository(ShopContext context) : base(context)
        {
            _Context = context;
        }

        public EditSlide GetDetails(long id)
        {
            return _Context.slides.Select(x=>new EditSlide
            {
                Id=x.Id,
                Picture=x.Picture,
                PictureAlt=x.PictureAlt,
                PictureTitle=x.PictureTitle,
                Heading=x.Heading,
                Title=x.Title,
                Text=x.Text,
                BtnText=x.BtnText,
                Link=x.Link
            }).FirstOrDefault(x=>x.Id == id);
        }

        public List<SlideViewModel> GetList()
        {
            return _Context.slides.Select(x => new SlideViewModel { 
            Id=x.Id,
            Picture=x.Picture,
            Heading=x.Heading,
            Title=x.Title,
            CreationDate=x.CreationDate.ToString(),
            IsRemoved=x.IsRemoved
            }).OrderByDescending(x=>x.Id).ToList();
        }
    }
}
