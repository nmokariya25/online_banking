namespace TransactionService.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        public int AccountId { get; set; }

        public string Description { get; set; }

        public decimal TransactionAmount { get; set; }
    }
}
