using System;
using System.Collections.Generic;
using System.Text;

namespace metal.Domain.Entities.Media
{
    public class MediaTexts
    {
        public long id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public virtual Media Media { get; set; }
    }
}
