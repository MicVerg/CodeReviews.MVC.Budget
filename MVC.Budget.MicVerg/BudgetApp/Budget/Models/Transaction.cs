using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Budget.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Please select a transaction type.")]
        [EnumDataType(typeof(TransactionType))]
        public TransactionType TransactionType { get; set; }


        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        [NotMapped]
        public string CategoryName => Category?.Description;

        public Category Category { get; set; }
    }
    public enum TransactionType
    {
        [Display(Name = "Income")]
        Income,
        [Display(Name = "Expense")]
        Expense
    }
}
