using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturareWorkflow.Domain.WorkflowEvents
{
    [AsChoice]
    public static partial class DeliveryEvent
    {
        public interface IDeliveryEvent { }
        public record DeliverySucceededEvent : IDeliveryEvent
        {
            // csv
        }
        public record DeliveryFailedEvent : IDeliveryEvent
        {
            public string Reason { get; }
            internal DeliveryFailedEvent(string reason)
            {
                Reason = reason;
            }
        }
    }
}
