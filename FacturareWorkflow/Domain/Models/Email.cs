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
    public record Email
    {
        private static readonly Regex ValidPatternEmail = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");

        public string? Value { get; }

        public Email(string? value)
        {
            if (IsValid(value))
            {
                Value = value;
            }
            else
            {
                throw new InvalidEmailException("");
            }
        }

        private static bool IsValid(string? value) => !string.IsNullOrEmpty(value) && ValidPatternEmail.IsMatch(value);

        public override string? ToString()
        {
            return Value;
        }

        public static Option<Email> TryParse(string? value)
        {
            if (IsValid(value))
            {
                return Some<Email>(new(value));
            }
            else
            {
                return None;
            }
        }
    }
}
