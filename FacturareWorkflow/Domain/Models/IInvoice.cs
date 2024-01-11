using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturareWorkflow.Domain.Models
{
    public interface IInvoice
    {
        double InvoicePrice { get; }
        DateTime InvoiceDate { get; }
    }
}
