using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturareWorkflow.Domain.Models
{
    public enum PaymentMethod
    {
        CreditCard,
        BankTransfer,
        Cash
    }
    public class Payment
    {
        public PaymentMethod Method { get; set; }

        public string? CardNumber { get; set; }

        public double Amount { get; set; }

        public Payment(PaymentMethod method, string? cardNumber, double amount)
        {
            Method = method;
            CardNumber = cardNumber;
            Amount = amount;
        }

        public override string ToString()
        {
            return $"PaymentMethod={Method}, CardNumber={CardNumber ?? "N/A"}, Amount={Amount}";
        }
    }
}
