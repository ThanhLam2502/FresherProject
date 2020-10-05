using CustomerRelationshipManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerRelationshipManagement
{
    public class Customer
    {
        #region property
        public string CustomerID { get => CustomerID; set => CustomerID = value; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerAddress { get; set; }
        #endregion

        //public List<ContactAdress> contactAddresses { get; set; }
        #region redundancy
        //public Customer(string id, string name)
        //{
        //    CustomerID = id;
        //    CustomerName = name;
        //}
        //public Customer(string id, string name, string email = null)
        //{
        //    CustomerID = id;
        //    CustomerName = name;
        //    CustomerEmail = email;
        //}
        //public Customer(string id, string name, string email = null, string phone = null)
        //{
        //    CustomerID = id;
        //    CustomerName = name;
        //    CustomerEmail = email;
        //    CustomerPhone = phone;
        //}
        #endregion
        public Customer(string id, string name, string email = null, string phone = null, string address = null)
        {
            CustomerID = id;
            CustomerName = name;
            CustomerEmail = email;
            CustomerPhone = phone;
            CustomerAddress = address;
        }
        public void displayCustomer()
        {
            StringBuilder displayCustomer = new StringBuilder();

            displayCustomer.Append(String.Format("ID: {0}, Name: {1}", CustomerID, CustomerName));

            if (!String.IsNullOrEmpty(CustomerEmail))
                displayCustomer.Append(String.Format(", Email: {0}", CustomerEmail));

            if (!String.IsNullOrEmpty(CustomerPhone))
                displayCustomer.Append(String.Format(", Phone: {0}", CustomerPhone));

            if (!String.IsNullOrEmpty(CustomerAddress))
                displayCustomer.Append(String.Format(", Address: {0}", CustomerAddress));


            Console.WriteLine(displayCustomer);
        }
 
        ~Customer()
        {
            Dispose();
        }

        public void Dispose()
        {
            Console.WriteLine("Fields cleaned");
            CustomerID = String.Empty;
            CustomerName = String.Empty;
            CustomerEmail = String.Empty;
            CustomerPhone = String.Empty;
            CustomerAddress = String.Empty;
        }
    }
}
