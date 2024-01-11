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
    public record Country
    {
        private static readonly Regex ValidPatternCountry = new("^[a-zA-Z ]{1,40}$");

        public string? Value { get; }

        public Country(string? value)
        {
            if (IsValid(value))
            {
                Value = value;
            }
            else
            {
                throw new InvalidCountryException("");
            }
        }

        private static bool IsValid(string? value) => !string.IsNullOrEmpty(value) && ValidPatternCountry.IsMatch(value);

        public override string? ToString()
        {
            return Value;
        }

        public static Option<Country> TryParse(string? value)
        {
            if (IsValid(value))
            {
                return Some<Country>(new(value));
            }
            else
            {
                return None;
            }
        }
    }
}
