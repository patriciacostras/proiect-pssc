using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturareWorkflow.Domain.WorkflowEvents
{
    [AsChoice]
    public static partial class InvoicePaidEvent
    {
        public interface IInvoiceProcessingEvent { }
        public record InvoiceProcessingSucceededEvent : IInvoiceProcessingEvent
        {
            // csv
        }
        public record InvoiceProcessingFailedEvent : IInvoiceProcessingEvent
        {
            public string Reason { get; }
            internal InvoiceProcessingFailedEvent(string reason)
            {
                Reason = reason;
            }
        }
    }
}
