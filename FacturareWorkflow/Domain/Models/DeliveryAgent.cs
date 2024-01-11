using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturareWorkflow.Domain.Models
{
    public class DeliveryAgent
    {
        public int Id { get; set; } // Un identificator unic pentru agentul de livrare
        public string Name { get; set; } // Numele agentului de livrare
        public string ContactNumber { get; set; } // Numărul de contact al agentului
        public string DeliveryArea { get; set; } // Zona de livrare acoperită de agent

        // Alte proprietăți relevante pentru un agent de livrare

        // Constructor și metode
    }
}
