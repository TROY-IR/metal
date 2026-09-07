using metal.Domain.Entities.commons;
using metal.Domain.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace metal.Domain.Entities.users
{
    public class User : BaseEntity
    {
      //  public long Id { get; set; }
        public string fullName { get; set; }
        public string Password { get; set; }
        public long? Adress { get; set; }
        public int Age { get; set; }
        public string? Cuntry { get; set; }
        public string EmailAdress { get; set; }
        public int? PostCode { get; set; }
        public bool isactive { get; set; }
        public ICollection<Userinrole> Userinrole { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

    }
}
