using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FacturareWorkflow.Domain.Models.InvoiceChoice;

namespace FacturareWorkflow.Domain.Models
{
    [AsChoice]
    public static partial class InvoiceChoice
    {
        public interface IInvoice { }
        public record EmptyInvoice : IInvoice
        {
            public Invoice EmptyInvoiceState { get; }
            public EmptyInvoice(Invoice emptyInvoiceState)
            {
                EmptyInvoiceState = emptyInvoiceState;
            }
        }

        public record UnvalidatedInvoice : IInvoice
        {
            public IReadOnlyCollection<UnvalidatedInvoice> Invoice1 { get; }
            public UnvalidatedInvoice(IReadOnlyCollection<UnvalidatedInvoice> Invoice1)
            {
                Invoice1 = Invoice1;
            }

            internal bool IsValid()
            {
                throw new NotImplementedException();
            }
        }

        public record InvalidInvoice : IInvoice
        {
            public IReadOnlyCollection<UnvalidatedInvoice> Invoice1 { get; }
            public string? Reason { get; }
            public InvalidInvoice(IReadOnlyCollection<UnvalidatedInvoice> Invoice1, string? reason)
            {
                Invoice1 = Invoice1;
                Reason = reason;
            }
        }

        public record ValidatedInvoice : IInvoice
        {
            public IReadOnlyCollection<ValidatedInvoice> Invoice1 { get; }
            public ValidatedInvoice(IReadOnlyCollection<ValidatedInvoice> Invoice1)
            {
                Invoice1 = Invoice1;
            }
        }

        public record PaidInvoice : IInvoice
        {
            public IReadOnlyCollection<PaidInvoice> Invoice1 { get; }
            public PaidInvoice(IReadOnlyCollection<PaidInvoice> Invoice1)
            {
                Invoice1 = Invoice1;
            }
        }
    }
}
