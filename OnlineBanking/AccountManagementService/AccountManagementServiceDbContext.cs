using Microsoft.EntityFrameworkCore;

namespace AccountManagementService
{
    public class AccountManagementServiceDbContext : DbContext
    {
        public AccountManagementServiceDbContext(DbContextOptions<AccountManagementServiceDbContext> options) : base(options) { }

    }
}
