using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace DeliveryServiceApp.DataAnnotations
{
    public class ValidPostalCode : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                if (!Regex.IsMatch(value.ToString(), "^[0-9]{0,5}$"))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
