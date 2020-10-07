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
            else customers.ForEach(item => ShowCustomerInfo(item));

            Console.WriteLine();
        }


        public void DisplayMenuEditCustomer(Customer customer)
        {
            Console.WriteLine();
            Console.WriteLine("-----------------------");
            Console.WriteLine("1. FULL NAME");
            Console.WriteLine("2. ADDRESS");
            Console.WriteLine("3. CLEAR");
            Console.WriteLine("4. EXIT EDIT CUSTOMER");
        }

        internal void ClearScreen()
        {
            Console.Clear();
        }

        internal string GetCustomerId()
        {
            var chooseID = GetOptionInput().ToString();
            return chooseID;
        }

        internal OptionCustomer GetOptionMenuEdit()
        {
            int input = -1;
            while (true)
            {
                input = GetOptionInput();
                if (input >= 1 && input <= 4)
                    break; 
            }
            switch (input)
            {
                case 1:
                    return OptionCustomer.FullName;
                case 2:
                    return OptionCustomer.Address;
                case 3:
                    return OptionCustomer.Clear;
                default:
                    return OptionCustomer.Exit;
            }
        }

        public void ShowCustomerInfo(Customer item)
        {
            Console.WriteLine();
            Console.WriteLine(string.Format("ID: {0}, FULL NAME: {1}", item.ID, item.FullName));
            ShowAllAddress(item.Address);
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
                FullName = ValidStringInput(Message.ENTER_FULLNAME, Validate.regexName),
            };
            
            return customer;
        }

        internal void ShowMenuEditCustomer(Customer customer)
        {
            // 1 Show info Customer by ID
            ShowCustomerInfo(customer);

            // 2 Show menu Edit Customer
            DisplayMenuEditCustomer(customer);
        }

        internal void ShowAllAddress(List<Address> addresses)
        {
            addresses.ForEach(item =>
            {
                ShowInfoAddress(item);
            });
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

                var option = GetOptionAddAddress();
                switch (option)
                {
                    case AddAddress.Add:
                        var itemAddress = new Address
                        {
                            ID = addresses.Count == 0 ? "1" : (addresses.Count + 1).ToString(),
                            Phone = ValidStringInputOrNull(Message.ENTER_PHONE, Validate.regexPhone),
                            Email = ValidStringInputOrNull(Message.ENTER_EMAIL, Validate.regexEmail),
                            Location = ValidStringInputOrNull(Message.ENTER_LOCATION, Validate.regexLocation),
                        };
                        addresses.Add(itemAddress);
                        Console.WriteLine();
                        ShowAllAddress(addresses);
                        break;

                    case AddAddress.Clear:
                        Console.Clear();
                        ShowAllAddress(addresses);
                        break;

                    case AddAddress.Exit:
                        return addresses;
                }
            }
        }

        internal void ShowMenuEditAddress(Address address)
        {
            // 1. Show Info Addresss
            ShowInfoAddress(address);

            // 2. Show menu edit Address
            DisplayMenuEditAddress(address);
        }

        private AddAddress GetOptionAddAddress()
        {
            int input = -1;
            while (true)
            {
                input = GetOptionInput();
                if (input >= 1 || input <= 3)
                    break;
            }
            switch (input)
            {
                case 1:
                    return AddAddress.Add;

                case 2:
                    return AddAddress.Clear;

                default:
                    return AddAddress.Exit;
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
            string input = string.Empty;
            do
            {
                Console.Write(message);
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input) || _validate.IsValid(input, regex))
                    break;
            } while (true);

            return input;
        }

        internal string ValidStringInput(string message, string regex)
        {
            string input = string.Empty;
            do
            {
                Console.Write(message);
                input = Console.ReadLine();
            } while (!_validate.IsValid(input, regex));

            return input;
        }

        internal void DisplayContactByID(List<Address> address, string idAddress)
        {
            var _address = address.First(item => idAddress.Equals(item.ID));
            StringBuilder displayAddess = new StringBuilder();
            Console.WriteLine("-----------------------");
            displayAddess.Append(string.Format("\tADDRESS ID: {0}", _address.ID));

            if (!string.IsNullOrEmpty(_address.Phone))
                displayAddess.Append(string.Format("\tPHONE: {0}", _address.Phone));
            if (!string.IsNullOrEmpty(_address.Email))
                displayAddess.Append(string.Format("\tEMAIL: {0}", _address.Email));
            if (!string.IsNullOrEmpty(_address.Location))
                displayAddess.Append(string.Format("\tLOCATION: {0}", _address.Location));

            Console.WriteLine(displayAddess);
        }

        internal OptionAddress GetOptionEditAdress()
        {
            int input = -1;
            while (true)
            {
                input = GetOptionInput();
                if (input >= 1 && input <= 5)
                    break;
            }
            switch (input)
            {
                case 1:
                    return OptionAddress.Phone;

                case 2:
                    return OptionAddress.Email;

                case 3:
                    return OptionAddress.Location;

                case 4:
                    return OptionAddress.Clear;

                default:
                    return OptionAddress.Exit;
            }
        }

        internal void DisplayMenuEditAddress(Address address)
        {
            Console.WriteLine();
            Console.WriteLine("-----------------------");

            if (!string.IsNullOrEmpty(address.Phone))
                Console.WriteLine("1. PHONE");
            if (!string.IsNullOrEmpty(address.Email))
                Console.WriteLine("2. EMAIL");
            if (!string.IsNullOrEmpty(address.Location))
                Console.WriteLine("3. LOCATION");
            Console.WriteLine("4. CLEAR");
            Console.WriteLine("5. EXIT EDIT ADDRESS");
        }

        internal void DisplayMenuAddress()
        {
            Console.WriteLine();
            Console.WriteLine("----------------------------");

            Console.WriteLine("1. ADD A ADDRESS");
            Console.WriteLine("2. CLEAR SCREEN");
            Console.WriteLine("3. EXIT");
        }

        internal void ShowInfoAddress(Address address)
        {
            StringBuilder displayAddess = new StringBuilder();

                displayAddess.Append(string.Format("\tADDRESS ID: {0}", address.ID));

                if (!string.IsNullOrEmpty(address.Phone))
                    displayAddess.Append(string.Format("\tPHONE: {0}", address.Phone));
                if (!string.IsNullOrEmpty(address.Email))
                    displayAddess.Append(string.Format("\tEMAIL: {0}", address.Email));
                if (!string.IsNullOrEmpty(address.Location))
                    displayAddess.Append(string.Format("\tLOCATION: {0}", address.Location));

                Console.WriteLine(displayAddess);
        }
    }
}