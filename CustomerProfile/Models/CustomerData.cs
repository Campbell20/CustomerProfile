using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CustomerProfile.Models
{
    public class CustomerData
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [DisplayName("Customer's First Name")]
        [DataType(DataType.Text)]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "The customer's first name must be between 3 and 25 characters long.")]
        public string CustomerFirstName { get; set; }

        [Required]
        [DisplayName("Customer's Last Name")]
        [DataType(DataType.Text)]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "The customer's first name must be between 3 and 25 characters long.")]
        public string CustomerLastName { get; set; }

        [Required]
        [DisplayName("Customer's Physical Address")]
        [DataType(DataType.Text)]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "The customer's address must be between 3 and 25 characters long.")]
        public string Line1 { get; set; }

        [DisplayName("Suite/Apartment")]
        [DataType(DataType.Text)]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "The customer's first name must be between 3 and 25 characters long.")]
        public string Line2 { get; set; }

        [Required]
        [DisplayName("City")]
        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The city must be between 3 and 50 characters long.")]
        public string City { get; set; }

        [Required]
        [DisplayName("State")]
        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The state must be between 3 and 50 characters long.")]
        public string State { get; set; }


        [Required]
        [DisplayName("Zipcode")]
        public int ZipCode { get; set; }

        [DisplayName("Country")]
        [DataType(DataType.Text)]
        [StringLength(3, MinimumLength = 1, ErrorMessage = "Enter the country code. ie: USA, UK, EU")]
        public string Country { get; set; }

        public int ImageId { get; set; }

        [ForeignKey("ImageId")]
        public virtual CustomerImage CustomerImages { get; set; }

    }
}