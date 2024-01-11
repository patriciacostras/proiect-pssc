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
    public record ZipCode
    {
        private static readonly Regex ValidPatternZipCode = new Regex(@"^\d{6}$");

        public string? Value { get; }

        public ZipCode(string? value)
        {
            if (IsValid(value))
            {
                Value = value;
            }
            else
            {
                throw new InvalidZipCodeException("");
            }
        }

        private static bool IsValid(string? value) => !string.IsNullOrEmpty(value) && ValidPatternZipCode.IsMatch(value);

        public override string? ToString()
        {
            return Value;
        }

        public static Option<ZipCode> TryParse(string? value)
        {
            if (IsValid(value))
            {
                return Some<ZipCode>(new(value));
            }
            else
            {
                return None;
            }
        }
    }
}
