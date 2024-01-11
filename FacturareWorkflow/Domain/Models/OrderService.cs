using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturareWorkflow.Domain.Models
{
    public class OrderService
    {
        public void AddOrder(Order order)
        {
            using (var context = new Pssc1Context())
            {
                context.Orders.Add(order);
                context.SaveChanges();
            }
        }
    }
}
