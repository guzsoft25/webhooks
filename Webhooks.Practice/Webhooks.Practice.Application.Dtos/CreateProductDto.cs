namespace Webhooks.Practice.Application.Dtos
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal price { get; set; }
        public string? Image { get; set; }
    }
}
