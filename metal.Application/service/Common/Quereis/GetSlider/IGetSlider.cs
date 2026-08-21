using metal.Application.InterFace.Contexts;
using metal.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace metal.Application.service.Common.Quereis.GetSlider
{
    public interface IGetSliderService
    {
        ResultDto<List<SliderDto>> Execute();
    }

    public class GetSliderService : IGetSliderService
    {
        private readonly IDataBaseContext _context;
        public GetSliderService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<SliderDto>> Execute()
        {
            var sliders = _context.Slider.OrderByDescending(p => p.Id).ToList().Select(
                p => new SliderDto
                {
                    Link = p.link,
                    imSrc = p.imsrc,
                    vSrc = p.vsrc,
                }).ToList();

            return new ResultDto<List<SliderDto>>()
            {
                Data = sliders,
                IsSuccess = true,
            };
        }
    }

    public class SliderDto
    {
        public string imSrc { get; set; }
        public string vSrc { get; set; }
        public string Link { get; set; }
    }
}
