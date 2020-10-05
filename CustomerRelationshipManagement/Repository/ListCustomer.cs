using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomerRelationshipManagement.Class
{
    public class ListCustomer : IListCustomers<Customer>
    {
        List<Customer> customers = new List<Customer>()
        {
            new Customer("01", "A",null ,"1212"),
            new Customer("02", "B", "mail@mail.com", "01235","scsa"),
            new Customer("03", "D"),
            new Customer("04", "F",null,"asaadsa"),
        };  


        public void addCustomer(Customer t)
        {
            customers.Add(t);
        }

        public void deleteCustomer(Customer t)
        {
            customers.RemoveAll(item => item.CustomerID == t.CustomerID);
            //customers.Remove(customers.Find(item => item.CustomerID == t.CustomerID));
        }

        public void editCustomer(Customer t)
        {
            Customer customerFindByID = customers.Find(item => item.CustomerID == t.CustomerID);
            if (customerFindByID != null)
            {
                customers.Remove(customerFindByID);
                customers.Add(t);
            }

        }

        public void viewListCustomers()
        {
            customers.OrderBy(item => item.CustomerName).ToList().ForEach(item => item.displayCustomer());
        }
        
    }
}
