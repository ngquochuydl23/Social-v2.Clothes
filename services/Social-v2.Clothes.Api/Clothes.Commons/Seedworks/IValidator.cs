using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothes.Commons.Seedworks
{
    public interface IValidator<TDto, IValid> where TDto : class where IValid : class
    {
        Boolean Validate(TDto dto);
    }
}
