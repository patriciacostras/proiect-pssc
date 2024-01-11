using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturareWorkflow.Domain.WorkflowEvents
{
    [AsChoice]
    public static partial class OrderPlacementEvent
    {
        public interface IOrderPlacementEvent { }
        public record OrderPlacementSucceededEvent : IOrderPlacementEvent
        {
            // csv
        }
        public record OrderPlacementFailedEvent : IOrderPlacementEvent
        {
            public string Reason { get; }
            internal OrderPlacementFailedEvent(string reason)
            {
                Reason = reason;
            }
        }
    }
}
