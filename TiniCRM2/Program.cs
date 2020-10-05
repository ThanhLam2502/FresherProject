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
                int option = ui.GetIntergerInput("");

                // 2.Based on the option, execute the operation
                switch (option)
                {
                    case (int)Choose.View:
                        ui.ShowAllCustomer(customers);
                        break;

                    case (int)Choose.Add:
                        Customer newCustomer = ui.CustomerInput();
                        service.AddCustomer(newCustomer);
                        break;

                    case (int)Choose.Edit:
                        EditCustomer(ui, service, message, customers);
                        ui.ShowMessage(message.EDIT_SUCCESSFULLY);
                        break;

                    case (int)Choose.Remove:
                        service.DeleteCustomer(ui.GetIDFromScreen(customers));
                        ui.ShowMessage(message.DELETE_SUCCESSFULLY);
                        break;
                    //case (int)Choose.RemoveAll:

                    //    //service.DeleteCustomer(id);
                    //    Console.WriteLine("Remove");
                    //    break;

                    default:
                        ui.ShowMessage(message.EXIT);
                        return;
                }

            }
        }

        private static void EditCustomer(UserInterface ui, CustomerService service, Message message, List<Customer> customers)
        {
            while (true)
            {
                var customerID = ui.GetIDFromScreen(customers);
                if (!customers.Exists(item => customerID.Equals(item.ID)))
                    return;

                var customer = customers.First(item => customerID.Equals(item.ID));
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
                            var fullName = ui.GetStringInput(message.ENTER_FULLNAME);
                            service.EditFullNameCustomer(customer, fullName);
                            ui.DisplayCustomer(customer);
                            break;

                        //Edit contact
                        case 2:
                            //Check list Address
                            if (customer.Address.Any())
                            {
                                ui.DisplayContact(customer);
                                var idAddress = ui.GetIntergerInput("SELECT AN OPTION: ");
                                //while (true)
                                //{
                                //    ui.DisplayMenuEditContacts(customer.Address);
                                //    var optionContact = ui.GetIntergerInput("SELECT AN OPTION: ");
                                //    switch (optionContact)
                                //    {
                                //        case 1: 
                                //            var phone = ui.GetStringInput(message.ENTER_PHONE);
                                //            service.EditPhoneByIDAddress(customer.Address, idAddress, phone);
                                //            ui.DisplayCustomer(customer);
                                //            break;
                                //        case 2:
                                //            var emai = ui.GetStringInput(message.ENTER_EMAIL);
                                //            service.EditEmailByIDAddress(customer.Address, idAddress, emai);
                                //            ui.DisplayCustomer(customer);
                                //            break;
                                //        case 3:
                                //            var location = ui.GetStringInput(message.ENTER_LOCATION);
                                //            service.EditLocationByIDAddress(customer.Address, idAddress, location);
                                //            ui.DisplayCustomer(customer);
                                //            break;
                                //        default:
                                //            return;
                                //    }

                                //}

                            }
                            return;
                        default:
                            return;
                    }
                }
                break;
            }
        }

    }
}
