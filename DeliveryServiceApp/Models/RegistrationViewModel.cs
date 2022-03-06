using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryServiceApp.Models
{
    public class RegistrationViewModel
    {
        [Required(ErrorMessage ="First name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Username name is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Entered phone number is not valid")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage ="Email address is required")]
        [EmailAddress(ErrorMessage ="Entered email address is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Password is required")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&].{8,}$", ErrorMessage = "The password must have at least one uppercase letter, number and special character and must contain at least eight characters.")]
        public string Password { get; set; }

        [Required(ErrorMessage ="Confirm password is required")]
        [Compare("Password")]
        [NotMapped]
        public string ConfirmPassword { get; set; }

    }
}
