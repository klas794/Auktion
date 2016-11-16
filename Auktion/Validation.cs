using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Auktion
{
    public static class Validation
    {
        public static Tuple<bool, List<ValidationResult>> DbValidate(object obj)
        {
            var context = new ValidationContext(obj, null, null);
            var result = new List<ValidationResult>();
            var valid = Validator.TryValidateObject(obj, context, result, true);

            return Tuple.Create(valid, result);
        }
        public static bool Text (string text)
        {
            text = text.Trim();
            return Regex.IsMatch(text, @"^[\p{L}\s]+$");
        }
        public static bool Numbers(string numbers)
        {
            numbers = numbers.Trim();
            return Regex.IsMatch(numbers, @"^[\p{N}\s]+$");
        }
        public static bool TextAndNumbers (string text)
        {
            text = text.Trim();
            return Regex.IsMatch(text, @"^[\p{L}\p{N}\s]+$");
        }
    }
}
