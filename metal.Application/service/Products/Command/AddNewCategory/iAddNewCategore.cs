using metal.Application.InterFace.Contexts;
using metal.Application.service.Products.Command.AddNewProduct;
using metal.Common;
using metal.Domain.Entities.Products;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using static metal.Application.service.Products.Command.AddNewCategory.AddNewCategoryService;

namespace metal.Application.service.Products.Command.AddNewCategory
{
    public interface IAddNewCategoryService
    {
        ResultDto Execute(RequestAddNewCategoryDto request);
    }

    public class AddNewCategoryService : IAddNewCategoryService
    {
        private readonly IDataBaseContext _context;
        private readonly IHostingEnvironment _environment;

        public AddNewCategoryService(IDataBaseContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _environment = hostingEnvironment;
        }

        public ResultDto Execute(RequestAddNewCategoryDto request)
        {
            if (string.IsNullOrEmpty(request.Name))
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "نام دسته بندی را وارد نمایید",
                };
            }

            Category category = new Category()
            {
                Name = request.Name,
                ParentCategory = GetParent(request.ParentId),
        //        Imsrc = UploadFile(request.Images.FirstOrDefault()).FileNameAddress)
            };
            _context.Categories.Add(category);

            List<CategoryImages> catim = new List<CategoryImages>();
            foreach (var item in request.Images)
            {
                var uploadedResult = UploadFile(item);
                catim.Add(new CategoryImages
                {
                    Category = category,
                    Src = uploadedResult.FileNameAddress,
                });
            }
            _context.CategoryImages.AddRange(catim);




            _context.SaveChanges();

            return new ResultDto()
            {
                IsSuccess = true,
                Message = "دسته بندی با موفقیت اضافه شد",
            };
        }

        private Category GetParent(long? ParentId)
        {
            return _context.Categories.Find(ParentId);
        }


        private UploadDto UploadFile(IFormFile file)
        {
            if (file != null)
            {
                string folder = $@"images\CategoryImages\";
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


        public class UploadDto
        {
            public long Id { get; set; }
            public bool Status { get; set; }
            public string FileNameAddress { get; set; }
        }

        public class RequestAddNewCategoryDto
        {
            public long ParentId { get; set; }
            public string Name { get; set; }
            public List<IFormFile> Images { get; set; }
        }
    }
}

