using metal.Application.InterFace.Contexts;
using metal.Common;
using metal.Domain.Entities.Finance;
using metal.Domain.Entities.Orders;
using metal.Domain.Entities.users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace metal.Application.service.Orders.Commands.AddNewOrder
{
    public interface IAddNewOrderService
    {
        ResultDto Execute(RequestAddNewOrderSericeDto request);
    }

    public class AddNewOrderService : IAddNewOrderService
    {
        private readonly IDataBaseContext _context;
        public AddNewOrderService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto Execute(RequestAddNewOrderSericeDto request)
        {
            var user = _context.Users.Find(request.UserId);
            var requestPay = _context.RequestPays.Find(request.RequestPayId);
            var cadress = _context.Adresses.Find(long.Parse(request.Address));
            var cart = _context.carts
                .Include(p => p.CartItems)
                .ThenInclude(p => p.Product)
                .Where(p => p.Id == request.CartId)
                .FirstOrDefault();

            requestPay.IsPay = true;
            requestPay.PayDate = DateTime.Now;
            requestPay.Authority = request.authority;


            cart.Finished = true;





            Order order = new Order()
            {
                Address = cadress.Adress,
                postcode = cadress.PostCode,
                OrderState = OrderState.Processing,
                RequestPay = requestPay,
                User = user,
                SoshialName = request.SoshialName,
                SoshialAdress = request.SoshialAdress,
                RequestPayId = requestPay.Id

            };


            List<OrderDetail> orderDetails = new List<OrderDetail>();
            foreach (var item in cart.CartItems)
            {

                OrderDetail orderDetail = new OrderDetail()
                {
                    Count = item.Count,
                    Order = order,
                    Price = item.Product.Price,
                    Product = item.Product,
                    OrderId = user.Id,
                    ProductId = item.ProductId,
                };
                orderDetails.Add(orderDetail);
            }

            order.OrderDetails = orderDetails;
            _context.orders.Add(order);

            _context.orderDetails.AddRange(orderDetails);

            _context.SaveChanges();

            return new ResultDto()
            {
                IsSuccess = true,
                Message = "",
            };
        }
    }
    public class RequestAddNewOrderSericeDto
    {
        public long CartId { get; set; }
        public long RequestPayId { get; set; }
        public long UserId { get; set; }
        public string? authority { get; set; }
        public string Address { get; set; }
        public long? postcode { get; set; }
        public string SoshialName { get; set; }
        public string SoshialAdress { get; set; }

    }
}