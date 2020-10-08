using System;
using System.Collections.Generic;
using System.Linq;

namespace TiniCRM2
{
    internal class CustomerRepository
    {
        public List<Customer> Customer { get; internal set; }

        public CustomerRepository()
        {
            //Customer = GetCustomerDB();
            Customer = new List<Customer> {
                new Customer
                {
                    ID = "1",
                    FullName = "abc",
                    Address = new List<Address>
                    {
                        new Address("1", "0126", "dsadg", "49sg"),
                        new Address("2", "0126"),
                        new Address("3",  "0126", null, "52nhl"),
                        new Address("4"),
                        new Address("5", null, "dsadsa"),
                    }
                },
                new Customer
                {
                    ID = "2",
                    FullName = "cba",
                },
                new Customer
                {
                    ID = "3",
                    FullName = "aef",
                    Address = new List<Address>
                    {
                        new Address("1", "0126", "dsadg", "49sg"),
                        new Address("2", "0126"),
                        new Address("3", "0126", null,"52nhl"),
                    }
                },
                new Customer
                {
                    ID = "10",
                    FullName = "cba",
                },
            };
        }

        private List<Customer> GetCustomerDB()
        {
            throw new NotImplementedException();
        }

        internal string GetMaxIDCustomer()
        {
            return Customer.Max(_ => int.Parse(_.ID)).ToString();
        }
        internal void Add(Customer newCustomer)
        {
            Customer.Add(newCustomer);
        }
        internal void Update(Customer customer)
        {
            var customerStore = Customer.First(_ => _.ID.Equals(customer.ID));
            customerStore.FullName = customer.FullName;
            customerStore.Address = customer.Address;
        }
        internal void Remove(string id)
        {
            Customer.RemoveAll(_ => _.ID.Equals(id));
        }
       
    }
}