using System;
using System.Linq;
using System.Collections.Generic;

namespace TiniCRM2
{
    class Program
    {
        static void Main(string[] args)
        {
            var ui = new UserInterface();
            var service = new CustomerService();
            var customers = service.GetAllCustomers();
  
            // 1. Execute the request user
            while (true)
            {
                // 1. Show menu
                ui.DisplayMenu();

                // 2. User chosse an option: Add, Edit, Delete, Exit
                Choose option = ui.GetOption();

                // 3.Based on the option, execute the operation
                switch (option)
                {
                    // Show list customer 
                    case Choose.View:
                        ui.ShowAllCustomer(customers);
                        break;

                    // Add customers from users
                    case Choose.Add:
                        #region Option Add Customer
                        // 1. User input Customer info
                            // 1.1 User input Full Name
                        Customer newCustomer = ui.EnterCustomerInfo();

                            // 1.2 User add Address Customer
                        newCustomer.Address = ui.EnterListAddress();

                        // 2. Save the Customer 
                        service.AddCustomer(newCustomer);

                        // 3. Show info to let user know the customer is added and stored
                        ui.ShowMessage(Message.ADD_SUCCESSFULLY); 
                        #endregion
                        break;

                    // Edit customer
                    case Choose.Edit:
                        #region Option Edit Customer
                        // 1. Show all customer info
                        ui.ShowAllCustomer(customers);

                        // 2. Edit customer info
                        EditCustomerInfo(ui, service);
                        #endregion
                        break;

                    //remove customer
                    case Choose.Delete:
                        #region Option Delete Customer
                        // 1. Show all Customer
                        ui.ShowAllCustomer(customers);

                        // 2. DeleteCustomer
                        DeleteCustomter(ui, service);
                        
                        // 4. Show info to let user know the customer is remove 
                        ui.ShowMessage(Message.DELETE_SUCCESSFULLY);
                        #endregion
                        break;

                    //clear screen
                    case Choose.Clear:
                        ui.ClearScreen();
                        break;

                    //exit
                    case Choose.Exit:
                        Console.WriteLine("=========*=========");
                        ui.ShowMessage("\t" + Message.EXIT);
                        return;
                }
                Console.WriteLine();
            }
        }

        private static void EditCustomerInfo(UserInterface ui, CustomerService service)
        {
            // 2. Get customer Id from UI
            var customerId = GetCustomerIDFromUI(ui, service);

            // 3. Get customer by ID from service
            Customer customer = service.GetCustomerByID(customerId);

            // 4. Edit customer info
            // loop Edit Customer for when choose Exit
            ui.ClearScreen();
            while (true)
            {
                bool isExit = false;    // check exit loop

                // 1. Show menu Edit Customer: : FullName, Address, Exit
                ui.ShowMenuEditCustomer(customer);

                // 2. User enter an option Edit customer: Full Name, Address
                var input = ui.GetOptionMenuEdit();

                // 3. Based on the option, execute the operation
                switch (input)
                {
                    // User choose edit Full Name
                    case OptionCustomer.FullName:
                        #region Option Edit Full Name
                        // 1. Get fullName user input 
                        string fullName = ui.ValidStringInput(Message.ENTER_FULLNAME, Validate.regexName);

                        // 2. Save edit
                        service.EditFullNameCustomer(customer, fullName);

                        // 3. Show info edit successfully
                        ui.ShowMessage(Message.EDIT_SUCCESSFULLY);
                        Console.WriteLine();
                        #endregion
                        break;

                    // User choose edit Address
                    case OptionCustomer.Address:
                        #region Option Edit List Address
                        // 1. Check for exist list Address
                        bool isListAddress = service.IsExistsAddress(customer.Address);
                        if (!isListAddress)
                        {
                            ui.ShowMessage(Message.INVALID_OPTION);
                            Console.WriteLine();
                            break;
                        }

                        // 2. Show address customer
                        ui.ClearScreen();
                        ui.ShowAllAddress(customer.Address);

                        // 3. Get the address information the user chooses
                        Address address = GetAddressServiceFromUI(ui, service, customer);

                        // 4. Edit Address info
                        // (loop for when user exist edit address 
                        while (true)
                        {
                            bool isExitsEditAddress = false; // check exit loop
                            // 1. Show info address
                            ui.ShowMenuEditAddress(address);
                            
                            // 2. User choose an option: Phone, Email, Location, Exit Edit Address
                            var optionEditAdress = ui.GetOptionEditAdress();

                            // 3. Edit Addreess by option
                            switch (optionEditAdress)
                            {
                                // edit Phone
                                case OptionAddress.Phone:
                                    #region Option Edit Address Phone
                                    // 1. check exist property phone in address
                                    bool isPhone = service.IsPhoneExistsAddress(address);
                                    if (isPhone)
                                    {
                                        ui.ShowMessage(Message.INVALID_OPTION);
                                        Console.WriteLine();
                                        break;
                                    }
                                    // 2. get Phone user input
                                    var phone = ui.ValidStringInput(Message.ENTER_PHONE, Validate.regexPhone);

                                    // 3. save the phone
                                    service.EditPhoneByIDAddress(address, phone);

                                    // 4. Show info edit successfully
                                    ui.ShowMessage(Message.EDIT_SUCCESSFULLY);
                                    #endregion
                                    break; 

                                //edit Email
                                case OptionAddress.Email:
                                    #region Option Edit Adress Mail
                                    // 1. check exist property email in address
                                    bool isMail = service.IsMailExistsAddress(address);
                                    if (isMail)
                                    {
                                        ui.ShowMessage(Message.INVALID_OPTION);
                                        Console.WriteLine();
                                        break;
                                    }

                                    // 2. get email user input
                                    var mail = ui.ValidStringInput(Message.ENTER_EMAIL, Validate.regexEmail);

                                    // 3. save the phone
                                    service.EditPhoneByIDAddress(address, mail);

                                    // 4. Show info edit successfully
                                    ui.ShowMessage(Message.EDIT_SUCCESSFULLY); 
                                    #endregion
                                    break;

                                //edit location
                                case OptionAddress.Location:
                                    #region Option Edit Address Location
                                    // 1. check exist property location in address
                                    bool isLocaltion = service.IsMailExistsAddress(address);
                                    if (isLocaltion)
                                    {
                                        ui.ShowMessage(Message.INVALID_OPTION);
                                        Console.WriteLine();
                                        break;
                                    }

                                    // 2. get email user input
                                    var adressInput = ui.ValidStringInput(Message.ENTER_LOCATION, Validate.regexLocation);

                                    // 3. save the phone
                                    service.EditLocationByIDAddress(address, adressInput);

                                    // 4. Show info edit successfully
                                    ui.ShowMessage(Message.EDIT_SUCCESSFULLY); 
                                    #endregion
                                    break;
                                
                                // Clear screen
                                case OptionAddress.Clear:
                                    ui.ClearScreen();
                                    break;
                                   
                                // Exit edit Address
                                case OptionAddress.Exit:
                                    isExitsEditAddress = true;
                                    break;

                            }
                            if (isExitsEditAddress)
                                break;
                        }
                        // (end loop)
                        #endregion
                        break;

                    // User clear screen
                    case OptionCustomer.Clear:
                        ui.ClearScreen();
                        break;

                    // User exit edit Customer
                    case OptionCustomer.Exit:
                        isExit = true;
                        break;

                }
                if (isExit)
                    break;
            }
            // end loop
        }

        private static void DeleteCustomter(UserInterface ui, CustomerService service)
        {
            // 1. User enter an option ID customer Delete from UI
            var customerID = GetCustomerIDFromUI(ui, service);

            // 2. Delete customer by ID
            service.DeleteCustomer(customerID);
        }

        private static Address GetAddressServiceFromUI(UserInterface ui, CustomerService service, Customer customer)
        {
            // 1. Loop for when get addressID
            string addressID = string.Empty;
            while (true)
            {
                // 1.1. Get AddressID From UI
                addressID = ui.GetIDFromUI();

                // 1.2. Check exists AddressID
                bool isAddress = service.IsExistsAddressByID(customer.Address, addressID);

                if (isAddress)
                    break;
            }

            // 2. Get Address By ID
            Address address = service.GetAddressByID(customer.Address, addressID);

            return address;
        }

        private static string GetCustomerIDFromUI(UserInterface ui, CustomerService service)
        {
            var ID = String.Empty;
            while (true)
            {
                // 1. Get customer ID from User
                ID = ui.GetCustomerId();

                // 2. Check exist CustomerID    
                bool isCustomerID = service.IsExistsCustomerID(ID);
                if (isCustomerID)
                    return ID;
            }
        }
    }
}
