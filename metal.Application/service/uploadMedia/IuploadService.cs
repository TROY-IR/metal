using Microsoft.AspNetCore.Http;
//using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using static metal.Application.service.Products.Command.AddNewCategory.AddNewCategoryService;

namespace metal.Application.service.NewFolder
{
    public interface IuploadService
    {
        UploadDto UploadFile(IFormFile file);
    }
    public class uploadService : IuploadService
    {
        private readonly IHostingEnvironment _environment;

        public uploadService(IHostingEnvironment environment)
        {
            _environment = environment;
        }
        public UploadDto UploadFile(IFormFile file)
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

