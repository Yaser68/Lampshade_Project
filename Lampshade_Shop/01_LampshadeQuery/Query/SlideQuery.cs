using _01_LampshadeQuery.Contracts.Slide;
using ShopManagement.Infrastructure.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_LampshadeQuery.Query
{
    public class SlideQuery : ISlideQuery
    {

        private readonly ShopContext _shopContext;

        public SlideQuery(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public List<SlideQueryModel> GetSlide()
        {
            return _shopContext.slides.Where(x=>x.IsRemoved==false)
                .Select(x => new SlideQueryModel 
                { 
                    Picture=x.Picture,
                    PictureAlt=x.PictureAlt,
                    PictureTitle=x.PictureTitle,
                    Heading=x.Heading,
                    Title=x.Title,
                    Text=x.Text,
                    BtnText=x.BtnText,
                    Link=x.Link
                    
                })
                .ToList();
        }
    }
}
