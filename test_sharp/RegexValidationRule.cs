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

        public bool Validate(string pattern, string input, int maxLength, bool checkEmpty = true)
        {   
            if (!checkEmpty && string.IsNullOrEmpty(input))
                return true;

            if (input == null || input.Length > maxLength)
                return false;

            if (string.IsNullOrEmpty(pattern))
                return true;

            

            return Regex.IsMatch(input, pattern);
        }
    }
}
