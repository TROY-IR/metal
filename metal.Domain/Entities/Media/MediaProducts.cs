using System;
using System.Collections.Generic;
using System.Text;

namespace metal.Domain.Entities.Media
{
    public class MediaProducts
    {
        public long id { get; set; }
        public string Name { get; set; }
        public string CName { get; set; }
        public string Titel { get; set; }
        public string src { get; set; }
        public virtual Media Media { get; set; }

    }
}
