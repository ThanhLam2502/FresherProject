using CustomerRelationshipManagement.Class;
using System;
using System.Collections.Generic;

namespace CustomerRelationshipManagement
{
    public class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer("03", "G");
            ListCustomer list = new ListCustomer();
            list.deleteCustomer(customer);
            //list.editCustomer(customer);

            list.viewListCustomers();

            Console.ReadKey();
        }
    }
}
