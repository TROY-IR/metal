using metal.Domain.Entities.users;
using System;
using System.Collections.Generic;
using System.Text;

namespace metal.Domain.Entities.Finance
{
    internal class RequestPay
    {
        public Guid Guid { get; set; }
        public virtual User User { get; set; }
        public string type { get; set; }
        public long UserId { get; set; }
        public int Amount { get; set; }
        public bool IsPay { get; set; }
        public DateTime? PayDate { get; set; }
        public string Authority { get; set; }
        public long RefId { get; set; } = 0;
    }
}
