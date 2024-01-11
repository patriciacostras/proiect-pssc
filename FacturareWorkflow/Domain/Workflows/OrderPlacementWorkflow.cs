using FacturareWorkflow.Domain.Commands;
using FacturareWorkflow.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FacturareWorkflow.Domain.WorkflowEvents.OrderPlacementEvent;
namespace FacturareWorkflow.Domain.Workflows
{
    public class OrderPlacementWorkflow
    {

        public async Task<IOrderPlacementEvent> ExecuteAsync(ProcessOrderCommand command)
        {
            if (!VerifyCart(command.Cart))
                return new OrderPlacementFailedEvent("Verificarea coșului a eșuat.");

            EnterDeliveryDetails(command.DeliveryDetails);
            ChoosePaymentMethod(command.PaymentMethod);

            bool isOrderConfirmed = ConfirmOrder(); // Corectat apelul ca metodă
            return isOrderConfirmed
                ? new OrderPlacementSucceededEvent()
                : new OrderPlacementFailedEvent("Confirmarea comenzii a eșuat.");
        }

        private void ChoosePaymentMethod(PaymentMethod paymentMethod)
        {
            throw new NotImplementedException();
        }

        private bool VerifyCart(ShoppingCart cart)
        {
            // Verifica dacă toate produsele din coș sunt disponibile și valide
            return cart.Items.All(item => item.IsAvailable && item.IsValid);

        }
        private void EnterDeliveryDetails(DeliveryDetails details)
        {
            Console.WriteLine($"Detalii livrare: {details.Address}, {details.City}, {details.ZipCode}");
        }

        private void ChoosePaymentMethod(Payment method)
        {
            Console.WriteLine($"Metoda de plată aleasă: {method}");
        }

        private bool ConfirmOrder()
        {
            Console.WriteLine("Comanda a fost confirmată.");
            return true;
        }
    }


}
