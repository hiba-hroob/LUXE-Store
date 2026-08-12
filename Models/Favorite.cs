using System.ComponentModel.DataAnnotations;

namespace Webproject.Models
{
    public class Favorite
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        public int ProductId { get; set; }

        public User User { get; set; }

        public Product Product { get; set; }
    }
}