using System;
using System.Collections.Generic;
using System.Text;

namespace metal.Domain.Entities.Media
{
    public class Media
    {
        public long id { get; set; }
        public string Name { get; set; }
        public string pName { get; set; }
        public virtual ICollection<MediaTexts> MTexts { get; set; }
        public virtual ICollection<MediaImages> MImages { get; set; }
        public virtual ICollection<MediaProducts> MProducts { get; set; }
    }
}
