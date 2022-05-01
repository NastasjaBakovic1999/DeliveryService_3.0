using DeliveryServiceApp.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DeliveryServiceApp.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Remote(action: "IsUsernameInUse", controller: "Authentication")]
        public string Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "This field is required")]
        [Remote(action: "IsEmailValid", controller: "Authentication")]
        public string Email { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Password { get; set; }

        [Compare("Password")]
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Confirm Password")]
        public string PasswordConfirm { get; set; }

        [ValidPhone(ErrorMessage = "The phone number can start with 06 and have from 8 to 11 digits.")]
        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [ValidPostalCode(ErrorMessage = "The postal code must have 5 digits.")]
        [DisplayName("Postal Code")]
        public string PostalCode { get; set; }
    }
}
