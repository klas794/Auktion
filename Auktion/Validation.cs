using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Auktion
{
    public static class Validation
    {
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
