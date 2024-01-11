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
    public record LastName
    {
        private static readonly Regex ValidPatternLastName = new("^[a-zA-Z ]{1,40}$");

        public string? Value { get; }

        public LastName(string? value)
        {
            if (IsValid(value))
            {
                Value = value;
            }
            else
            {
                throw new InvalidLastNameException("");
            }
        }

        private static bool IsValid(string? value) => !string.IsNullOrEmpty(value) && ValidPatternLastName.IsMatch(value);

        public override string? ToString()
        {
            return Value;
        }

        public static Option<LastName> TryParse(string? value)
        {
            if (IsValid(value))
            {
                return Some<LastName>(new(value));
            }
            else
            {
                return None;
            }
        }
    }
}
