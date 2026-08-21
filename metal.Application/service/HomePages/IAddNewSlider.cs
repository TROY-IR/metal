using metal.Application.InterFace.Contexts;
using metal.Common;
using metal.Domain.Entities.HomePages;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using static metal.Application.service.Products.Command.AddNewCategory.AddNewCategoryService;

namespace metal.Application.service.HomePages
{
    public interface IAddNewSliderService
    {
        ResultDto Execute(IFormFile imfile, IFormFile vfile, string Link);
    }

    public class AddNewSliderService : IAddNewSliderService
    {

        private readonly IHostingEnvironment _environment;
        private readonly IDataBaseContext _context;

        public AddNewSliderService(IHostingEnvironment environment, IDataBaseContext context)
        {
            _environment = environment;
            _context = context;
        }
        public ResultDto Execute(IFormFile imfile, IFormFile vfile, string Link)
        {
            var resultUploadim = UploadFile(imfile);
            var resultUploadv = UploadFile(vfile);

            Slider slider = new Slider()
            {
                link = Link,
                imsrc = resultUploadim.FileNameAddress,
                vsrc = resultUploadv.FileNameAddress,
            };
            _context.Slider.Add(slider);
            _context.SaveChanges();

            return new ResultDto()
            {
                IsSuccess = true
            };

        }
        private UploadDto UploadFile(IFormFile file)
        {
            if (file != null)
            {
                string folder = $@"images\HomePages\Slider\";
                var uploadsRootFolder = Path.Combine(_environment.WebRootPath, folder);
                if (!Directory.Exists(uploadsRootFolder))
                {
                    Directory.CreateDirectory(uploadsRootFolder);
                }


                if (file == null || file.Length == 0)
                {
                    return new UploadDto()
                    {
                        Status = false,
                        FileNameAddress = "",
                    };
                }

                string fileName = DateTime.Now.Ticks.ToString() + file.FileName;
                var filePath = Path.Combine(uploadsRootFolder, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                return new UploadDto()
                {
                    FileNameAddress = folder + fileName,
                    Status = true,
                };
            }
            return null;
        }
    }

}
