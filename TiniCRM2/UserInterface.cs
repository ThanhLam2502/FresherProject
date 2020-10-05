﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TiniCRM2
{
    internal class UserInterface
    {
        Message _message;
        public UserInterface()
        {
            _message = new Message();
        }

        internal int GetIntergerInput(string text)
        {
            Console.Write(text);
            return Convert.ToInt32(Console.ReadLine());

        }
        internal string GetStringInput(string text)
        {
            Console.Write(text);
            return Console.ReadLine();
        }

        internal void DisplayMenu()
        {
            Console.WriteLine("===================MENU===================");
            Console.WriteLine("1. SHOW ALL CUSTOMERS");
            Console.WriteLine("2. ADD A CUSTOMER");
            Console.WriteLine("3. EDIT A CUSTOMER");
            Console.WriteLine("4. DELETE A CUSTOMER");
            Console.WriteLine("5. PRESS ANOTHER KEY TO EXIT");
            Console.Write("SELECT AN OPTION: ");
        }

        internal void ShowAllCustomer(List<Customer> customers)
        {
            Console.WriteLine();
            if (customers.Count == 0)
                ShowMessage(_message.EMPTY_CUSTOMER);
            else customers.ForEach(item => DisplayCustomer(item));
            Console.WriteLine();
        }


        public void DisplayMenuEditCustomer(Customer customer)
        {
            Console.WriteLine();
            if(!string.IsNullOrEmpty(customer.FullName))
                Console.WriteLine("1. FULL NAME");
            if (customer.Address.Any())
                Console.WriteLine("2. ADDRESS");
            Console.WriteLine("3. PRESS ANOTHER KEY TO EXIT");
        }

        internal string GetIDFromScreen(List<Customer> customers)
        {
            ShowAllCustomer(customers);
            var chooseID = GetStringInput(_message.CHOOSE_ID);
            return chooseID;
        }

        public void DisplayCustomer(Customer item)
        {
            Console.WriteLine(string.Format("ID: {0}, FULL NAME: {1}", item.ID, item.FullName));
            DisplayContact(item);
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        internal Customer CustomerInput()
        {
            Console.WriteLine();
            var customer = new Customer
            {
                FullName = GetStringInput(_message.ENTER_FULLNAME),
            };
            customer.Address = listAddressInput();
            return customer;
        }

        internal void DisplayContact(Customer customer)
        {
            customer.Address.ForEach(x =>
            {
                StringBuilder displayAddess = new StringBuilder();

                displayAddess.Append(string.Format("\tADDRESS ID: {0}", x.ID));

                if (!string.IsNullOrEmpty(x.Phone))
                    displayAddess.Append(string.Format("\tPHONE: {0}", x.Phone));
                if (!string.IsNullOrEmpty(x.Email))
                    displayAddess.Append(string.Format("\tEMAIL: {0}", x.Email));
                if (!string.IsNullOrEmpty(x.Location))
                    displayAddess.Append(string.Format("\tLOCATION: {0}", x.Location));

                Console.WriteLine(displayAddess);
            });
        }

        private List<Address> listAddressInput()
        {
            List<Address> addresses = new List<Address>();
            while (true)
            {
                DisplayMenuAddress();
                int option = GetIntergerInput("");
                switch (option)
                {
                    case 1:
                        var itemAddress = new Address
                        {
                            ID = addresses.Count == 0 ? "1" : (addresses.Count + 1).ToString(),
                            Email = GetStringInput(_message.ENTER_PHONE),
                            Phone = GetStringInput(_message.ENTER_EMAIL),
                            Location = GetStringInput(_message.ENTER_LOCATION),
                        };
                        addresses.Add(itemAddress);
                        break;
                    default:
                        return addresses;
                }
            }
        }

        internal void DisplayMenuEditContacts(List<Address> address)
        {
            Console.WriteLine();
            Console.WriteLine("----------------------------");

            address.ForEach(item =>
            {
                if(!string.IsNullOrEmpty(item.Phone))
                    Console.WriteLine("1. PHONE");
                if (!string.IsNullOrEmpty(item.Email))
                    Console.WriteLine("2. Email");
                if (!string.IsNullOrEmpty(item.Location))
                    Console.WriteLine("3. LOCATION");

            });
            
            Console.WriteLine("2. PRESS ANOTHER KEY TO EXIT");
        }

        internal void DisplayMenuAddress()
        {
            Console.WriteLine();
            Console.WriteLine("----------------------------");
            Console.WriteLine("1. ADD A ADDRESS");
            Console.WriteLine("2. PRESS ANOTHER KEY TO EXIT");
            Console.Write("SELECT AN OPTION: ");
        }

    }
}