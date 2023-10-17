using Microsoft.EntityFrameworkCore;

namespace NotificationService
{
    public class NotificationServiceDbContext : DbContext
    {
        public NotificationServiceDbContext(DbContextOptions<NotificationServiceDbContext> options) : base(options) { }

    }
}
