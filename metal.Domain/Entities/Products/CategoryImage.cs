using metal.Domain.Entities.commons;
using System;
using System.Collections.Generic;
using System.Text;

namespace metal.Domain.Entities.Products
{
    public class CategoryImages : BaseEntity
    {
        public virtual Category Category { get; set; }
        public long CatId { get; set; }
        public string Src { get; set; }
    }
}
