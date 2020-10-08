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
        internal void AddCustomer(Customer newCustomer)
        {
            // 1. Get max ID
            string maxID = _customerRepository.GetMaxIDCustomer();

            // 2. Set ID newCustomer
            newCustomer.ID = maxID.Equals("0") ? "1" : (int.Parse(maxID) + 1).ToString();

            // 3. Save newCustomer
            _customerRepository.Add(newCustomer);
        }
        internal void EditCustomer(Customer customer)
        {
            // 1. Check customer exist in DB
            if (IsExistsCustomerID(customer.ID))

            // 2. Update customer
                _customerRepository.Update(customer);
            else
                throw new Exception(Message.NOT_FOUND);
        }
        internal void DeleteCustomer(string id)
        {
            if (IsExistsCustomerID(id))
                _customerRepository.Remove(id);
            else
                throw new Exception(Message.NOT_FOUND);
        }
        internal bool IsExistsCustomerID(string customerId)
        {
            var listCustomer = GetAllCustomers();

            return listCustomer.Any(item => customerId.Equals(item.ID));
        }

    }
}