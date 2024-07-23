using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace test_sharp
{
    public class RegexValidationRule : ValidationRule
    {
        public string RegexPattern { get; set; }
        public string ErrorMessage { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string input = value as string;
            if (input == null)
                return new ValidationResult(true, null);

            if (Regex.IsMatch(input, RegexPattern))
                return new ValidationResult(true, null); 
            else
                return new ValidationResult(false, ErrorMessage);
        }
    }
}
