using Microsoft.EntityFrameworkCore.Storage;

namespace Social_v2.Clothes.Api.Infrastructure
{
    public interface IUnitOfWork
    {
        public IDbContextTransaction Begin();

        public void Complete();

        public void Rollback();
    }
}
