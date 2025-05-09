using System;
using System.ComponentModel.DataAnnotations;

namespace Product.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required]
        public string FullName { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        public DateTime RegisterDate { get; set; }
    }
}