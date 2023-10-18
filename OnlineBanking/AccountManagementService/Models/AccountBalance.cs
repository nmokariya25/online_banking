using AccountManagementService.Enums;

namespace AccountManagementService.Models
{
    public class AccountBalance
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public decimal Balance { get; set; }
        public BalanceType BalanceType { get; set; }
    }
}
