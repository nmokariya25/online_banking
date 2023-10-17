using Microsoft.EntityFrameworkCore;

namespace FraudDetectionService
{
    public class FraudDetectionServiceDbContext : DbContext
    {
        public FraudDetectionServiceDbContext(DbContextOptions<FraudDetectionServiceDbContext> options) : base(options) { }

    }
}
