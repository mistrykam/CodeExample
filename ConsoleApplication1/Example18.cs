using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication1
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public DateTime CustomerSince { get; set; }

        public IList<Order> OrderList { get; set; }

        public override string ToString()
        {
            return string.Format(" \t{0}\n \t{1}\n \t{2}\n \t{3}\n \t{4}\n \t{5}", CustomerId, FirstName, LastName, Country, CustomerSince, OrderList.Count);
        }

        public Customer()
        {
            OrderList = new List<Order>();
        }
    }

    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime DateOfOrder { get; set; }
        public float Amount { get; set; }
        public string ShipToCountry { get; set; }

        public override string ToString()
        {
            return string.Format("\t{0} {1} {2} {3} {4}", OrderId, CustomerId, DateOfOrder, Amount, ShipToCountry);
        }
    }

    public static class Example18
    {
        private static List<Customer> DBCustomers = new List<Customer>();

        private static List<Order> DBOrders = new List<Order>();

        private static void InitCustomerList()
        {
            Random rand = new Random();

            int k = 0;

            for (int i = 0; i < 100; i++)
            {
                Customer customer = new Customer();

                customer.CustomerId = i;

                customer.FirstName = "Bob-" + ((char)rand.Next(65, 90)).ToString();
                customer.LastName = "Smith-" + rand.Next(1, 100).ToString();
                customer.Country = "Germany-" + rand.Next(1, 100).ToString();
                customer.CustomerSince = DateTime.Now;

                for (int j = 0; j < rand.Next(1, 15); j++)
                {
                    Order order = new Order();

                    order.OrderId = k++;
                    order.CustomerId = customer.CustomerId;
                    order.DateOfOrder = DateTime.Now;
                    order.Amount = (float)rand.Next(1, 100) / 3 * (float)rand.Next(1, 100);
                    order.ShipToCountry = rand.Next(0, 10) % 2 == 0 ? "Canada" : "USA";

                    customer.OrderList.Add(order);

                    // simulate a database
                    DBOrders.Add(order);
                }

                // simulate a database
                DBCustomers.Add(customer);
            }
        }

        public static void ExampleCode1()
        {
            InitCustomerList();

            // list of customer grouped by Country

            var result = from x in DBCustomers
                         where x.LastName.Contains("2")
                         orderby x.Country descending
                         group x by x.Country;
            
            foreach (var group in result)  // group is the type IGrouping<string, Customer>
            {
                Console.WriteLine(group.Key + " :: Count=" + group.Count());

                foreach (Customer c in group)
                    Console.WriteLine(c);
            }
        }

        public static void ExampleCode2()
        {
            InitCustomerList();

            // list of customer and there orders

            var result = from customer in DBCustomers
                         join order in DBOrders
                            on customer.CustomerId equals order.CustomerId
                         select customer;


            foreach (Customer customer in result)
            {
                Console.WriteLine(customer);

                foreach(Order order in customer.OrderList)
                    Console.WriteLine(order);

                Console.WriteLine();
            }
        }
    }
}