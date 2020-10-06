using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TiniCRM2
{
    internal class UserInterface
    {
        Validate _validate;
        public UserInterface()
        {
            _validate = new Validate();
        }

        internal Choose GetOption()
        {
            Console.WriteLine();
            while (true)
            {
                try
                {
                    Console.Write("Select an option: ");
                    int input = int.Parse(Console.ReadLine());
                    switch (input)
                    {
                        case 1:
                            return Choose.View;
                        case 2:
                            return Choose.Add;
                        case 3:
                            return Choose.Edit;
                        case 4:
                            return Choose.Delete;
                        case 5:
                            return Choose.Clear;
                        case 6:
                            return Choose.Exit;
                        default:
                            continue;
                    }
                }
                catch (Exception)
                {
                    continue;
                }
            }
        }

        internal string GetStringInput(string text, string regex)
        {
            string input = "";
            do
            {
                Console.Write(text);
                input = Console.ReadLine();
            } while (string.IsNullOrEmpty(input) || !_validate.IsValid(input, regex));

            return input;
        }

        internal void DisplayMenu()
        {
            Console.WriteLine("===================MENU===================");
            Console.WriteLine("1. SHOW ALL CUSTOMERS");
            Console.WriteLine("2. ADD A CUSTOMER");
            Console.WriteLine("3. EDIT A CUSTOMER");
            Console.WriteLine("4. DELETE A CUSTOMER");
            Console.WriteLine("5. CLEAR SCREEN");
            Console.WriteLine("6. EXIT");
        }

        internal void ShowAllCustomer(List<Customer> customers)
        {
            if (customers.Count == 0)
                ShowMessage(Message.EMPTY_CUSTOMER);
            else customers.ForEach(item => ShowCustomer(item));

            Console.WriteLine();
        }


        public void DisplayMenuEditCustomer(Customer customer)
        {
            Console.WriteLine();
            Console.WriteLine("1. FULL NAME");
            Console.WriteLine("2. ADDRESS");
            Console.WriteLine("3. CLEAR");
            Console.WriteLine("4. EXIT");
        }

        internal string GetCustomerId()
        {
            var chooseID = GetOptionInput().ToString();
            return chooseID;
        }

        internal int GetOptionMenuEdit()
        {

            while (true)
            {
                int input = GetOptionInput();
                if (input >= 1 && input <= 4)
                    return input; 
            }
        }

        public void ShowCustomer(Customer item)
        {
            Console.WriteLine(string.Format("ID: {0}, FULL NAME: {1}", item.ID, item.FullName));
            ShowAllContact(item.Address);
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        internal Customer EnterCustomerInfo()
        {
            Console.WriteLine();
            var customer = new Customer
            {
                //FullName = ValidStringInput(Message.ENTER_FULLNAME, Validate.regexName),
            };
            
            return customer;
        }

        internal void ShowAllContact(List<Address> addresses)
        {
            addresses.ForEach(x =>
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
            Console.WriteLine();
        }

        internal string GetIDFromUI()
        {
            var input = GetOptionInput();
            return input.ToString();
        }

        public List<Address> EnterListAddress()
        {
            List<Address> addresses = new List<Address>();
            while (true)
            {
                DisplayMenuAddress();

                int option = GetOptionInput();
                switch (option)
                {
                    case 1:
                        var itemAddress = new Address
                        {
                            ID = addresses.Count == 0 ? "1" : (addresses.Count + 1).ToString(),
                            Phone = ValidStringInputOrNull(Message.ENTER_PHONE, Validate.regexPhone),
                            Email = ValidStringInputOrNull(Message.ENTER_EMAIL, Validate.regexEmail),
                            //Location = GetStringInput(Message.ENTER_LOCATION),
                        };
                        addresses.Add(itemAddress);
                        Console.WriteLine();
                        ShowAllContact(addresses);
                        break;
                    case 2:
                        Console.Clear();
                        ShowAllContact(addresses);
                        break;
                    case 3:
                        return addresses;
                        //default:
                        //    continue;
                }
            }
        }

        public int GetOptionInput()
        {
            while (true)
                try
                {
                    Console.Write("Select an option: ");
                    return int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    continue;
                };
        }

        private string ValidStringInputOrNull(string message, string regex)
        {
            string input = "";
            do
            {
                //input = GetStringInput(message);
                if (string.IsNullOrEmpty(input))
                    break;
            } while (!_validate.IsValid(input, regex));

            return input;
        }

        internal string ValidStringInput(string message, string regex)
        {
            string input = "";
            do
            {
                Console.Write(message);
                input = Console.ReadLine();
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

        internal void DisplayMenuEditContact(Address address)
        {
            Console.WriteLine();
            Console.WriteLine("---------------------------");

            if (!string.IsNullOrEmpty(address.Phone))
                Console.WriteLine("1. PHONE");
            if (!string.IsNullOrEmpty(address.Email))
                Console.WriteLine("2. EMAIL");
            if (!string.IsNullOrEmpty(address.Location))
                Console.WriteLine("3. LOCATION");

            Console.WriteLine("4. CLEAR SCREEN");
            Console.WriteLine("5. EXIT");
        }

        internal void DisplayMenuAddress()
        {
            Console.WriteLine();
            Console.WriteLine("----------------------------");

            Console.WriteLine("1. ADD A ADDRESS");
            Console.WriteLine("2. CLEAR");
            Console.WriteLine("3. EXIT");
        }

    }
}