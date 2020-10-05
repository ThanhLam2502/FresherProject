using System;

namespace TinyCRM
{
    class Program
    {
        static void Main(string[] args)
        {
            // Waterfall
            // Agile software engineer (programmer, coder)
            // Top-down implementation

            while (true)
            {
                // 1. User enter an option: Add, Edit, Delete, View a customer: 
                var ui = new UserInterface();
                var logic = new CustomerApplication();
                var storage = new CustomerStorage();
                Operations option = ui.GetOperation();
                // 2. Based on the option, execute the operation
                switch (option)
                {
                    case Operations.Exit:
                        return;

                    case Operations.Add:
                        {
                            // 1.User input customer info
                            Customer newCustomer = ui.EnterCustomerInfo();
                            logic.AddCustomer(newCustomer);
                            // 2. Save the customer
                            storage.Add(newCustomer);
                            // 3. Show info to let user know the customer is added and stored
                            ui.ShowMessage("Customer added");
                            break;
                        }
                    case Operations.Edit:
                        {
                            EditExistingCustomer(ui, storage);

                            break;
                        }
                    case Operations.Delete:
                        {
                            break;
                        }
                    case Operations.View:
                        {
                            break;
                        }
                }
            }
        }
    }
}
