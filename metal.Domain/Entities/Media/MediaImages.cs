using System;
using System.Collections.Generic;
using System.Text;

namespace metal.Domain.Entities.Media
{
    public class MediaImages
    {
        public long id { get; set; }
        public string Name { get; set; }
        public string src { get; set; }
        public virtual Media Media { get; set; }
    }
}
