using metal.Application.InterFace.Contexts;
using metal.Application.service.like.Quarys.getlike;
using metal.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using static metal.Application.service.Products.Quary.GetProductForSearch.productSearchDto;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace metal.Application.service.Products.Quary.GetProductForSearch
{
    public interface IGetProductForSearch
    {
         (List<productSearchDto>,List<CatForSearchDto>) Execute(string name,int catid);
    }

    public class GetProductForSearch : IGetProductForSearch
    {
       private readonly IDataBaseContext _context;
        public GetProductForSearch(IDataBaseContext context)
        {
            _context = context;
        }

        public (List<productSearchDto>, List<CatForSearchDto>) Execute(string name,int catid)
        {

            List<productSearchDto> pro = new List<productSearchDto>();
            List<CatForSearchDto> cate = new List<CatForSearchDto>();

            List<Product> pr = new List<Product>();
            List<Category> cat = new List<Category>();

            pr = _context.Products.Where(p => p.Name == name).ToList();

            var cid = pr.Select(p => p.CategoryId).ToList();
            cat = _context.Categories.
                Where(p => cid.Contains(p.Id)).
                Include(p => p.CategoryImages).
                ToList();

            if (catid != null)
            {
                pr.AddRange( pr.Where(p => p.CategoryId == catid).ToList());
                cat.AddRange(_context.Categories.Where(p => p.Id == catid).ToList());
            }

            pro = pr.Select(p => new productSearchDto
            {
                Id = p.Id,
                Name = p.Name,
                titel = p.Description,
                imsrc = p.ProductImages?.FirstOrDefault()?.Src,

            }).ToList();



            cate = cat.Select(p => new CatForSearchDto
            {
                catId = p.Id,
                Name = p.Name,
                Images = p.CategoryImages.FirstOrDefault().Src,
                products = p.products.ToList()

            }).ToList();


            return (pro,cate);










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
        public List<Product>? products { get; set; }
    }

    public class ProductForSearchDto
    {

        public long Id { get; set; }
        public string? Name { get; set; }
        public string? titel { get; set; }
        public string? imsrc { get; set; }
    }


}
