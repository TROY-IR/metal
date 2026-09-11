using metal.Application.InterFace.Contexts;
using metal.Application.service.Orders.Commands.Quary.GetUserOrder;
using metal.Common;
using metal.Domain.Entities.Products;
using metal.Domain.Entities.users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Common;
using System.Text;



namespace metal.Application.service.Profile.ProfileDetail.Quarys.GetProfileDetail
{
    public interface IGetProfileDetailService
    {
        ResultDto<ProfileDetailDto> Execute(long? Id);
        ResultDto<List<COrdersDto>> GetCOrders(long? Id);
    }

    public class GetProfileDetailService : IGetProfileDetailService
    {
        public readonly IDataBaseContext _context;
        public GetProfileDetailService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<ProfileDetailDto> Execute(long? Id)
        {
            var user = _context.Users.Find(Id);

            var ldf0 = _context.Defavs.Where(p => p.Id == Id).FirstOrDefault();

            List<DefavDto> Ldf = new List<DefavDto>();

            if (ldf0 != null) {

            Ldf = typeof(Defav).GetProperties().Where(p => p.PropertyType == typeof(bool)).
                    Where(p => (bool)p.GetValue(ldf0)!).
                    Select(p => new DefavDto
                    {
                        Name = p.Name,
                    }).ToList();
            }


            ProfileDetailDto result = new ProfileDetailDto()
            {

                Name = user.fullName,
                GmailAddress = user.EmailAdress,
                PSrc = user.Psrc,
                Adresses = user.adresses?.Select(a => new AdresseDto
                {
                    Adress = a.Adress,
                    PostCode = a.PostCode
                }).ToList(),
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
         RequestPay = new cRequestPay
         {
             RpayId = p.RequestPayId,
             Amount = p.RequestPay.Amount,
             IsPay = p.RequestPay.IsPay,
             PayDate = p.RequestPay.PayDate,
             type = p.RequestPay.type
         },
         ProductCount = p.OrderDetails.Count(),
         OrderState = (AOrderState)p.OrderState,
         ordimgsrc = p.ordimgsrc,
         ordimgdetail = p.ordimgdetail,
         Address = p.Address,
         postcode = p.postcode,
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
    }

    public class ProfileDetailDto
    {
        public string Name { get; set; }
        public string GmailAddress { get; set; }
        public string? PSrc { get; set; }
        public virtual List<AdresseDto>? Adresses { get; set; }
        public virtual List<DefavDto>? Defav { get; set; }

    }

    public class DefavDto
    {
        public string Name { get; set; }
    }

    public class AdresseDto
    {
        public string Adress { get; set; }
        public long? PostCode { get; set;}
    }


        public class COrdersDto
        {
            public long UserId { get; set; }
            public virtual cRequestPay RequestPay { get; set; }
            public int ProductCount { get; set; }

            public AOrderState OrderState { get; set; }

            public string? ordimgsrc { get; set; }
            public string? ordimgdetail { get; set; }

            public string Address { get; set; }
            public long postcode { get; set; }
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
            public DateTime? PayDate { get; set; }
        }

}

