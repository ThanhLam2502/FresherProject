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
            var listCustomer = _customerRepository.Customer;
            int maxID = int.Parse(listCustomer.Max(item => item.ID));

            newCustomer.ID = maxID == 0 ? "1" : (maxID + 1).ToString();

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
        internal void EditFullNameCustomer(Customer customer, string fullName)
        {
            customer.FullName = fullName;
        }

        internal void EditPhoneByIDAddress(Address address, string phone)
        {
            address.Phone = phone;
        }

        internal void EditEmailByIDAddress(Address address, string emai)
        {
            address.Email = emai;
        }

        internal void EditLocationByIDAddress(Address address, string location)
        {
            address.Location = location;
        }

        internal bool IsExistsCustomerID(string customerId)
        {
            return _customerRepository.Customer.Exists(item => customerId.Equals(item.ID));
        }

        internal Customer GetCustomerByID(string customerId)
        {
            return _customerRepository.Customer.First(item => customerId.Equals(item.ID));
        }

        internal bool IsExistsAddress(List<Address> address)
        {
            return address.Any();
        }

        internal Address GetAddressByID(List<Address> address, string addressID)
        {
            return address.First(item => addressID.Equals(item.ID));
        }

        internal bool IsExistsAddressByID(List<Address> address, string addressID)
        {
            return address.Exists(item => addressID.Equals(item.ID));
        }

        internal bool IsPhoneExistsAddress(Address address)
        {
            return string.IsNullOrEmpty(address.Phone);
        }

        internal bool IsMailExistsAddress(Address address)
        {
            return string.IsNullOrEmpty(address.Email);
        }
    }
}