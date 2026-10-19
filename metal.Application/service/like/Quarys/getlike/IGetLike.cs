using metal.Application.InterFace.Contexts;
using metal.Common;
using metal.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace metal.Application.service.like.Quarys.getlike
{

    public interface IGetLike
    {
        ResultDto<List<prod>> getlike(long? id);
    }


    public class GetLike : IGetLike
    {
        private readonly IDataBaseContext _context;
        public GetLike(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<prod>> getlike(long? id)
        {

            List<prod> result = new List<prod>();

            var user = _context.Users.Find(id);
            var pro = _context.likechildren.Select(p => p.productid).ToList();

            foreach (var item2 in pro)
            {
                var p = _context.Products
                    .Include(p => p.Category)
                    .Include(p => p.ProductImages)
                    .Where(p => p.Id == item2).FirstOrDefault();

                result.Add(new prod
                {
                    id = p.Id,
                    category = p.Category.Name,
                    name = p.Name,
                    src = p.ProductImages.FirstOrDefault().Src,
                    price = p.Price,
                });
            }
            

            return new ResultDto<List<prod>>
            {

                Data = result,
                IsSuccess = true,
            };

        }
    }

    public class prod
    {
        public long id {  get; set; }
        public string name {  get; set; }
        public int price { get; set; }
        public string category { get; set; }
        public string src { get; set; }
    }


}
