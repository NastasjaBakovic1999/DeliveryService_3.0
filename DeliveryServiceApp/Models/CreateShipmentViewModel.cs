using DeliveryServiceApp.DataAnnotations;
using DeliveryServiceDomain;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DeliveryServiceApp.Models
{
    public class CreateShipmentViewModel : IValidatableObject
    {

        [DisplayName("Shipment Content")]
        [Required(ErrorMessage = "This field is required")]
        public string ShipmentContent { get; set; }

        [DisplayName("Sending City")]
        [Required(ErrorMessage = "This field is required")]
        public string SendingCity { get; set; }

        [DisplayName("Sending Address")]
        [Required(ErrorMessage = "This field is required")]
        public string SendingAddress { get; set; }

        [DisplayName("Sending Postal Code")]
        [Required(ErrorMessage = "This field is required")]
        [ValidPostalCode(ErrorMessage = "The postal code must have 5 digits.")]
        public string SendingPostalCode { get; set; }

        [DisplayName("Receiving City")]
        [Required(ErrorMessage = "This field is required")]
        public string ReceivingCity { get; set; }

        [DisplayName("Receiving Address")]
        [Required(ErrorMessage = "This field is required")]
        public string ReceivingAddress { get; set; }

        [DisplayName("Receiving Postal Code")]
        [Required(ErrorMessage = "This field is required")]
        [ValidPostalCode(ErrorMessage = "The postal code must have 5 digits.")]
        public string ReceivingPostalCode { get; set; }

        [DisplayName("Contact Person Name")]
        [Required(ErrorMessage = "This field is required")]
        public string ContactPersonName { get; set; }

        [DisplayName("Contact Person Phone")]
        [Required(ErrorMessage = "This field is required")]
        [ValidPhone(ErrorMessage = "The phone number can start with 06 and have from 8 to 11 digits.")]
        public string ContactPersonPhone { get; set; }

        [DisplayName("Shipment Weight")]
        [Required(ErrorMessage = "This field is required")]
        public int ShipmentWeightId { get; set; }
        public string Note { get; set; }
        public List<AdditonalServiceViewModel> Services { get; set; } = new List<AdditonalServiceViewModel>();

        public List<SelectListItem> ShipmentWeights { get; set; }
        public List<SelectListItem> AdditionalServices { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> result = new List<ValidationResult>();

            if(Services.Select(c => c.AdditionalServiceId).Distinct().Count() != Services.Count())
            {
                result.Add(new ValidationResult("You cannot add the same services."));
            }

            return result;
        }
    }
}
