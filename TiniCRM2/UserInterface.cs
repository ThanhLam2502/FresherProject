using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TiniCRM2
{
    internal class UserInterface
    {
        Validate _validate;
        Message _message;
        public UserInterface()
        {
            _message = new Message();
            _validate = new Validate();
        }

        internal int GetIntergerInput(string text)
        {
        reup:
            try{
                Console.Write(text);
                return Convert.ToInt32(Console.ReadLine());
            }catch{
                goto reup;
            };
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
            Console.WriteLine("5. CLEAR SCREEN");
            Console.WriteLine("6. PRESS ANOTHER KEY NUMBER TO EXIT");
        }

        internal void ShowAllCustomer(List<Customer> customers)
        {
            Console.WriteLine();
            //1. if: List empty, show message EMPTY
            if (customers.Count == 0)
                ShowMessage(_message.EMPTY_CUSTOMER);

            //2. else: Show all list Customer
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
            Console.WriteLine("3. CLEAR");
            Console.WriteLine("4. PRESS ANOTHER KEY NUMBER TO EXIT");
        }

        internal string GetIDFromScreen(List<Customer> customers)
        {
            ShowAllCustomer(customers);
            var chooseID = GetIntergerInput(_message.CHOOSE_ID).ToString();
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
                FullName = ValidInput(_message.ENTER_FULLNAME, Validate.regexName),
                //GetStringInput(_message.ENTER_FULLNAME),
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
                            Phone = ValidInputOrNull(_message.ENTER_PHONE, Validate.regexPhone),//GetStringInput(_message.ENTER_EMAIL),
                            Email = ValidInputOrNull(_message.ENTER_EMAIL, Validate.regexEmail),//GetStringInput(_message.ENTER_PHONE),
                            Location = GetStringInput(_message.ENTER_LOCATION),
                        };
                        addresses.Add(itemAddress);
                        break;
                    default:
                        return addresses;
                }
            }
        }

        private string ValidInputOrNull(string message, string regex)
        {
            string input = "";
            do
            {
                input = GetStringInput(message);
                if (string.IsNullOrEmpty(input))
                    break;
            } while (!_validate.IsValid(input, regex));

            return input;
        }

        internal string ValidInput(string message, string regex)
        {
            string input = "";
            do{
                input = GetStringInput(message);
            } while (string.IsNullOrEmpty(input) || !_validate.IsValid(input, regex));

            return input;
        }

        internal void DisplayContactByID(List<Address> address, string idAddress)
        {
            var _address = address.First(item => idAddress.Equals(item.ID));
            StringBuilder displayAddess = new StringBuilder();

            displayAddess.Append(string.Format("\tADDRESS ID: {0}", _address.ID));

            if (!string.IsNullOrEmpty(_address.Phone))
                displayAddess.Append(string.Format("\tPHONE: {0}", _address.Phone));
            if (!string.IsNullOrEmpty(_address.Email))
                displayAddess.Append(string.Format("\tEMAIL: {0}", _address.Email));
            if (!string.IsNullOrEmpty(_address.Location))
                displayAddess.Append(string.Format("\tLOCATION: {0}", _address.Location));

            Console.WriteLine(displayAddess);
        }

        internal void DisplayMenuEditContacts(List<Address> address, string idAddress)
        {
            Console.WriteLine();
            Console.WriteLine("---------------------------");

            var _address = address.First(item => idAddress.Equals(item.ID));
            if (!string.IsNullOrEmpty(_address.Phone))
                Console.WriteLine("1. PHONE");
            if (!string.IsNullOrEmpty(_address.Email))
                Console.WriteLine("2. EMAIL");
            if (!string.IsNullOrEmpty(_address.Location))
                Console.WriteLine("3. LOCATION");

            Console.WriteLine("4. CLEAR SCREEN");
            Console.WriteLine("5. PRESS ANOTHER KEY NUMBER TO EXIT");
        }

        internal void DisplayMenuAddress()
        {
            Console.WriteLine();
            Console.WriteLine("----------------------------");
            Console.WriteLine("1. ADD A ADDRESS");
            Console.WriteLine("2. PRESS ANOTHER KEY NUMBER TO EXIT");
            Console.Write("SELECT AN OPTION: ");
        }

    }
}