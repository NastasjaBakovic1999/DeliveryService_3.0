using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DeliveryServiceApp.Models
{
    public class CalculatorViewModel : IValidatableObject
    {
        public List<AdditonalServiceViewModel> Services { get; set; } = new List<AdditonalServiceViewModel>();
        public List<SelectListItem> ShipmentWeights { get; set; }
        public List<SelectListItem> AdditionalServices { get; set; }
        public int ShipmentWeightId { get; set; }
        public double Price { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> result = new List<ValidationResult>();

            if (Services.Select(c => c.AdditionalServiceId).Distinct().Count() != Services.Count())
            {
                result.Add(new ValidationResult("You cannot add the same services."));
            }

            return result;
        }
    }
}
