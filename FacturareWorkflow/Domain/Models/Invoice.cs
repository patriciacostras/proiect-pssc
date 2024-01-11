using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturareWorkflow.Domain.Models
{
    public record Invoice
    {
        public Client Client { get; set; }
        public Invoice()
        {
        }
    }
}
