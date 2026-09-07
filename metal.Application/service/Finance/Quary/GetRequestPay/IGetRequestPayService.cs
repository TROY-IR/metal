using metal.Application.InterFace.Contexts;
using metal.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace metal.Application.service.Finance.Quary.GetRequestPay
{
    public interface IGetRequestPayService
    {
        ResultDto<RequestPayDto> Execute(Guid guid);
    }

    public class GetRequestPayService : IGetRequestPayService
    {
        private readonly IDataBaseContext _context;
        public GetRequestPayService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<RequestPayDto> Execute(Guid guid)
        {
            var requestPay = _context.RequestPays.Where(p => p.Guid == guid).FirstOrDefault();

            if (requestPay != null)
            {
                return new ResultDto<RequestPayDto>()
                {
                    Data = new RequestPayDto()
                    {
                        Amount = requestPay.Amount,
                    }
                };
            }
            else
            {
                throw new Exception("request pay not found");
            }
        }
    }

    public class RequestPayDto
    {
        public int Amount { get; set; }

    }
}
