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
                        ui.ShowListCustomer(customers);
                        break;

                    // Add customers from users
                    case Choose.Add:
                        AddCustomer(ui, service);
                        break;

                    // Edit customer
                    case Choose.Edit:
                        EditCustomer(ui, service, customers);
                        break;

                    //remove customer
                    case Choose.Delete:
                        DeleteCustomter(ui, service, customers);
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

                    default:
                        return;
                }
                Console.WriteLine();
            }
        }

        private static void EditCustomer(UserInterface ui, CustomerService service, List<Customer> customers)
        {
            try
            {
                // 1. Get info customer from UI 
                Customer customer = ui.GetCustomerFromUI(customers);

                // 2. Check exist customer
                bool isCustomer = service.IsExistsCustomer(customer);

                // 3. Save the info customer
                service.EditCustomer(customer);

                // 4. Show info to let user know the customer is update
                ui.ShowMessage(Message.EDIT_SUCCESSFULLY);
            }
            catch (Exception)
            {
                ui.ShowMessage(Message.ERROR);
            }

        }
        private static void AddCustomer(UserInterface ui, CustomerService service)
        {
            // 1. User input Customer info
            Customer newCustomer = ui.EnterCustomerInfo();

            // 2. Save the Customer 
            service.AddCustomer(newCustomer);

            // 3. Show info to let user know the customer is added and stored
            ui.ShowMessage(Message.ADD_SUCCESSFULLY);
        }
        private static void DeleteCustomter(UserInterface ui, CustomerService service, List<Customer> customers)
        {
            // 1. User enter an option ID customer Delete from UI
            var ID = ui.GetIDCustomerFromUI(customers);

            // 2. Check exis CustomerID
            var isCusttomer = service.IsExistsCustomerID(ID);

            if (isCusttomer)
            {
                // 3. Delete customer by ID
                service.DeleteCustomer(ID);
                // 4. Show info to let user know the customer is remove 
                ui.ShowMessage(Message.DELETE_SUCCESSFULLY);
            }
            else ui.ShowMessage(Message.ERROR);
        }
    }
}
