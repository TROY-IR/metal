using metal.Domain.Entities.commons;
using System;
using System.Collections.Generic;
using System.Text;

namespace metal.Domain.Entities.Products
{
    public class Category : BaseEntity

    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long Imsrc { get; set; }
        public virtual Category ParentCategory { get; set; }
        public long? ParentCategoryId { get; set; }


        public virtual ICollection<CategoryImages> CategoryImages { get; set; }
        //برای نمایش زیر دسته های هر گروه
        public virtual ICollection<Category> SubCategories { get; set; }
        public ICollection<Product> products { get; set; }

    }
}
