using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturareWorkflow.Domain.Models
{
    public class ShoppingCart
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        // Alte proprietăți și metode relevante

        public bool IsEmpty => !Items.Any();
    }

    public class CartItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public bool IsAvailable { get; set; } // Presupune disponibilitatea produsului
        public bool IsValid { get; set; } // Presupune validarea produsului

        // Constructor și metode necesare
    }
}
