using Microsoft.EntityFrameworkCore;
using TransactionService.Models;

namespace TransactionService
{
    public class TransactionServiceDbContext : DbContext
    {
        public TransactionServiceDbContext(DbContextOptions<TransactionServiceDbContext> options) : base(options) { }

        public DbSet<Transaction> Transactions { get; set; }
    }
}
