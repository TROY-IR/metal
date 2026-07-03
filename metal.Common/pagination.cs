using System;
using System.Collections.Generic;
using System.Text;

namespace metal.Common
{
    public static class pagination
    {

        public static IEnumerable<TSource> ToPaged<TSource>(this IEnumerable<TSource> source, int page, int pagesize , out int rowsCount)
        {
            rowsCount = source.Count();
            return source.Skip((page - 1) * pagesize).Take(pagesize);
        }

    }
}
