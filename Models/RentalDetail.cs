using System.ComponentModel.DataAnnotations;

namespace Product.Models
{
    public class RentalDetail
    {
        public int RentalDetailId { get; set; }

        [Required]
        public int RentalId { get; set; }
        public Rental Rental { get; set; }

        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int Quantity { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public decimal PricePerDay { get; set; }
    }
}