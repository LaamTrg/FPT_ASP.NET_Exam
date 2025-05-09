using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Product.Models
{
    public class Rental
    {
        public int RentalId { get; set; }

        [Required]
        public DateTime RentalDate { get; set; }

        [Required]
        public DateTime ReturnDate { get; set; }

        [Required]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public List<RentalDetail> RentalDetails { get; set; }
    }
}