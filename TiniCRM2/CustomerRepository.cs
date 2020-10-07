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

        internal void Edit(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}