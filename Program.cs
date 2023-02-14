using System;
using System.Globalization;
using Course02.Entities;
using Course02.Entities.Enums;

namespace Course02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> productList = new List<Product>();
            productList.Add(new Product("TV", 1000.00));
            productList.Add(new Product("Mouse", 40.00));

            Console.WriteLine("Enter cliente data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("BirthDate(dd-MM-yyyy): ");
            DateTime birthDate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);

            Client client = new Client(name, email, birthDate);

            Console.WriteLine("Enter Order Data:");

            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());

            Console.Write("How many items to this order? ");
            int n = int.Parse(Console.ReadLine());

            Order order = new Order(status, client);

            for(int i = 1; i <= n; i++)
            {
                Console.Write("Product's Name: ");
                string productName = Console.ReadLine();
                Console.Write("Quantity: ");
                int productQuantity = int.Parse(Console.ReadLine());

                foreach (Product product in productList)
                {
                    if(productName == product.Name)
                    {
                        OrderItem orderItem = new OrderItem(product, productQuantity);
                        order.AddItem(orderItem);
                    }
                }
            }

            Console.WriteLine(order);
           
        }
    }
}