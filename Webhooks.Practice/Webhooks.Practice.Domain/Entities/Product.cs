using Webhooks.Practice.Domain.Enums;

namespace Webhooks.Practice.Domain.Entities
{
    public class Product
    {
        public int ProductId { get; private set; }
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public decimal Price { get; private set; }
        public Status Status { get; private set; } = Status.ACTIVE;
        public string? Image { get; private set; }
        public DateTime?  UpdateAt { get; private set; }

        
    }
}
