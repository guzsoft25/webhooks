using Webhooks.Practice.Application.Contracts;

namespace Webhooks.Practice.Application.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        void Begin();
        Task Commit();
        Task Rollback();
        public IProductRepository ProductRepository  { get; }
    }
}
