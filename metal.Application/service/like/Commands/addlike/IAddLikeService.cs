using metal.Application.InterFace.Contexts;
using metal.Common;
using metal.Domain.Entities.likedto;
using metal.Domain.Entities.Products;
using metal.Domain.Entities.users;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace metal.Application.service.like.Commands.addlike
{
    public interface IAddLikeService
    {
        ResultDto addlikelist(bool isremove,long? uid,string name);
        ResultDto addlike(bool isremove,long? uid, long pid, string name);
    }
    public class AddLikeService : IAddLikeService
    {
        private readonly IDataBaseContext _context;
        public AddLikeService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto addlikelist(bool isremove,long? uid, string name)
        {
            if (!isremove)
            {
            var user = _context.Users.Find(uid);

            Like like = new Like()
            {
                user = user,
                name = name

            };

            _context.likes.Add(like);
            }
            else
            {
                var llist = _context.likes.Find(uid);

                _context.likes.Remove(llist);
            }

            _context.SaveChanges();

            return new ResultDto()
            {
                IsSuccess = true,
            };
        }
       public ResultDto addlike(bool isremove, long? uid, long pid, string name)
        {
            var user = _context.Users.Find(uid);
            var product = _context.Products.Where(p => p.Id == pid).FirstOrDefault();
            var likelist = _context.likes.Where(p => p.user.Id == uid).Where(p => p.name == name).FirstOrDefault();

            if (!isremove)
            {

            likechild likechild = new likechild()
            {
             //   like = likelist,
                products = product
                
            };

            _context.likechildren.Add(likechild);
            }
            else
            {
              _context.likechildren.Where(p => p.Id == likelist.Id).ToList().Select(p => p.IsRemoved = true);
            }

            _context.SaveChanges();

            return new ResultDto()
            {
                IsSuccess = true,
            };
        }
    }
    public class likedto
    {
        public User user { get; set; }
        public string name { get; set; }
        public ICollection<likechilddto>? likechild { get; set; }
        public int Cunt { get; set; }
    }

    public class likechilddto
    {
        public likedto like { get; set; }
        public long productid { get; set; }
        public ICollection<Product> products { get; set; }

    }


}
