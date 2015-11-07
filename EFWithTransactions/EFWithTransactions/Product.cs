using System.ComponentModel.DataAnnotations.Schema;

namespace EFWithTransactions
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
    }
}