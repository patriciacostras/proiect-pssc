using FacturareWorkflow.Domain.Commands;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FacturareWorkflow.Domain.Models.InvoiceChoice;
using static FacturareWorkflow.Domain.WorkflowEvents.InvoicePaidEvent;
using static FacturareWorkflow.Domain.Models.Client;
FacturareWorkflow.Domain.Models.InvoiceChoice.UnvalidatedInvoice invoice1;




namespace FacturareWorkflow.Domain.Workflows
{
    public class InvoiceWorkflow
    {

        public async Task<IInvoiceProcessingEvent> ExecuteAsync(ProcessInvoiceCommand command, Func<double, TryAsync<bool>> checkTotalPrice)
        {
            UnvalidatedInvoice unvalidatedInvoice = new UnvalidatedInvoice(command.InputInvoicePrice);
            IInvoice Invoice = await ValidatedInvoice(unvalidatedInvoice);

            return Invoice.Match(
                    whenEmptyInvoice: emptyInvoice => new InvoiceProcessingFailedEvent("Unexpected empty state") as IInvoiceProcessingEvent,
                    whenUnvalidatedInvoice: unvalidatedInvoice => new InvoiceProcessingFailedEvent("Unexpected unvalidated state"),
                    whenInvalidInvoice: invalidInvoice => new InvoiceProcessingFailedEvent(invalidInvoice.Reason),
                    whenValidatedInvoice: validatedInvoice => new InvoiceProcessingFailedEvent("Unexpected validated state"),
                    whenPaidInvoice: paidInvoice => new InvoiceProcessingSucceededEvent()
                );
        }
    }
}
