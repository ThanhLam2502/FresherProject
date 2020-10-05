using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerRelationshipManagement
{
    interface IListCustomers<T> where T : Customer
    {
        public void viewListCustomers();
        public void addCustomer(T t);
        public void editCustomer(T t);
        public void deleteCustomer(T t);
    }
}
