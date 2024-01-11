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
    public record Street
    {
        private static readonly Regex ValidPatternStreet = new("^[a-zA-z][a-zA-Z0-9]*$");

        public string? Value { get; }

        public Street(string? value)
        {
            if (IsValid(value))
            {
                Value = value;
            }
            else
            {
                throw new InvalidStreetException("");
            }
        }

        private static bool IsValid(string? value) => !string.IsNullOrEmpty(value) && ValidPatternStreet.IsMatch(value);

        public override string? ToString()
        {
            return Value;
        }

        public static Option<Street> TryParse(string? value)
        {
            if (IsValid(value))
            {
                return Some<Street>(new(value));
            }
            else
            {
                return None;
            }
        }
    }
}
