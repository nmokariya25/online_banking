using Microsoft.EntityFrameworkCore;
using NotificationService.Models;

namespace NotificationService
{
    public class NotificationServiceDbContext : DbContext
    {
        public NotificationServiceDbContext(DbContextOptions<NotificationServiceDbContext> options) : base(options) { }

        public DbSet<Notification> Notifications { get; set; }
    }
}
