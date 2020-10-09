using System;

namespace ConsoleCalculation
{
    class Program
    {
        static void Main(string[] args)
        {
            int _result = 0;
            UserInterface ui = new UserInterface();
            Service service = new Service();

            ui.ShowMenu();
            while (true)
            {
                // 1. User can select an operator to perform: Add, Subtract, Multiply, Division
                Operator op = ui.GetOptionOperator();
                switch (op)
                {

                    // Add
                    case Operator.Add:
                        AddResult(ui, service, ref _result);
                        break;

                    // Subtract
                    case Operator.Subtract:
                        SubtractResult(ui, service, ref _result);
                        break;

                    // Multiply
                    case Operator.Multiply:
                        MultiplyResult(ui, service, ref _result);
                        break;

                    // Division
                    case Operator.Division:
                        DivisionResult(ui, service, ref _result);
                        break;

                    // Clear
                    case Operator.Clear:
                        ClearResult(ui, service, ref _result);
                        break;

                    // CleanScreen
                    case Operator.CleanScreen:
                        CleanScreen(ui, ref _result);
                        break;

                    // EXIT
                    case Operator.Exit:
                        ui.ShowMessage(Message.EXIT);
                        return;

                    default:
                        ui.ShowMessage(Message.OPTION_INCORRECT);
                        break;
                }
            };
        }

        private static void CleanScreen(UserInterface ui, ref int _result)
        {
            // 1. Show Menu
            ui.CleanScreen();
            ui.ShowMenu();

            // 2. Show result
            Console.WriteLine();
            ui.ShowResult(_result);
        }

        private static void ClearResult(UserInterface ui, Service service, ref int _result)
        {
            // 1. Set reuilt = 0
            service.SetResult(ref _result);

            // 2. Show result
            ui.ShowResult(_result);
        }

        private static void DivisionResult(UserInterface ui, Service service, ref int _result)
        {
            // 1. Get Number from UI
            int input = ui.GetNumberUserInput();

            // 2. Perform the division operator
            try
            {
                _result = service.Division(_result, input);
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            // 3. Display the results on the screen
            ui.ShowResult(_result);
        }

        private static void MultiplyResult(UserInterface ui, Service service, ref int _result)
        {
            // 1. Get Number from UI
            int input = ui.GetNumberUserInput();

            // 2. Execute the multiplication operator
            _result = service.Multiply(_result, input);

            // 3. Display the results on the screen
            ui.ShowResult(_result);
        }

        private static void SubtractResult(UserInterface ui, Service service, ref int _result)
        {
            // 1. Get Number from UI
            int input = ui.GetNumberUserInput();

            // 2. Execute the subtraction operator
            _result = service.Subtract(_result, input);

            // 3. Display the results on the screen
            ui.ShowResult(_result);
        }

        private static void AddResult(UserInterface ui, Service service, ref int _result)
        {
            // 1. Get Number from UI
            int input = ui.GetNumberUserInput();

            // 2. Execute the addition operator
            _result = service.Add(_result, input);

            // 3. Display the results on the screen
            ui.ShowResult(_result);
        }
    }
}
