using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Course02.Entities.Enums;

namespace Course02.Entities
{
    internal class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public Order() { }

        public Order(OrderStatus status, Client client)
        {
            Moment = DateTime.Now;
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem orderItem)
        {
            OrderItems.Add(orderItem);
        }

        public void RemoveItem(OrderItem orderItem)
        {
            OrderItems.Add(orderItem);
        }

        public double Total()
        {
            double sum = 0.0;
            foreach(OrderItem orderItem in OrderItems)
            {
                sum += orderItem.SubTotal();
            }
            return sum;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("ORDER SUMMARY:");
            sb.Append("Order moment: ");
            sb.AppendLine(Moment.ToString("dd-MM-yyyy HH:mm:ss"));
            sb.Append("Order status: ");
            sb.AppendLine(Status.ToString());
            sb.Append("Client: ");
            sb.Append(Client.Name);
            sb.Append(" (");
            sb.Append(Client.BirthDate.ToString("dd-MM-yyyy"));
            sb.Append(") - ");
            sb.AppendLine(Client.Email);
            sb.AppendLine("Order items:");

            foreach(OrderItem orderItem in OrderItems)
            {
                sb.Append(orderItem.Product.Name);
                sb.Append(", $");
                sb.Append(orderItem.Product.Price.ToString("F2",CultureInfo.InvariantCulture));
                sb.Append(", Quantity: ");
                sb.Append(orderItem.Quantity.ToString());
                sb.Append(", Subtotal: $");
                sb.AppendLine(orderItem.SubTotal().ToString("F2", CultureInfo.InvariantCulture));
            }

            sb.Append("Total price: $");
            sb.Append(Total().ToString("F2", CultureInfo.InvariantCulture));

            return sb.ToString();

        }
    }
}
