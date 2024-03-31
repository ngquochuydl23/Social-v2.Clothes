using Clothes.Commons.Seedworks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothes.Commons
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private bool _disposed;
        private readonly DbContext _appDbContext;
        private IDbContextTransaction _dbTransaction;
        public UnitOfWork(DbContext appDbContext)
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
            }
            catch (Exception ex)
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
