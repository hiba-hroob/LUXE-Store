namespace Webproject.Models
{
    public class WalletTransaction
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public decimal Amount { get; set; }

        public string Type { get; set; } = "Add Money";

        public string Status { get; set; } = "Completed";

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}