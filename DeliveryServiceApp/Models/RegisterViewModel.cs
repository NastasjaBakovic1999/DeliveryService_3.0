using DeliveryServiceApp.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DeliveryServiceApp.Models
{
    public class RegisterViewModel
    {
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        public string Username { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        public string Password { get; set; }

        [Compare("Password")]
        [Required]
        [DisplayName("Confirm Password")]
        public string PasswordConfirm { get; set; }

        [ValidPhone]
        [Required]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [DisplayName("Postal Code")]
        public string PostalCode { get; set; }
    }
}
