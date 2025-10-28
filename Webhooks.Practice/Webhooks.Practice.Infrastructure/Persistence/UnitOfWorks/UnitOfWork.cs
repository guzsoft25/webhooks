using Microsoft.EntityFrameworkCore.Storage;
using Webhooks.Practice.Application.Contracts;
using Webhooks.Practice.Application.UnitOfWorks;
using Webhooks.Practice.Infrastructure.Exceptions;
using Webhooks.Practice.Infrastructure.Persistence.DbContexts;
using Webhooks.Practice.Infrastructure.Persistence.Repositories;

namespace Webhooks.Practice.Infrastructure.Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProductDbContext dbContext;
        private IDbContextTransaction transaction;

        public IProductRepository ProductRepository { get; private set; }


        public UnitOfWork(ProductDbContext dbContext)
        {
            this.dbContext = dbContext;
            ProductRepository = new ProductRepository(dbContext);
        }

        public void Begin()
        {
            if (transaction != null) {
                throw new InfrastructureException("Already exist an open transaction, please close first");
            }

            transaction = dbContext.Database.BeginTransaction();
        }

        public async Task Commit()
        {
            if (transaction == null){
                throw new InfrastructureException("Active transaction not detected. Begin transaction first");
            }

            try
            {
                await dbContext.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await Rollback();
            }
        }


        public async Task Rollback()
        {
            if (transaction == null) return;

            try
            {
                await transaction.RollbackAsync();
            }
            finally { 
                transaction.Dispose();
                transaction = null;
            }
        }

        public void Dispose()
        {
            if(transaction != null)
            {
                transaction.Rollback();
                transaction.Dispose();
                transaction = null;
            }

            dbContext.Dispose();
        }

       
    }
}
