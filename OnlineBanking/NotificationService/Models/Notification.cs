using NotificationService.Enums;

namespace NotificationService.Models
{
    public class Notification
    {
        public int Id { get; set; }

        public int AccountId { get; set; }

        public NotificationType NotificationType { get; set; }
    }
}
