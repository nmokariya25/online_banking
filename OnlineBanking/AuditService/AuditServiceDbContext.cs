using Microsoft.EntityFrameworkCore;

namespace AuditService
{
    public class AuditServiceDbContext : DbContext
    {
        public AuditServiceDbContext(DbContextOptions<AuditServiceDbContext> options) : base(options) { }

    }
}
