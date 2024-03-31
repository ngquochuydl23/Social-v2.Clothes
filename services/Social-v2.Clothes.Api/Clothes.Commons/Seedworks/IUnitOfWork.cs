using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace Clothes.Commons.Seedworks
{
    public interface IUnitOfWork
    {
         IDbContextTransaction Begin();

         void Complete();

         void Rollback();
    }
}
