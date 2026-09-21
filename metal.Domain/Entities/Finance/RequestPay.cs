using metal.Domain.Entities.commons;
using metal.Domain.Entities.Orders;
using metal.Domain.Entities.users;
using System;
using System.Collections.Generic;
using System.Text;

namespace metal.Domain.Entities.Finance
{
    public class RequestPay : BaseEntity
    {
        public Guid Guid { get; set; }
        public virtual User User { get; set; }
        public string? type { get; set; }
        public long UserId { get; set; }
        public int Amount { get; set; }
        public int fee { get; set; }
        public bool IsPay { get; set; }
        public string cuntry { get; set; }
        public int SendType { get; set; } = 0;
        public DateTime? PayDate { get; set; } 
        public string? Authority { get; set; }
        public long? RefId { get; set; } = 0;
        public virtual ICollection<Order>? Orders { get; set; }
    }
}
