using metal.Application.InterFace.Contexts;
using metal.Application.service.UI.DaynamicUi.Quary.Getmedia;
using metal.Common;
using metal.Domain.Entities.Media;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using static metal.Application.service.Products.Command.AddNewCategory.AddNewCategoryService;

namespace metal.Application.service.UI.DaynamicUi.Command.AddMediaUi
{
    public interface IAddMediaUiService
    {
        List<AllCategory> Execute();
        List<AllProducts> CatProducts(int catid);
        ResultDto AddUi(AddMedia request);
    }

    public class AddMediaUiService : IAddMediaUiService
    {
        private readonly IDataBaseContext _context;
        private readonly IHostingEnvironment _environment;

        public AddMediaUiService(IDataBaseContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _environment = hostingEnvironment;
        }

        public List<AllCategory> Execute()
        {
            var categories = _context
                .Categories
                //       .Include(p => p.ParentCategory)
          //      .Where(p => p.ParentCategoryId != null)
                .ToList()
                .Select(p => new AllCategory
                {
                    Id = p.Id,
                    Name = $"{p.ParentCategory?.Name?? "No Parent"} - {p.Name}",
                }
                ).ToList();

            return categories;
        }

        public List<AllProducts> CatProducts(int catid)
        {
            var products = _context.Products.
                Include(p => p.ProductImages).
                Where(p => p.CategoryId == catid).
                ToList().
                Select(p => new AllProducts
                {
                    Id = p.Id,
                    Name = p.Name,
                    imsrc = p.ProductImages.FirstOrDefault().Src
                }
                ).ToList();

            return products;
        }


        public ResultDto AddUi(AddMedia request)
        {
            try
            {

                var media = new Media()
                {
                    Name = request.Name,
                    pName = request.pName,
                };

                _context.Medias.Add(media);



                List<MediaTexts> mtext = new List<MediaTexts>();

                foreach (var item in request.MTexts)
                {
                    mtext.Add( new MediaTexts
                    {
                        Name = item.TName,
                        Text = item.Text,
                        Media = media
                    }
                        );
                }
                _context.MediaTexts.AddRange(mtext);



                List<MediaProducts> mpro = new List<MediaProducts>();

                foreach (var item in request.MProducts)
                {
                    Console.WriteLine(item.Name);
                    var p = _context.Products.Include(p => p.ProductImages).Include(p => p.Category).Where(p => p.Name == item.Name).FirstOrDefault();

                    mpro.Add(new MediaProducts
                    {
                        Name = p.Name,
                        CName = item.CName,
                        src = p.ProductImages.FirstOrDefault().Src,
                        Titel = p.Category.Name,
                        Media = media
                    }
                        );
                }
                _context.MediaProducts.AddRange(mpro);




                List<MediaImages> mim = new List<MediaImages>();

                foreach (var item in request.MImages)
                {
                    var up = UploadFile(item.Images);
                    mim.Add(new MediaImages
                    {
                        Name = item.IName,
                        src = up.FileNameAddress,
                        Media = media
                    }
                        );
                }
                _context.MediaImages.AddRange(mim);

                _context.SaveChanges();



                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "saved"
                };
            }
            catch
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "not save"
                };
            }
        }





        private UploadDto UploadFile(IFormFile file)
        {
            if (file != null)
            {
                string folder = $@"images\ProductImages\";
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







    public class AllCategory
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }

    public class AllProducts
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string imsrc { get; set; }
    }

    public class AddMedia
    {

        public string Name { get; set; }
        public string pName { get; set; }
        public virtual List<AddMediaText>? MTexts { get; set; }
        public virtual List<AddMediaImage>? MImages { get; set; }
        public virtual List<AddMediaProduct>? MProducts { get; set; }
    }

    public class AddMediaText
    {

        public string TName { get; set; }
        public string Text { get; set; }

    }

    public class AddMediaImage
    {
        public string IName { get; set; }
        public IFormFile Images { get; set; }

    }
    public class AddMediaProduct
    {
        public string Name { get; set; }
        public string CName { get; set; }


    }
}



