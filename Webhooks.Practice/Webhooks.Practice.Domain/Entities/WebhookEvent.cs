namespace Webhooks.Practice.Domain.Entities
{
    public class WebhookEvent
    {
        public int Id { get; set; }
        public string EventType { get; set; } = string.Empty;
        public string Payload { get; set; } = string.Empty;
        public DateTime ReceivedAt { get; set; } = DateTime.UtcNow;
    }
}
