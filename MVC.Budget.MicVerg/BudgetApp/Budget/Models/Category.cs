using System.ComponentModel.DataAnnotations;

namespace Budget.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
    }
}
