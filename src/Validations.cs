using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace TripAdvisor
{
    public class PhoneNumberValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is string phoneNumber)
            {
                var regex = new Regex(@"^[0-9+\- ]+$");
                if (!regex.IsMatch(phoneNumber))
                    return new ValidationResult(false, "Nieprawidłowy numer telefonu. Dozwolone znaki to '+', '-', ' ' i cyfry.");
                return ValidationResult.ValidResult;
            }
            throw new ArgumentException("The parameter 'value' should be of type 'string'.");
        }
    }
    public class EmailValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is string email)
            {
                var regex = new Regex(@"^.+@.+\..+$");
                if (!regex.IsMatch(email))
                    return new ValidationResult(false, "Nieprawidłowy adres email. Powinien zawierać znaki '@' i '.' oraz '.' musi być po '@'");
                return ValidationResult.ValidResult;
            }
            throw new ArgumentException("The parameter 'value' should be of type 'string'.");
        }
    }
}
