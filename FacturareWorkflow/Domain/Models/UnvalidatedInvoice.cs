using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturareWorkflow.Domain.Models
{
    public class UnvalidatedInvoice
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }

        // Alte proprietăți specifice facturii nevalidate

        public UnvalidatedInvoice(string firstName, string lastName, string city, string street, string zipCode, string emailAddress, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            City = city;
            Street = street;
            ZipCode = zipCode;
            EmailAddress = emailAddress;
            PhoneNumber = phoneNumber;

            // Inițializați și celelalte proprietăți specifice facturii nevalidate
        }
    }
}
