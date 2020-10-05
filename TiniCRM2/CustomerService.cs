using System;
using System.Linq;
using System.Collections.Generic;

namespace TiniCRM2
{
    internal class CustomerService
    {
        private readonly CustomerRepository _customerRepository;
        public CustomerService()
        {
            _customerRepository = new CustomerRepository();
        }

        internal List<Customer> getAllCustomers()
        {
            return _customerRepository.Customer;
        }

        internal void AddCustomer(Customer newCustomer)
        {
            var listCustomer = _customerRepository.Customer;
            var lenList = listCustomer.Count;

            newCustomer.ID = lenList == 0 ?  "1" :  (lenList+1).ToString();
            listCustomer.Add(newCustomer);
        }

        internal void DeleteCustomer(string id)
        {
            _customerRepository.Customer.RemoveAll(item => item.ID.Equals(id));
        }
        internal void DeleteAllCustomer()
        {
            _customerRepository.Customer = new List<Customer>();
        }
        internal void EditCustomer(string id)
        {
            
        }
        internal void EditFullNameCustomer(Customer customer, string fullName)
        {
            customer.FullName = fullName;
        }

        internal void EditPhoneByIDAddress(List<Address> address, int idAddress, string phone)
        {
            address.First(item => item.ID.Equals(idAddress)).Phone = phone;
        }

        internal void EditEmailByIDAddress(List<Address> address, int idAddress, string emai)
        {
            address.First(item => item.ID.Equals(idAddress)).Email = emai;
        }

        internal void EditLocationByIDAddress(List<Address> address, int idAddress, string location)
        {
            address.First(item => item.ID.Equals(idAddress)).Location = location;
        }
    }
}