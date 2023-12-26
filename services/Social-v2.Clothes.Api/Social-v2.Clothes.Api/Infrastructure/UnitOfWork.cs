using Microsoft.EntityFrameworkCore.Storage;

namespace Social_v2.Clothes.Api.Infrastructure
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private bool _disposed;
        private readonly ClothesDbContext _appDbContext;
        private IDbContextTransaction _dbTransaction;
        public UnitOfWork(ClothesDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IDbContextTransaction Begin()
        {
            _dbTransaction = _appDbContext.Database.BeginTransaction();
            return _dbTransaction;
        }

        public void Complete()
        {
            
            try
            {
                _dbTransaction.Commit();
            } catch(Exception ex)
            {

                Rollback();
                throw ex;
            }
        }

        public void Rollback()
        {
            _dbTransaction.Rollback();
            _dbTransaction.Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    _appDbContext.Dispose();
            _disposed = true;
        }
    }
}
