using metal.Application.InterFace.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using static metal.Application.service.Products.Quary.GetProductForSearch.productSearchDto;

namespace metal.Application.service.Products.Quary.GetProductForSearch
{
    public interface IGetProductForSearch
    {
         (List<productSearchDto>,List<CatForSearchDto>,List<ProductForSearchDto>) Execute(string name,int catid);
    }

    public class GetProductForSearch : IGetProductForSearch
    {
       private readonly IDataBaseContext _context;
        public GetProductForSearch(IDataBaseContext context)
        {
            _context = context;
        }

        public (List<productSearchDto>, List<CatForSearchDto>, List<ProductForSearchDto>) Execute(string name,int catid)
        {
            var allproduct = _context.Products.AsQueryable();
            var allproduct1 = _context.Products.AsQueryable();



            var prodoct = _context.Products.
                Include(p => p.ProductImages).
                Where(p => p.Name.Contains(name) && p.CategoryId == catid).
                ToList().
                Select(p => new productSearchDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    titel = p.Description,
                    imsrc = p.ProductImages?.FirstOrDefault()?.Src,

                }).ToList();

            var cat = _context.Categories.
                Where(p => _context.Products.Where(p1 => p1.Name.Contains(name) && p1.CategoryId == catid).Select(p2 => p2.CategoryId).Contains(p.Id)).
                Include(p => p.CategoryImages).


                ToList().
                Select(p => new CatForSearchDto
                {
                    catId = p.Id,
                    Name = p.Name,
                    Images = p.CategoryImages.FirstOrDefault().Src

                }).ToList();


            var allprod = _context.Products.
                Where(p => _context.Products.Where(p1 => p1.Name.Contains(name) && p.CategoryId == catid).Select(p2 => p2.CategoryId).Contains(p.CategoryId)).
                ToList().
                Select(p =>

                new ProductForSearchDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    titel = p.Description,
                    imsrc = p.ProductImages?.Select(p => p.Src).FirstOrDefault()
                }
                ).ToList();

            return (prodoct,cat,allprod);










        }



    }


    public class productSearchDto
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? titel { get; set; }
        public string? imsrc { get; set; }

    }
        public class CatForSearchDto
    {
        public long catId { get; set; }
        public string? Name { get; set; }
        public string? Images { get; set; }
    }

    public class ProductForSearchDto
    {

        public long Id { get; set; }
        public string? Name { get; set; }
        public string? titel { get; set; }
        public string? imsrc { get; set; }
    }


}
