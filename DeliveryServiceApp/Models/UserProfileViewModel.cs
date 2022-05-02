using DeliveryServiceApp.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DeliveryServiceApp.Models
{
    public class UserProfileViewModel
    {
        public int Id { get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessage = "This field is required")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "This field is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [ValidEmailAddress(ErrorMessage = "The email address is not in the correct format!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Phone Number")]
        [ValidPhone(ErrorMessage = "The phone number can start with 06 and have from 8 to 11 digits.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Address { get; set; }

        [ValidPostalCode(ErrorMessage = "The postal code must have 5 digits.")]
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Postal Code")]
        public string PostalCode { get; set; }

        [DisplayName("Date Of Employment")]
        [BindProperty, DataType(DataType.Date)]
        public DateTime DateOfEmployment { get; set; }
    }
}
