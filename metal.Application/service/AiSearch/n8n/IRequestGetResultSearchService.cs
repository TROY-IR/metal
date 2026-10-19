using metal.Application.InterFace.Contexts;
using metal.Application.service.Products.Quary.GetProductForSearch;
using metal.Common;
using metal.Domain.Entities.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;

namespace metal.Application.service.AiSearch.n8n
{
    public interface IRequestGetResultSearchService
    {
        Task<ResultDto<(List<productSearchDto>, List<CatForSearchDto>)>> n8nrequest(long? catid,string? ser, IFormFile? img,CancellationToken cancellationToken = default);
    }

    public class RequestGetResultSearchService : IRequestGetResultSearchService
    {
        private readonly HttpClient _httpClient;
        private readonly IDataBaseContext _context;
        private readonly IConfiguration _configuration;
        public RequestGetResultSearchService(
            HttpClient httpClient,
            IConfiguration configuration,
            IDataBaseContext dataBaseContext)
        {
            _context = dataBaseContext;
             _httpClient = httpClient;
            _configuration = configuration;
        }
        public async Task<ResultDto<(List<productSearchDto>, List<CatForSearchDto>)>> n8nrequest(long? catid,string? ser, IFormFile? img, CancellationToken cancellationToken = default)
        {

            var res = new HttpRequestMessage(
                HttpMethod.Post,
                _configuration["n8n:WebhookUrl"]
                );
            res.Headers.Add("X-API-Key", _configuration["n8n:ApiKey"]);

            res.Content = JsonContent.Create( new {ser});

            using var respon = await _httpClient.SendAsync(
                res,
                cancellationToken
                );

            respon.EnsureSuccessStatusCode();

            var resbody = await respon.Content.ReadFromJsonAsync<List<n8nRDto>>(
                cancellationToken:cancellationToken
                );


            List<productSearchDto> pro = new List<productSearchDto>();
            List<CatForSearchDto> cate = new List<CatForSearchDto>();

            if (resbody != null)
            {

                List<Product> pr = new List<Product>();
                List<Category> cat = new List<Category>();

                foreach(var p  in resbody)
                {
                    pr.Add(_context.Products.Find(p.id));
                }

                var cid = pr.Select(p => p.CategoryId).ToList();
                cat = _context.Categories.
                    Where(p => cid.Contains(p.Id)).
                    Include(p => p.CategoryImages).
                    ToList();

                if (catid != null)
                {
                    pr = pr.Where(p => p.CategoryId == catid).ToList();
                    cat = _context.Categories.Where(p => p.Id == catid).ToList();
                }
                
               pro = pr.Select(p => new productSearchDto
                        {
                            Id = p.Id,
                            Name = p.Name,
                            titel = p.Description,
                            imsrc = p.ProductImages?.FirstOrDefault()?.Src,

                        }).ToList();
                


                  cate = cat.Select(p => new CatForSearchDto
                    {
                        catId = p.Id,
                        Name = p.Name,
                        Images = p.CategoryImages?.FirstOrDefault()?.Src,
                        products = p.products.ToList()

                    }).ToList();


            }

  //      Console.WriteLine("ffffffffffff====="+ resbody );



            return new ResultDto<(List<productSearchDto>, List<CatForSearchDto>)>
            {
                Data = (pro, cate),
                IsSuccess = true,
            };
        }
    }

    public class n8nRDto
    {
  //      public string? discription {  get; set; }
        public long? id {  get; set; }
    }

}
