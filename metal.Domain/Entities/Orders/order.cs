using metal.Domain.Entities.commons;
using metal.Domain.Entities.Finance;
using metal.Domain.Entities.Products;
using metal.Domain.Entities.users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace metal.Domain.Entities.Orders
{
    public class Order : BaseEntity
    {
        public virtual User User { get; set; }
        public long UserId { get; set; }

        public virtual RequestPay RequestPay { get; set; }
        public long RequestPayId { get; set; }

        public OrderState OrderState { get; set; }

        public string? ordimgsrc { get; set; }
        public string? ordimgdetail { get; set; }

        public string Address { get; set; }
        public long postcode { get; set; }
        public string SoshialName { get; set; }
        public string SoshialAdress { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }

    public class OrderDetail : BaseEntity
    {
        public virtual Order Order { get; set; }
        public long OrderId { get; set; }

        public virtual Product Product { get; set; }
        public long ProductId { get; set; }

        public int Price { get; set; }
        public int Count { get; set; }
    }


    public enum OrderState
    {
        [Display(Name = "لغو شده")]
        Canceled = 1,
        [Display(Name = "در حالی پردازش")]
        Processing = 2,
        [Display(Name = "در حال ساخت")]
        created = 3,
        [Display(Name = "در حال ارسال")]
        sending = 4,
        [Display(Name = "در حال تحویل")]
        Delivering = 5,
        [Display(Name = "تحویل شده")]
        Delivered = 6,
    }

}
