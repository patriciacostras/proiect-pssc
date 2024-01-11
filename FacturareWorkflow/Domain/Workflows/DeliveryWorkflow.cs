using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FacturareWorkflow.Domain.WorkflowEvents.DeliveryEvent;
using static FacturareWorkflow.Domain.Models.Order;
using static FacturareWorkflow.Domain.Models.DeliveryMethod;
using FacturareWorkflow.Domain.Models;
using FacturareWorkflow.Domain.Commands;

namespace FacturareWorkflow.Domain.Workflows
{
    public class DeliveryWorkflow
    {
        public async Task<IDeliveryEvent> ExecuteAsync(ProcessDeliveryCommand command)
        {
            PrepareOrder(command.Order);

            if (!ChooseDeliveryMethod(command.DeliveryMethod))
                return new DeliveryFailedEvent("Alegerea metodei de livrare a eșuat.");

            if (!ProcessDelivery(command.Order))
                return new DeliveryFailedEvent("Procesarea livrării a eșuat.");

            TrackDelivery(command.Order);
            DeliverOrder(command.Order);

            bool isReceiptConfirmed = ConfirmReceipt();
            return isReceiptConfirmed
                ? new DeliverySucceededEvent()
                : new DeliveryFailedEvent("Confirmarea recepției a eșuat.");
        }

        private void PrepareOrder(Order order)
        {
            Console.WriteLine($"Comanda {order.Id} este pregătită pentru livrare.");
        }

        private bool ChooseDeliveryMethod(DeliveryMethod method)
        {
            Console.WriteLine($"Metoda de livrare aleasă este: {method}.");
            return true;
        }

        private bool ProcessDelivery(Order order)
        {
            Console.WriteLine($"Procesarea livrării pentru comanda {order.Id}.");
            return order.DeliveryAgent != null;
        }

        private void TrackDelivery(Order order)
        {
            Console.WriteLine($"Comanda {order.Id} este în tranzit.");
        }

        private void DeliverOrder(Order order)
        {
            Console.WriteLine($"Comanda {order.Id} a fost livrată la adresa {order.DeliveryAddress}.");
        }

        private bool ConfirmReceipt()
        {
            Console.WriteLine("Clientul a confirmat recepția comenzii.");
            return true;
        }
    }


}
