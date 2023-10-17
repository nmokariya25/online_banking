using Microsoft.EntityFrameworkCore;

namespace TransactionService
{
    public class TransactionServiceDbContext : DbContext
    {
        public TransactionServiceDbContext(DbContextOptions<TransactionServiceDbContext> options) : base(options) { }

    }
}
