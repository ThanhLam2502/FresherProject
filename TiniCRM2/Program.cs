using System;
using System.Linq;
using System.Collections.Generic;

namespace TiniCRM2
{
    class Program
    {
        static void Main(string[] args)
        {
            var message = new Message();
            var ui = new UserInterface();
            var service = new CustomerService();
            var customers = service.getAllCustomers();

            // 1. Execute the request user
            while (true)
            {
                // 1. User chosse an option: Add, Edit, Delete, Exit
                ui.DisplayMenu();
                int option = ui.GetIntergerInput("SELECT AN OPTION: ");

                // 2.Based on the option, execute the operation
                switch (option)
                {
                    case (int)Choose.View:
                        ui.ShowAllCustomer(customers);
                        break;

                    case (int)Choose.Add:
                        Customer newCustomer = ui.CustomerInput();
                        service.AddCustomer(newCustomer);
                        ui.ShowMessage(message.ADD_SUCCESSFULLY);
                        break;

                    case (int)Choose.Edit:
                        EditCustomer(ui, service, message, customers);
                        //ui.ShowMessage(message.EDIT_SUCCESSFULLY);
                        break;

                    case (int)Choose.Remove:
                        var deleteCustomerID = ui.GetIDFromScreen(customers);
                        service.DeleteCustomer(deleteCustomerID);
                        ui.ShowMessage(message.DELETE_SUCCESSFULLY);
                        break;
                    case (int)Choose.Clear:
                        Console.Clear();
                        break;

                    default:
                        Console.WriteLine("=========*=========");
                        ui.ShowMessage("\t" + message.EXIT);
                        return;
                }

            }
        }

        private static void EditCustomer(UserInterface ui, CustomerService service, Message message, List<Customer> customers)
        {
            while (true)
            {
                var customerID = ui.GetIDFromScreen(customers);
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
                            //var fullName = ui.GetStringInput(message.ENTER_FULLNAME);
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

                        // exit
                        default:
                            return;

                    }
                }

            }
        }

        private static void EditContact(Customer customer, UserInterface ui, CustomerService service, Message message)
        {
            if (customer.Address.Any())
            {
                Console.Clear();
                ui.DisplayContact(customer);
                var idAddress = ui.GetStringInput("SELECT AN OPTION: ");
                while (true)
                {
                    ui.DisplayContactByID(customer.Address, idAddress);
                    ui.DisplayMenuEditContacts(customer.Address, idAddress);
                    var optionContact = ui.GetIntergerInput("SELECT AN OPTION: ");
                    Address contact = GetContactByID(customer.Address, idAddress);
                    switch (optionContact)
                    {
                        case 1:
                            if (string.IsNullOrEmpty(contact.Phone))
                            {
                                ui.ShowMessage(message.NOT_FOUND);
                                break;
                            }
                            var phone = ui.ValidInput(message.ENTER_PHONE, Validate.regexPhone);//ui.GetStringInput(message.ENTER_PHONE);
                            service.EditPhoneByIDAddress(customer.Address, idAddress, phone);
                            break;

                        case 2:
                            if (string.IsNullOrEmpty(contact.Location))
                            {
                                ui.ShowMessage(message.NOT_FOUND);
                                break;
                            }
                            var emai = ui.ValidInput(message.ENTER_EMAIL, Validate.regexEmail);
                            service.EditEmailByIDAddress(customer.Address, idAddress, emai);
                            break;

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
    }
}
