using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace DeliveryServiceApp.DataAnnotations
{
    public class ValidEmailAddress : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                if (!Regex.IsMatch(value.ToString(), @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                {
                     return false;
                }
            }

            return true;
        }
    }
}