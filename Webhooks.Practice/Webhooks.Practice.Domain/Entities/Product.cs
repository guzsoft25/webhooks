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


        public Product(string name, string? description, decimal price, string? image)
        {
            Name = name;
            Description = description;
            Price = price;
            Status = Status.ACTIVE;
            Image = image;
        }


    }
}
