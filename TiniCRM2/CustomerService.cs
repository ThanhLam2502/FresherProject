using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;

namespace TiniCRM2
{
    internal class CustomerService
    {
        private readonly CustomerRepository _customerRepository;
        public CustomerService()
        {
            _customerRepository = new CustomerRepository();
        }

        internal List<Customer> GetAllCustomers()
        {
            return _customerRepository.Customer;
        }
        //
        internal void AddCustomer(Customer newCustomer)
        {
            var listCustomer = _customerRepository.Customer;
            int maxID = int.Parse(listCustomer.Max(item => item.ID));

            newCustomer.ID = maxID == 0 ? "1" : (maxID + 1).ToString();

            listCustomer.Add(newCustomer);
        }
        //
        internal void EditCustomer(Customer customer)
        {
            _customerRepository.Edit(customer);
        }
        //
        internal void DeleteCustomer(string id)
        {
            _customerRepository.Customer.RemoveAll(item => item.ID.Equals(id));
        }
        internal bool IsExistsCustomer(Customer customer)
        {
            return _customerRepository.Customer.Any(_ => customer.ID.Equals(_.ID));
        }
        internal bool IsExistsCustomerID(string customerId)
        {
            return _customerRepository.Customer.Exists(item => customerId.Equals(item.ID));
        }
        internal bool IsExistsAddress(List<Address> address)
        {
            return address.Any();
        }

    }
}