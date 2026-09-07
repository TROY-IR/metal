using metal.Application.InterFace.Contexts;
using metal.Common;
using metal.Domain.Entities.Orders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace metal.Application.service.Orders.Commands.Quary.GetUserOrder
{
    public interface IGetOrdersForAdminService
    {
        ResultDto<List<OrdersDto>> Execute(OrderState orderState);
    }

    public class GetOrdersForAdminService : IGetOrdersForAdminService
    {
        private readonly IDataBaseContext _context;
        public GetOrdersForAdminService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<OrdersDto>> Execute(OrderState orderState)
        {
            var orders = _context.orders
                 .Include(p => p.OrderDetails)
                 .Where(p => p.OrderState == orderState)
                 .OrderByDescending(p => p.Id)
                 .ToList()
                 .Select(p => new OrdersDto
                 {
                     InsetTime = p.InsertTime,
                     OrderId = p.Id,
                     OrderState = p.OrderState,
                     ProductCount = p.OrderDetails.Count(),
                     RequestId = p.RequestPayId,
                     UserId = p.UserId,
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
        public long OrderId { get; set; }
        public DateTime InsetTime { get; set; }
        public long RequestId { get; set; }
        public long UserId { get; set; }
        public OrderState OrderState { get; set; }
        public int ProductCount { get; set; }

    }
}
