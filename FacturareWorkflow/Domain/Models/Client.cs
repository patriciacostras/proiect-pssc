using LanguageExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace FacturareWorkflow.Domain.Models
{
    public class Client
    {
        public City City { get; set; }
        public Country Country { get; set; }
        public Email Email { get; set; }
        public FirstName FirstName { get; set; }
        public LastName LastName { get; set; }
        public Payment Payment { get; set; }
        public PhoneNumber PhoneNumber { get; set; }
        public Street Street { get; set; }
        public ZipCode ZipCode { get; set; }
        public bool CheckClientExist() { return true; }
        public Client(City city, Country country, Email email, FirstName firstName, LastName lastName, Payment payment, PhoneNumber phoneNumber, Street street, ZipCode zipCode)
        {
            City = city;
            Country = country;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Payment = payment;
            PhoneNumber = phoneNumber;
            Street = street;
            ZipCode = zipCode;
        }

        public override string ToString()
        {
            return $"FirstName={FirstName}, LastName={LastName}, City={City}, Country={Country}, Street={Street}, ZipCode={ZipCode}, Email={Email}, PhoneNumber={PhoneNumber}, Payment={Payment}";
        }
    }
}
