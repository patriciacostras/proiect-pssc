using FacturareWorkflow.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturareWorkflow.Domain.Commands
{
    public class ProcessDeliveryCommand
    {
        public Order Order { get; set; } // Comanda care trebuie livrată
        public DeliveryMethod DeliveryMethod { get; set; } // Metoda de livrare aleasă

        // Constructor și alte metode necesare
    }
}
