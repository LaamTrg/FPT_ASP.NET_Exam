using System.ComponentModel.DataAnnotations;

namespace Product.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        public string Title { get; set; }

        public string Author { get; set; }

        public decimal PricePerDay { get; set; }
    }
}