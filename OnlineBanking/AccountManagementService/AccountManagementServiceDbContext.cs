using AccountManagementService.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountManagementService
{
    public class AccountManagementServiceDbContext : DbContext
    {
        public AccountManagementServiceDbContext(DbContextOptions<AccountManagementServiceDbContext> options) : base(options) { }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<AccountBalance> AccountBalances { get; set; }
    }
}
