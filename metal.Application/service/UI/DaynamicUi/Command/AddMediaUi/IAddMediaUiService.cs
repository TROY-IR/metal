using metal.Application.InterFace.Contexts;
using metal.Common;
using metal.Domain.Entities.Media;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

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

        public AddMediaUiService(IDataBaseContext context)
        {
            _context = context;
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

                var products = _context.Products.Include(p => p.ProductImages).Where(p => request.MProducts.Select(p1 => p1.Id).ToList().Contains(p.Id)).ToList();

                var media = new Media
                {
                    Name = request.Name,
                    pName = request.pName,
                    
                    MTexts = request.MTexts.ToList().Select(p => 
                    new MediaTexts
                    {
                        Name = p.Name,
                        Text =p.Text
                    }
                    ).ToList(),
                    MImages = request.MImages.ToList().Select(p =>
                    new MediaImages
                    {
                        Name = p.Name,
                        src = p.src
                    }
                    ).ToList(),
                    MProducts = request.MProducts. Join(
                        products,
                        mp => mp.Id,
                        pdb => pdb.Id,
                   (mp,pdb) => new MediaProducts
                    {
                        Name = pdb.Name,
                        Titel = pdb.Description,
                        CName = mp.CName,
                        src = pdb.ProductImages.FirstOrDefault().Src
                    }
                    ).ToList()
                };


                _context.Medias.Add(media);

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
        public virtual List<AddMediaText> MTexts { get; set; }
        public virtual List<AddMediaImage> MImages { get; set; }
        public virtual List<AddMediaProduct> MProducts { get; set; }
    }

    public class AddMediaText
    {

        public string Name { get; set; }
        public string Text { get; set; }

    }

    public class AddMediaImage
    {
        public string Name { get; set; }
        public string src { get; set; }

    }
    public class AddMediaProduct
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string CName { get; set; }
        public string Titel { get; set; }
        public string imsrc { get; set; }


    }
}



