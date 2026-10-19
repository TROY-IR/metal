
using metal.Domain.Entities.Products;
using metal.Domain.Entities.users;
using metal.Domain.Entities.commons;
using System;
using System.Collections.Generic;
using System.Text;

namespace metal.Domain.Entities.likedto
{
    public class Like : BaseEntity
    {
        public long Id { get; set; }
        public User user {  get; set; }
        public string name { get; set; }
        public ICollection<likechild>? likechild { get; set; }
        public int? Cunt { get; set; }
    }

    public class likechild : BaseEntity
    {
        public long Id { get; set; }
        public long likeid { get; set; }
        public Like? like { get; set; }
        public long? productid { get; set; }
        public Product? products { get; set; }

    }

}
