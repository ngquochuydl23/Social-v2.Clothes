using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothes.Commons.Exceptions
{
    public class AppException : Exception
    {
        public AppException(string msg) : base(msg)
        {
        }
    }
}
