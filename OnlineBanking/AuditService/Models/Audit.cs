namespace AuditService.Models
{
    public class Audit
    {
        public int Id { get; set; }

        public string EventName { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
