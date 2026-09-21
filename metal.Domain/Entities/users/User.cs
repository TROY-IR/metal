using metal.Domain.Entities.commons;
using metal.Domain.Entities.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace metal.Domain.Entities.users
{
    public class User : BaseEntity
    {
        //  public long Id { get; set; }
        public string? fullName { get; set; }
        public string? Password { get; set; }
        public int? Age { get; set; }
        public string? Cuntry { get; set; }
        public string? EmailAdress { get; set; }
        public string? Psrc { get; set; }
        public bool isactive { get; set; }
        public virtual Defav? Defavs { get; set; }
        public virtual ICollection<Adresse>? adresses { get; set; }
        public ICollection<Userinrole>? Userinrole { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }

    }

    public class Defav
    {
        public long Id { get; set; }
        [ForeignKey("Id")]
        public virtual User Users { get; set; }

        public bool? Name { get; set; }
        public bool? Name1 { get; set; }
        public bool? Name2 { get; set; }
        public bool? Name3 { get; set; }
        public bool? Name4 { get; set; }
        public bool? Name5 { get; set; }
    }

    public class Adresse : BaseEntity
    {
        public virtual User Users { get; set; }
        public string Adress { get; set; }
        public long? PostCode { get; set; }
        public bool? Isactive { get; set; } = false;
    }
}
