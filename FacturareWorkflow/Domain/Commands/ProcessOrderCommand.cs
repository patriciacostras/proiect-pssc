using FacturareWorkflow.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturareWorkflow.Domain.Commands
{
    public class ProcessOrderCommand
    {
        public ShoppingCart Cart { get; set; }
        public DeliveryDetails DeliveryDetails { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        // Alte proprietăți și metode necesare
    }
}
