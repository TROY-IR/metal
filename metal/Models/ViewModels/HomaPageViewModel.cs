using metal.Application.service.Common.Quereis.GetSlider;
using metal.Application.service.Products.Quary.GetProDuctForSite;

namespace metal.Models.ViewModels
{
    public class HomePageViewModel
    {
        public List<SliderDto> Sliders { get; set; }
//        public List<HomePageImagesDto> PageImages { get; set; }
        public List<ProductForSiteDto> Camera { get; set; }
        public List<ProductForSiteDto> Mobile { get; set; }
        public List<ProductForSiteDto> Laptop { get; set; }
    }
}
