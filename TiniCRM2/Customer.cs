using System.Collections.Generic;
using System;

namespace TiniCRM2
{
    internal class Customer
    {
        private string iD;
        private string fullName;

        public string ID { get => iD; set => iD = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public List<Address> Address { get; set; }

        public Customer()
        {
            Address = new List<Address>();
        }

    }
}