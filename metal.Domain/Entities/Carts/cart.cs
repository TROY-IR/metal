using metal.Domain.Entities.commons;
using metal.Domain.Entities.Products;
using metal.Domain.Entities.users;
using System;
using System.Collections.Generic;
using System.Text;

namespace metal.Domain.Entities.Carts
{
    public class Cart : BaseEntity
    {
        public virtual User User { get; set; }
        public long? UserId { get; set; }

        public Guid BrowserId { get; set; }
        public bool Finished { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
        public ICollection<dCartItem> dCartItems { get; set; }
    }


    public class CartItem : BaseEntity
    {
        public virtual Product Product { get; set; }
        public long ProductId { get; set; }

        public int Count { get; set; }
        public int Price { get; set; }

        public virtual Cart Cart { get; set; }
        public long CartId { get; set; }

    }
    public class dCartItem : BaseEntity
    {
        public string? size { get; set; } = "22*33";
        public string? txchra { get; set; } = "merory";
        public string tozih { get; set; } = "bbbb";
        public string imsrc { get; set; } = "bbb.jpg";
        public int? Count { get; set; } = 1;
        public int? Price { get; set; }
        public virtual Cart Cart { get; set; }
        public long CartId { get; set; }

    }
    public class size
    {
        public long Id { get; set; }
        public string msize {  get; set; }
        public int ? Price { get; set; }
    }
    public class texra
    {
        public long Id { get; set; }
        public string mtexra { get; set; }
        public int? Price { get; set; }
    }
}
