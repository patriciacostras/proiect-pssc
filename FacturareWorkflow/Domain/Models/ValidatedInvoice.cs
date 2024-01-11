using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturareWorkflow.Domain.Models
{
    public class ValidatedInvoice : IInvoice
    {
        public double InvoicePrice { get; }
        public DateTime InvoiceDate { get; }

        public ValidatedInvoice(double invoicePrice, DateTime invoiceDate)
        {
            InvoicePrice = invoicePrice;
            InvoiceDate = invoiceDate;
        }
    }
}
