using metal.Application.InterFace.Contexts;
using metal.Domain.Entities.Media;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace metal.Application.service.UI.DaynamicUi.Quary.Getmedia
{
    public interface IGetMedia
    {
        List<Mediag> Execute(string pname);
    }

    public class GetMedia : IGetMedia
    {
        private readonly IDataBaseContext _context;

        public GetMedia(IDataBaseContext context)
        {
            _context = context;
        }

        public List<Mediag> Execute(string pname)
        {

            var media = _context.Medias.
               Include(p => p.MTexts).
                Include(p => p.MImages).
                Include(p => p.MProducts).
                Where(p => p.pName.Contains(pname)).
                ToList().
                Select(p => new Mediag
                {
                    id = p.id,
                    Name = p.Name,
                    pName = p.pName,

                    MTexts = p.MTexts.Select(p => new MTexts
                    {
                        id = p.id,
                        Name = p.Name,
                        Text = p.Text
                    }).ToList(),

                    MImages = p.MImages.Select(p => new MImages
                    {
                        id = p.id,
                        Name = p.Name,
                        src = p.src,
                    }).ToList(),

                    MProducts =
                    p.MProducts.Select(p1 => 
                       new MProducts
                    {
                        id=p1.id,
                        Name=p1.Name,
                        CName=p1.CName,
                        src=p1.src,
                        Titel=p1.Titel
                      
                    }).ToList()



                }).ToList();

            return media;
        }
    }







    public class Mediag
    {
        public long id { get; set; }
        public string Name { get; set; }
        public string pName { get; set; }
        public List<MTexts> MTexts { get; set; }
        public List<MImages> MImages { get; set; }
        public List<MProducts> MProducts { get; set; }
    }

    public class MImages
    {
        public long id { get; set; }
        public string Name { get; set; }
        public string src { get; set; }
        public  Media Media { get; set; }
    }

    public class MProducts
    {
        public long id { get; set; }
        public string Name { get; set; }
        public string CName { get; set; }
        public string Titel { get; set; }
        public string src { get; set; }
        public Media Media { get; set; }

    }

    public class MTexts
    {
        public long id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public Media Media { get; set; }
    }
}
