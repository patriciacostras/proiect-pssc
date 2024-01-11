using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturareWorkflow.Domain.Models
{
    public class Order
    {
        public int Id { get; set; } // Un identificator unic pentru comandă
        public string CustomerName { get; set; } // Numele clientului
        public string DeliveryAddress { get; set; } // Adresa de livrare
        // Alte proprietăți relevante pentru comandă

        // Presupunem că DeliveryAgent este un tip de date sau o clasă definită în altă parte
        public DeliveryAgent DeliveryAgent { get; set; } // Agentul de livrare asignat comenzii

        // Constructor, metode și alte funcționalități
    }
}
