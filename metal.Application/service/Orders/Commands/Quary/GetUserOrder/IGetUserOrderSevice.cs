using metal.Application.InterFace.Contexts;
using metal.Common;
using metal.Domain.Entities.Orders;
//using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using static metal.Application.service.Products.Command.AddNewCategory.AddNewCategoryService;

namespace metal.Application.service.Orders.Commands.Quary.GetUserOrder
{
    public interface IGetUserOrdersService
    {
        ResultDto<List<GetUserOrdersDto>> Execute(long UserId);
        ResultDto AddOrderimg(long? ordId, string? tozih, IFormFile? psrc);
    }


    public class GetUserOrdersService : IGetUserOrdersService
    {
        private readonly IDataBaseContext _context;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment;
        public GetUserOrdersService(IDataBaseContext context, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _environment = hostingEnvironment;
        }

        public ResultDto<List<GetUserOrdersDto>> Execute(long UserId)
        {
            var orders = _context.orders
                .Include(p => p.OrderDetails)
                .ThenInclude(p => p.Product)
                .Where(p => p.UserId == UserId)
                .OrderByDescending(p => p.Id).ToList().Select(p => new GetUserOrdersDto
                {
                    OrderId = p.Id,
                    OrderState = p.OrderState,
                    RequestPayId = p.RequestPayId,
                    OrderDetails = p.OrderDetails.Select(o => new OrderDetailsDto
                    {
                        Count = o.Count,
                        OrderDetailId = o.Id,
                        Price = o.Price,
                        ProductId = o.ProductId,
                        ProductName = o.Product.Name,
                    }).ToList(),
                }).ToList();

            return new ResultDto<List<GetUserOrdersDto>>()
            {
                Data = orders,
                IsSuccess = true,
            };


        }
        public ResultDto AddOrderimg(long? ordId, string? tozih, IFormFile? psrc)
        {
            var uorder = _context.orders.Find(ordId);

            if (tozih != null)
            {
                uorder.cimgdetail = tozih;
                _context.SaveChanges();
            }

            if (psrc != null)
            {
                var user = _context.Users.Find(ordId);
                foreach (var item in user.Orders)
                {
                    if (item.cimgdetail != null && item.cimgsrc == null)
                    {
                        uorder.cimgsrc = UploadFile(psrc).FileNameAddress;
                    }
                    _context.SaveChanges();
                }
            }

                return new ResultDto
                {
                    IsSuccess = true,
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
}
    



   public class GetUserOrdersDto
    {
        public long OrderId { get; set; }
        public OrderState OrderState { get; set; }
        public long RequestPayId { get; set; }
        public List<OrderDetailsDto> OrderDetails { get; set; }
    }

    public class OrderDetailsDto
    {
        public long OrderDetailId { get; set; }
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
    }
}
