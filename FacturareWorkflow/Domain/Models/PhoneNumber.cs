using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FacturareWorkflow.Domain.Exceptions;
using LanguageExt;
using static LanguageExt.Prelude;

namespace FacturareWorkflow.Domain.Models
{
    public record PhoneNumber
    {
        private static readonly Regex ValidPatternPhoneNumber = new Regex(@"^\+?[0-9\s()-]+$");

        public string? Value { get; }

        public PhoneNumber(string? value)
        {
            if (IsValid(value))
            {
                Value = value;
            }
            else
            {
                throw new InvalidPhoneNumberException("");
            }
        }

        private static bool IsValid(string? value) => !string.IsNullOrEmpty(value) && ValidPatternPhoneNumber.IsMatch(value);

        public override string? ToString()
        {
            return Value;
        }

        public static Option<PhoneNumber> TryParse(string? value)
        {
            if (IsValid(value))
            {
                return Some<PhoneNumber>(new(value));
            }
            else
            {
                return None;
            }
        }
    }
}
