using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace DeliveryServiceApp.DataAnnotations
{
    public class ValidShipmentCode : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                if (!Regex.IsMatch(value.ToString(), "^[a-zA-Z0-9]{11,11}$"))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
