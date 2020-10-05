using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerRelationshipManagement.Model
{
    public class ContactAdress
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        public string OfficeAddress { get; set; }
        public string HomeAddress { get; set; }
        public void displayContactAddress()
        {
            StringBuilder displayCustomer = new StringBuilder();

            if (!String.IsNullOrEmpty(Email))
                displayCustomer.Append(String.Format(", Email: {0}", Email));
            if (!String.IsNullOrEmpty(Phone))
                displayCustomer.Append(String.Format(", Phone: {0}", Phone));
            if (!String.IsNullOrEmpty(OfficeAddress))
                displayCustomer.Append(String.Format(", Address: {0}", OfficeAddress));
            if (!String.IsNullOrEmpty(HomeAddress))
                displayCustomer.Append(String.Format(", Address: {0}", HomeAddress));

            Console.WriteLine(displayCustomer);
        }

    }
}
