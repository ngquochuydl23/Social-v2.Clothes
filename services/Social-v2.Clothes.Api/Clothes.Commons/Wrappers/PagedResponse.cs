using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothes.Commons.Wrappers
{
    public class PagedResponse<T>
    {
        public int Offset { get; set; }

        public int Limit { get; set; }

        public long Total { get; set; }

        public ICollection<T> Result { get; set; } = new List<T>();

        public PagedResponse() { }
        public PagedResponse(int offset, int limit, long total, ICollection<T> result)
        {
            Offset = offset;
            Limit = limit;
            Total = total;
            Result = result;
        }
    }
}
