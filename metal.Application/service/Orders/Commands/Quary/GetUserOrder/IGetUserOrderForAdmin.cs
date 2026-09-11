using metal.Application.InterFace.Contexts;
using metal.Common;
using metal.Domain.Entities.commons;
using metal.Domain.Entities.Finance;
using metal.Domain.Entities.Orders;
using metal.Domain.Entities.Products;
using metal.Domain.Entities.users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace metal.Application.service.Orders.Commands.Quary.GetUserOrder
{
    public interface IGetOrdersForAdminService
    {
        ResultDto<List<OrdersDto>> Execute();
    }

    public class GetOrdersForAdminService : IGetOrdersForAdminService
    {
        private readonly IDataBaseContext _context;
        public GetOrdersForAdminService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<OrdersDto>> Execute()
        {
            var orders = _context.orders
                 .Include(p => p.RequestPay)
                 //.Include(p => p.OrderState)
                 .Include(p => p.OrderDetails)
                // .Include(p => p.o)
                 .OrderByDescending(p => p.Id)
                 .ToList()
                 .Select(p => new OrdersDto
                 {
                     UserId = p.UserId,
                     RequestPay = new ARequestPay
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
                     OrderDetails = p.OrderDetails.Select( p => new AOrderDetail
                     {
                         Count = p.Count,
                         Price = p.Price,
                         Product = p.Product,
                         ProductId = p.ProductId
                     }).ToList(),
                     InsetTime = p.InsertTime,
                     UpdateTime = p.UpdateTime,
                 }).ToList();

            return new ResultDto<List<OrdersDto>>()
            {
                Data = orders,
                IsSuccess = true,
            };
        }
    }
    public class OrdersDto
    {
        public long UserId { get; set; }
        public virtual ARequestPay RequestPay { get; set; }
        public int ProductCount { get; set; }

        public AOrderState OrderState { get; set; }

        public string? ordimgsrc { get; set; }
        public string? ordimgdetail { get; set; }

        public string Address { get; set; }
        public long postcode { get; set; }
        public string SoshialName { get; set; }
        public string SoshialAdress { get; set; }
        public virtual List<AOrderDetail> OrderDetails { get; set; }

        public DateTime InsetTime { get; set; } 
        public DateTime? UpdateTime { get; set; }

    }

    public class AOrderDetail
    {

        public virtual Product Product { get; set; }
        public long ProductId { get; set; }

        public int Price { get; set; }
        public int Count { get; set; }
    }


    public enum AOrderState
    {
        [Display(Name = "لغو شده")]
        Processing = 1,
        [Display(Name = "در حالی پردازش")]
        Canceled = 2,
        [Display(Name = "در حال ساخت")]
        created = 3,
        [Display(Name = "در حال ارسال")]
        sending = 4,
        [Display(Name = "در حال تحویل")]
        Delivering = 5,
        [Display(Name = "تحویل شده")]
        Delivered = 6,
    }

    public class ARequestPay 
    {
        public string? type { get; set; }
        public long RpayId { get; set; }
        public int Amount { get; set; }
        public bool IsPay { get; set; }
        public DateTime? PayDate { get; set; }
    }




}
