using metal.Application.service.Products.Command.AddNewCategory;
using metal.Application.service.Products.Command.AddNewProduct;
using metal.Application.service.Products.Quary.GetProDuctForSite;
using metal.Application.service.Products.Quary.GetAllCategories;
using metal.Application.service.Products.Quary.GetCategories;
using metal.Application.service.Products.Quary.GetProductDetailForAdmin;
using metal.Application.service.Products.Quary.GetProductForAdmin;
using System;
using System.Collections.Generic;
using System.Text;
using metal.Application.service.Products.Quary.GetProductDetailForSite;

namespace metal.Application.InterFace.FacadPaerns
{
    public interface IProductFacad
    {

        AddNewCategoryService AddNewCategoryService { get; }
        IGetCategoriesService GetCategoriesService { get; }
        AddNewProductService AddNewProductService { get; }
        IGetAllCategoriesService GetAllCategoriesService { get; }

        IGetProductForAdminService GetProductForAdminService { get; }
        IGetProductDetailForAdminService GetProductDetailForAdminService { get; }

        IGetProductForSiteService GetProductForSiteService { get; }

        IGetProductDetailForSiteService GetProductDetailForSiteService { get; }
    }
}
