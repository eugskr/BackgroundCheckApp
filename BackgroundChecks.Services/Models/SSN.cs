using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BackgroundChecks.Services.Models
{
    public struct SSN
    {
        public const string ValidationRegEx = @"^\d{9}$";
        public string Number { get; private set; }
        public static SSN FromString(string ssnNumber)
        {
            if (!Regex.IsMatch(ssnNumber, ValidationRegEx))
                throw new ArgumentException(nameof(ssnNumber));
            return new SSN { Number = ssnNumber };
        }
        public override string ToString()
        {
            return ToStringMask(Number);
        }
        private static string ToStringMask(string input)
        {
            var inputLong = input.ToString();
            string mask = new string('*', inputLong.Length - 4);
            string digits = inputLong.Substring(inputLong.Length - 4, 4);
            return mask + digits;
        }
    }
}
