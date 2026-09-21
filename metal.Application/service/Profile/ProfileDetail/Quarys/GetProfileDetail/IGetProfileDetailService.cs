using metal.Application.InterFace.Contexts;
using metal.Application.service.Orders.Commands.Quary.GetUserOrder;
using metal.Common;
using metal.Domain.Entities.commons;
using metal.Domain.Entities.Products;
using metal.Domain.Entities.users;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Common;
using System.Text;
using static metal.Application.service.Products.Command.AddNewCategory.AddNewCategoryService;
using static metal.Application.service.Profile.ProfileDetail.Quarys.GetProfileDetail.GetProfileDetailService;



namespace metal.Application.service.Profile.ProfileDetail.Quarys.GetProfileDetail
{
    public interface IGetProfileDetailService
    {
        ResultDto<ProfileDetailDto> Execute(long? Id);
        ResultDto<List<COrdersDto>> GetCOrders(long? Id);
        ResultDto GetCfav(long? Id,List<string> cfavs);
        ResultDto compprof(long? Id, string? adrid, string? adr, int? post, IFormFile? psrc);
        ResultDto<List<getadr>> Getadr(long? Id);
        ResultDto<List<getpos>> Getpos(long? Id);
    }

    public class GetProfileDetailService : IGetProfileDetailService
    {
        public readonly IDataBaseContext _context;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment;
        public GetProfileDetailService(IDataBaseContext context, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _environment = hostingEnvironment;
        }
        public ResultDto<ProfileDetailDto> Execute(long? Id)
        {
            var user = _context.Users.Find(Id)
                ;

            var cname = new[] { "Name", "Name1", "Name2", "Name3", "Name4", "Name5" };

            var ldf0 = _context.Defavs.Where(p => p.Id == Id).FirstOrDefault();

            List<cDefav> Ldf = new List<cDefav>();

            if (ldf0 != null)
            {

                Ldf = cname.Where(p => (bool)typeof(Defav).GetProperty(p).GetValue(ldf0)).ToList().Select(p => new cDefav { Name = p }).ToList();


            }


            ProfileDetailDto result = new ProfileDetailDto()
            {

                Name = user.fullName,
                GmailAddress = user.EmailAdress,
                PSrc = user.Psrc,
                Adresse = _context.Adresses.Where(p => p.Id == Id && p.Isactive == true)?.Select(a => new AdresseDto
                {
                    Adress = a.Adress,
                    PostCode = a.PostCode
                }).FirstOrDefault(),
                Defav = Ldf
            };



            return new ResultDto<ProfileDetailDto>()
            {
                Data = result,
                IsSuccess = true
            };
        }
        public ResultDto<List<COrdersDto>> GetCOrders(long? Id)
        {
            var user1 = _context.Users.Find(Id);


            var orders = _context.orders
     .Include(p => p.RequestPay)
     //.Include(p => p.OrderState)
     .Include(p => p.OrderDetails)
     // .Include(p => p.o)
     .OrderByDescending(p => p.Id)
     .Where(p => p.Id == Id)
     .ToList()
     .Select(p => new COrdersDto
     {
         UserId = p.UserId,
         Oid = p.Id,
         RequestPay = new cRequestPay
         {
             RpayId = p.RequestPayId,
             Amount = p.RequestPay.Amount,
             IsPay = p.RequestPay.IsPay,
             PayDate = p.RequestPay.PayDate,
             type = p.RequestPay.type,
             SendType = p.RequestPay.SendType,

         },
         ProductCount = p.OrderDetails.Count(),
         OrderState = (AOrderState)p.OrderState,
         ordimgsrc = p.ordimgsrc,
         ordimgdetail = p.ordimgdetail,
         cimgsrc = p.cimgsrc,
         cimgdetail = p.cimgdetail,
         Adresse =  new AdressDto { Adress = p.Address , PostCode = p.postcode},
         postcode = p.User.adresses.FirstOrDefault().PostCode,
         SoshialName = p.SoshialName,
         SoshialAdress = p.SoshialAdress,
         OrderDetails = p.OrderDetails.Select(p => new cOrderDetail
         {
             Count = p.Count,
             Price = p.Price,
             Product = p.Product,
             ProductId = p.ProductId
         }).ToList(),
         InsetTime = p.InsertTime,
         UpdateTime = p.UpdateTime,
     }).ToList();

            return new ResultDto<List<COrdersDto>>()
            {
                Data = orders,
                IsSuccess = true,
            };

        }
        public ResultDto GetCfav(long? Id, List<string> cfavs)
        {

            var favs = _context.Defavs.Where(p => p.Id == Id).FirstOrDefault();
            var us = _context.Users.Find(Id);

            if (favs == null)
            {
                Defav d = new Defav
                {
                    Users = us,
                    Name = false,
                    Name1 = false,
                    Name2 = false,
                    Name3 = false,
                    Name4 = false,
                    Name5 = false,

                };
                foreach (var v in cfavs)
                {
                    var fav = d.GetType().GetProperty(v);


                    if (fav != null)
                    {
                        fav.SetValue(d, true);
                    }
                }

                _context.Defavs.Add(d);

            }
            else
            {
                favs.Name = false;
                favs.Name1 = false;
                favs.Name2 = false;
                favs.Name3 = false;
                favs.Name4 = false;
                favs.Name5 = false;
                foreach (var v in cfavs)
                {
                    var fav = favs.GetType().GetProperty(v);

                    if (fav != null)
                    {
                        fav.SetValue(favs, true);
                    }
                }

            }

            _context.SaveChanges();
            return new ResultDto()
            {
                IsSuccess = true,
            };
        }
        public ResultDto compprof(long? Id,string? adrid, string? adr, int? post, IFormFile? psrc)
        {
            var user1 = _context.Users.Find(Id);
            var isadr = _context.Adresses.Find(Id);
            var adrs = _context.Adresses.Where(p => p.Id == Id);

            if(adrid != null)
            {
                foreach(var ad in adrs)
                {
                    ad.Isactive = false;
                }
                var aadr = _context.Adresses.Find(long.Parse(adrid));
                aadr.Isactive = true;
            }
            else
            {
            if (adr != null)
            {
                if (isadr == null)
                {
                    _context.Adresses.Add(new Adresse
                    {
                        Adress = adr,
                        Users = user1,
                        Isactive = true
                    });
                }
                else
                {
                    var ind = adrs.Count();
                    foreach (var (i,y) in adrs.ToList().Index())
                    {
                        if (y.Adress == null)
                        {
                                foreach (var ad in adrs)
                                {
                                    ad.Isactive = false;
                                }
                                y.Adress = adr;
                            y.Isactive = true;
                            break;
                            if (i == ind - 1) {
                                _context.Adresses.Add(new Adresse
                                {
                                    Adress = adr,
                                    Users = user1,
                                    Isactive = true
                                });
                            }
                        }
                    }
                }

            }
            if (post != null)
            {
                if (isadr == null)
                {
                    _context.Adresses.Add(new Adresse
                    {
                        PostCode = post,
                        Users = user1,
                        Isactive = true
                    });
                }
                else
                {
                    var ind1 = adrs.Count();
                    foreach (var (i,y)  in adrs.ToList().Index())
                    {
                        if(y.PostCode == null)
                        {
                                foreach (var ad in adrs)
                                {
                                    ad.Isactive = false;
                                }
                                y.PostCode = post;
                                y.Isactive = true;
                            break;
                            if (i == ind1 - 1)
                            {
                                _context.Adresses.Add(new Adresse
                                {
                                    PostCode = post,
                                    Users = user1,
                                    Isactive = true
                                });
                            }
                        }
                    }
                }
            }
            }


            if (psrc != null)
            {
                user1.Psrc = UploadFile(psrc).FileNameAddress;
            }



            _context.SaveChanges();

            return new ResultDto()
            {
                IsSuccess = true
            };



        }
        public ResultDto<List<getadr>> Getadr(long? Id)
        {
            getadr adrlist = new getadr()
            {
                Adress = "select your adress",
                Id = null
            };
            List<getadr> adrs = new List<getadr>();
            adrs.Add(adrlist);
            
             adrs.AddRange(_context.Adresses.Where(p => p.Users.Id == Id && p.Adress != null).ToList().
                Select(p => new getadr
                {
                    Id = p.Id,
                    Adress = p.Adress,
                }).ToList());



            return new ResultDto<List<getadr>>() {
            Data = adrs

            };
            
        }
        public ResultDto<List<getpos>> Getpos(long? Id)
        {
            getpos poslist = new getpos()
            {
                Postcode = 0,
                Id = null
            };
            List<getpos> poss = new List<getpos>();
            poss.Add(poslist);

            poss.AddRange(_context.Adresses.Where(p => p.Users.Id == Id && p.PostCode != null).ToList().
                Select(p => new getpos
                {
                    Id = p.Id,
                    Postcode = p.PostCode,
                }).ToList());

            return new ResultDto<List<getpos>>()
            {
                Data = poss

            };
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
    






    public class cDefav
        {
            public string? Name { get; set; }
        }

        public class ProfileDetailDto
        {
            public string Name { get; set; }
            public string GmailAddress { get; set; }
            public string? PSrc { get; set; }
            public virtual AdresseDto? Adresse { get; set; }
            public virtual List<cDefav>? Defav { get; set; }

        }

        public class DefavDto
        {
            public string Name { get; set; }
        }

        public class AdresseDto
        {
            public string Adress { get; set; }
            public long? PostCode { get; set; }
        }


        public class COrdersDto
        {
            public long Oid { get; set; }
            public long UserId { get; set; }
            public virtual cRequestPay RequestPay { get; set; }
            public int ProductCount { get; set; }

            public AOrderState OrderState { get; set; }

            public string? ordimgsrc { get; set; }
            public string? ordimgdetail { get; set; }
            public string? cimgsrc { get; set; }
            public string? cimgdetail { get; set; }

            public AdressDto Adresse { get; set; }
            public long? postcode { get; set; }
            public string SoshialName { get; set; }
            public string SoshialAdress { get; set; }
            public virtual List<cOrderDetail> OrderDetails { get; set; }

            public DateTime InsetTime { get; set; }
            public DateTime? UpdateTime { get; set; }

        }

        public class cOrderDetail
        {

            public virtual Product Product { get; set; }
            public long ProductId { get; set; }

            public int Price { get; set; }
            public int Count { get; set; }
        }

        public class cRequestPay
        {
            public string? type { get; set; }
            public long RpayId { get; set; }
            public int Amount { get; set; }
            public bool IsPay { get; set; }
            public int? SendType { get; set; }
            public DateTime? PayDate { get; set; }
        }

        public class AdressDto
        {
            public string? Adress { get; set; }
            public long? PostCode { get; set; }
        }
        public class getpos
        {
            public long? Id { get; set; }
            public long? Postcode { get; set; }
        }
        public class getadr
        {
            public long? Id { get; set; }
            public string? Adress { get; set; }
        }
    }
}

