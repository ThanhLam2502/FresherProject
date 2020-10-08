using System;

namespace ConsoleCalculation
{
    class Program
    {
        static void Main(string[] args)
        {
            UserInterface ui = new UserInterface();
            Service service = new Service();

            // 1. User can select an operator to perform: Add, Subtract, Multiply, Division
            Operator op = ui.GetInputOperator();
            switch (op)
            {
                // Add
                case Operator.Add:
                    AddResult(ui, service);
                    break;

                // Subtract
                case Operator.Subtract:
                    SubtractResult(ui, service);
                    break;

                // Multiply
                case Operator.Multiply:
                    MultiplyResult(ui, service);
                    break;

                // Division
                case Operator.Division:
                    DivisionResult(ui, service);
                    break;

                default:
                    Console.WriteLine("ERROR") ;
                    break;
            }
        }

        private static void DivisionResult(UserInterface ui, Service service)
        {
            // 1. User input
            int input = ui.GetUserInput();

            // 2. Perform the division operator
            int result = service.Add(input);

            // 3. Display the results on the screen
            ui.ShowResult(result);
        }

        private static void MultiplyResult(UserInterface ui, Service service)
        {
            // 1. User input

            // 2. Execute the multiplication operator

            // 3. Display the results on the screen
        }

        private static void SubtractResult(UserInterface ui, Service service)
        {
            // 1. User input

            // 2. Execute the subtraction operator

            // 3. Display the results on the screen
        }

        private static void AddResult(UserInterface ui, Service service)
        {
            // 1. User input

            // 2. Execute the addition operator

            // 3. Display the results on the screen
        }
    }
}
