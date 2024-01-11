using FacturareWorkflow.Domain.Models;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using static FacturareWorkflow.Domain.Models.InvoiceChoice;
using static FacturareWorkflow.Domain.Models.Client;

namespace FacturareWorkflow.Domain.Operations
{
    public static class InvoiceOperations
    {
        public static Task<IInvoice> ValidateInvoice(Func<Client, TryAsync<bool>> checkClientExists, UnvalidatedInvoice Invoice) => Invoice.Invoice1.Select(ValidateInvoice(checkClientExists)).MatchAsync(
            Right: ValidatedInvoice => new ValidatedInvoice(Invoice),
            LeftAsync: errorMessage => Task.FromResult((IInvoice)new InvalidInvoice(Invoice, errorMessage)));

        private static Func<InvoiceChoice.UnvalidatedInvoice, EitherAsync<string, InvoiceChoice.ValidatedInvoice>> ValidateInvoice(Func<Client, TryAsync<bool>> checkClientExists) => unvalidatedInvoice => ValidateInvoice(checkClientExists, unvalidatedInvoice);

        private static EitherAsync<string, ValidatedInvoice> ValidateInvoice1(Func<Client, TryAsync<bool>> checkClientExists, UnvalidatedInvoice unvalidatedInvoice) =>
            from firstName in FirstName.TryParse(unvalidatedInvoice.FirstName).ToEitherAsync(() => $"Invalid first name {unvalidatedInvoice.FirstName}")
            from lastName in LastName.TryParse(unvalidatedInvoice.LastName).ToEitherAsync(() => $"Invalid last name {unvalidatedInvoice.LastName}")
            from city in City.TryParse(unvalidatedInvoice.City).ToEitherAsync(() => $"Invalid city {unvalidatedInvoice.City}")
            from street in Street.TryParse(unvalidatedInvoice.Street).ToEitherAsync(() => $"Invalid street {unvalidatedInvoice.Street}")
            from zipCode in ZipCode.TryParse(unvalidatedInvoice.ZipCode).ToEitherAsync(() => $"Invalid zip code {unvalidatedInvoice.ZipCode}")
            from emailAddress in Email.TryParse(unvalidatedInvoice.EmailAddress).ToEitherAsync(() => $"Invalid email address {unvalidatedInvoice.EmailAddress}")
            from phoneNumber in PhoneNumber.TryParse(unvalidatedInvoice.PhoneNumber).ToEitherAsync(() => $"Invalid phone number {unvalidatedInvoice.PhoneNumber}")
            select new ValidatedInvoice();

        public static IInvoice Workflow(IInvoice Invoice) => Invoice.Match(
            whenEmptyInvoice: emptyInvoice => emptyInvoice,
            whenUnvalidatedInvoice: unvalidatedInvoice => unvalidatedInvoice,
            whenInvalidInvoice: invalidInvoice => invalidInvoice,
            whenValidatedInvoice: validatedInvoice => validatedInvoice,
            whenPaidInvoice: paidInvoice => paidInvoice
            );
    }
}
