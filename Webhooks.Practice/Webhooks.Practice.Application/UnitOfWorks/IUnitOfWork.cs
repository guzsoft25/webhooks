using Webhooks.Practice.Application.Contracts;

namespace Webhooks.Practice.Application.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        void Begin();
        Task Commit();
        void RollBack();
        public IProductRepository ProductRepository  { get; set; }
    }
}
