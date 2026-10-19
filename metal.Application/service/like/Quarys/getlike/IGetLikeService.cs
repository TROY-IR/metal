using metal.Application.InterFace.Contexts;
using metal.Application.service.like.Commands.addlike;
using metal.Common;
using metal.Domain.Entities.likedto;
using metal.Domain.Entities.users;
using System;
using System.Collections.Generic;
using System.Text;

namespace metal.Application.service.like.Quarys.getlike
{
    public interface IGetLikeService
    {
        ResultDto<List<Likedto>> getlikelist(long? id);
    }
    public class GetLikeService : IGetLikeService
    {
        private readonly IDataBaseContext _context;
        public GetLikeService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<Likedto>> getlikelist(long? id)
        {

            var llike = _context.likes
                .Where(p => p.user.Id == id)?
                .ToList()
                .Select(p => new Likedto
                {
                    Id = p.Id,
                    name = p.name
                }).ToList();


            return new ResultDto<List<Likedto>>()
            {
                Data = llike,
                IsSuccess = true,
            };
        }
    }

    public class Likedto
    {
        public long Id { get; set; }
        public string name { get; set; }
        public int? Cunt { get; set; }
    }
}
