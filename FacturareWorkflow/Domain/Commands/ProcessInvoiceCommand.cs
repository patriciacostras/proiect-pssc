using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FacturareWorkflow.Domain.Models.InvoiceChoice;

namespace FacturareWorkflow.Domain.Commands
{
    public record ProcessInvoiceCommand
    {
        public IReadOnlyCollection<UnvalidatedInvoice> InputInvoicePrice { get; }
        public ProcessInvoiceCommand(IReadOnlyCollection<UnvalidatedInvoice> inputInvoicePrice)
        {
            InputInvoicePrice = inputInvoicePrice;
        }
    }
}
