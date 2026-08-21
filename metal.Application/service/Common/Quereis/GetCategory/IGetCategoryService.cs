using metal.Application.InterFace.Contexts;
using metal.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace metal.Application.service.Common.Quereis.GetCategory
{
    public interface IGetCategoryService
    {
        ResultDto<List<CategoryDto>> Execute();
    }

    public class GetCategoryService : IGetCategoryService
    {
        private readonly IDataBaseContext _context;
        public GetCategoryService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<CategoryDto>> Execute()
        {

            var category = _context.Categories
                .Include(p => p.SubCategories)
                .Where(p => p.ParentCategoryId == null)
                .ToList()
                .Select(p => new CategoryDto
                {
                    CatId = p.Id,
                    CategoryName = p.Name,
                    child = p.SubCategories.ToList().Select(p => new CategoryDto
                    {
                        CatId = p.Id,
                        CategoryName = p.Name
                    }).ToList()

                }).ToList();

            return new ResultDto<List<CategoryDto>>()
            {
                Data = category,
                IsSuccess = true,
            };
        }
    }

    public class CategoryDto
    {
        public long CatId { get; set; }
        public string CategoryName { get; set; }
        public List<CategoryDto> child { get; set; }
    }
}
