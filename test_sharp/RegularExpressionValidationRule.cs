using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace test_sharp
{
    public class RegularExpressionValidationRule : ValidationRule
    {
        public string Pattern { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string text = value as string;
            if (text != null && !Regex.IsMatch(text, Pattern))
            {
                return new ValidationResult(false, "The input is not in the correct format.");
            }
            return ValidationResult.ValidResult;
        }
    }
}
