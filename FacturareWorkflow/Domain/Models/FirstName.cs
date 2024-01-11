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
    public record FirstName
    {
        private static readonly Regex ValidPatternFirstName = new("^[a-zA-Z ]{1,40}$");

        public string? Value { get; }

        public FirstName(string? value)
        {
            if (IsValid(value))
            {
                Value = value;
            }
            else
            {
                throw new InvalidFirstNameException("");
            }
        }

        private static bool IsValid(string? value) => !string.IsNullOrEmpty(value) && ValidPatternFirstName.IsMatch(value);

        public override string? ToString()
        {
            return Value;
        }

        public static Option<FirstName> TryParse(string? value)
        {
            if (IsValid(value))
            {
                return Some<FirstName>(new(value));
            }
            else
            {
                return None;
            }
        }
    }
}
