using metal.Domain.Entities.commons;
using System;
using System.Collections.Generic;
using System.Text;

namespace metal.Domain.Entities.HomePages
{
    public class Slider:BaseEntity
    {
        public string imsrc {get; set;}
        public string vsrc { get; set; }
        public string link { get; set; }
        public int Click { get; set; }
    }
}
