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
                        new Address("3",  "0126", "52nhl"),
                        new Address("4"),
                    }
                },
                new Customer
                {
                    ID = "2",
                    FullName = "cba",
                    Address = new List<Address>()
                },
                new Customer
                {
                    ID = "3",
                    FullName = "aef",
                    Address = new List<Address>
                    {
                        new Address("1", "0126", "dsadg", "49sg"),
                        new Address("2", "0126"),
                        new Address("3", "0126", "52nhl"),
                    }
                }
            };
        }

        private List<Customer> GetCustomerDB()
        {
            throw new NotImplementedException();
        }

        internal string GetMaxIDCustomer()
        {
            return Customer.Max(_ => _.ID);
        }
        internal void Add(Customer newCustomer)
        {
            Customer.Add(newCustomer);
        }
        internal void Update(Customer customer)
        {
            var customerStore = Customer.FirstOrDefault(_ => _.ID.Equals(customer.ID));
            if (customerStore != null)
                customerStore = customer;
            else
                throw new Exception(Message.ERROR);
        }
        internal void Remove(string id)
        {
            Customer.RemoveAll(_ => _.ID.Equals(id));
        }
    }
}