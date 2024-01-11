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
    public record City
    {
        private static readonly Regex ValidPatternCity = new("^[a-zA-Z ]{1,40}$");

        public string? Value { get; }

        public City(string? value)
        {
            if (IsValid(value))
            {
                Value = value;
            }
            else
            {
                throw new InvalidCityException("");
            }
        }

        private static bool IsValid(string? value) => !string.IsNullOrEmpty(value) && ValidPatternCity.IsMatch(value);

        public override string? ToString()
        {
            return Value;
        }

        public static Option<City> TryParse(string? value)
        {
            if (IsValid(value))
            {
                return Some<City>(new(value));
            }
            else
            {
                return None;
            }
        }

        internal static object TryParse(object city)
        {
            throw new NotImplementedException();
        }
    }
}
