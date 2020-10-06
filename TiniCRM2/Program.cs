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
                        // 1. User input Customer info
                            // 1.1 User input Full Name
                        //Customer newCustomer = ui.EnterCustomerInfo();

                            // 1.2 User add Address Customer
                        //newCustomer.Address = ui.EnterListAddress();

                        // 2. Save the Customer 
                        //service.AddCustomer(newCustomer);

                        // 3. Show info to let user know the customer is added and stored
                        ui.ShowMessage(Message.ADD_SUCCESSFULLY);
                        break;

                    // Edit customer
                    case Choose.Edit:
                        // 1. Show all customer info
                        ui.ShowAllCustomer(customers);

                        // 2. Get customer Id from UI
                            // 2.1. Get customer ID from User
                        var customerId = ui.GetCustomerId();

                        // 2.2 Check exist CustomerID    
                        bool isCustomerID = service.IsExistsCustomerID(customerId);
                        if (!isCustomerID)
                            return;

                        // 3. Show menu Edit by Customer ID: FullName, Address
                            // 3.1 Get customer by ID 
                        Console.Clear();    
                        var customer = service.GetCustomerByID(customerId);

                            // 3.2 Show info Customer by ID
                        ui.ShowCustomer(customer);

                            // 3.3 Show menu Edit Customer
                        ui.DisplayMenuEditCustomer(customer);

                        // 4. User enter an option Edit
                        var input = ui.GetOptionMenuEdit();
                        // 5. Based on the option, execute the operation
                        switch (input)
                        {
                            // 5.1. User choose Full Name
                            case 1:
                                // 5.1.1 Get Input Full Name
                                string fullName = ui.GetStringInput(Message.ENTER_FULLNAME, Validate.regexName);
                                // 5.1.2 Save edit
                                service.EditFullNameCustomer(customer, fullName);
                                break;

                            // 5.2. User choose Address
                            case 2:
                                // 5.2.1. Check exist list Address
                                bool isAddress = service.isExistsAddress(customer.Address);
                                if (!isAddress)
                                    break;
                                // 5.2.2 Show contact customer
                                ui.ShowAllContact(customer.Address);

                                // 5.2.2. Show menu edit contact

                                // 3.4.2. User choose an option

                                // 3.4.3. Edit Addreess by option

                                break;
                            


                            
                        }


                        // 4. Save the customer

                        // 5. Show info to let user know the customer is edit and stored

                        //EditCustomer(ui, service, , customers);
                        ui.ShowMessage(Message.EDIT_SUCCESSFULLY);
                        break;

                    //remove customer
                    case Choose.Delete:
                        // 1. Show all Customer
                        ui.ShowAllCustomer(customers);
                        // 2. User enter an option ID customer Delete

                        // 3. Delete customer by ID

                        // 4. Show info to let user know the customer is remove 

                        //var deleteCustomerID = ui.GetCustomerId(customers);
                        //service.DeleteCustomer(deleteCustomerID);
                        ui.ShowMessage(Message.DELETE_SUCCESSFULLY);
                        break;

                    //clear screen
                    case Choose.Clear:
                        Console.Clear();
                        break;

                    //exit
                    default:
                        Console.WriteLine("=========*=========");
                        ui.ShowMessage("\t" + Message.EXIT);
                        return;
                }

            }
        }
        /*
        private static void EditCustomer(UserInterface ui, CustomerService service, Message message, List<Customer> customers)
        {
            //1. Get customer Id from UI
            var customerId = ui.GetCustomerId();
            //2. Get customer object to show in the UI
            //3. 

            while (true)
            {
                var customerID = ui.GetCustomerId(customers);
                //check exits ID in list
                if (!customers.Exists(item => customerID.Equals(item.ID)))
                {
                    ui.ShowMessage(message.NOT_FOUND);
                    return;
                }

                var customer = customers.First(item => customerID.Equals(item.ID));
                Console.Clear();
                ui.DisplayCustomer(customer);
                while (true)
                {
                    ui.DisplayMenuEditCustomer(customer);

                    //Choose Customer
                    var option = ui.GetIntergerInput("SELECT AN OPTION: ");
                    switch (option)
                    {
                        //Edit fullName
                        case 1:
                            var fullName = ui.ValidInput(message.ENTER_FULLNAME, Validate.regexName);
                            service.EditFullNameCustomer(customer, fullName);
                            ui.DisplayCustomer(customer);
                            break;

                        //Edit contact
                        case 2:
                            EditContact(customer, ui, service, message);
                            break;

                        //Clear screen
                        case 3:
                            Console.Clear();
                            ui.DisplayCustomer(customer);
                            break;

                        // Exit
                        default:
                            return;

                    }
                }

            }
        }

        private static void EditContact(Customer customer, UserInterface ui, CustomerService service, Message message)
        {
            // 1.

            // 2. 

            //check list address
            if (customer.Address.Any())
            {
                Console.Clear();
                ui.DisplayContact(customer);
                // choose address id
                var idAddress = ui.GetStringInput("SELECT AN OPTION: ");
                while (true)
                {
                    ui.DisplayContactByID(customer.Address, idAddress);
                    ui.DisplayMenuEditContacts(customer.Address, idAddress);
                    var optionContact = ui.GetIntergerInput("SELECT AN OPTION: ");
                    Address contact = GetContactByID(customer.Address, idAddress);
                    switch (optionContact)
                    {
                        //edit Phone
                        case 1:
                            //check exist phone
                            if (string.IsNullOrEmpty(contact.Phone))
                            {
                                ui.ShowMessage(message.NOT_FOUND);
                                break;
                            }
                            var phone = ui.ValidInput(message.ENTER_PHONE, Validate.regexPhone);//ui.GetStringInput(message.ENTER_PHONE);
                            service.EditPhoneByIDAddress(customer.Address, idAddress, phone);
                            break;

                        //edit Email
                        case 2:
                            if (string.IsNullOrEmpty(contact.Email))
                            {
                                ui.ShowMessage(message.NOT_FOUND);
                                break;
                            }
                            var emai = ui.ValidInput(message.ENTER_EMAIL, Validate.regexEmail);
                            service.EditEmailByIDAddress(customer.Address, idAddress, emai);
                            break;

                        //edit location
                        case 3:
                            if (string.IsNullOrEmpty(contact.Location))
                            {
                                ui.ShowMessage(message.NOT_FOUND);
                                break;
                            }
                            var location = ui.GetStringInput(message.ENTER_LOCATION);
                            service.EditLocationByIDAddress(customer.Address, idAddress, location);
                            break;

                        case 4:
                            Console.Clear();
                            break;

                        default:
                            ui.DisplayCustomer(customer);
                            return;
                    }

                }

            }
        }

        private static Address GetContactByID(List<Address> address, string idAddress)
        {
            return address.First(item => item.ID.Equals(idAddress));
        }
        */
    }
}
