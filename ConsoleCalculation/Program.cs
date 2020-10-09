using System;

namespace ConsoleCalculation
{
    class Program
    {
        static void Main(string[] args)
        {
            var ui = new UserInterface();
            var service = new Service();
            var number = new Number();

            ui.ShowMenu();
            while (true)
            {
                // 1. User can select an operator to perform: Add, Subtract, Multiply, Division
                ChooseOption op = ui.GetOptionOperator();
                switch (op)
                {

                    // Add
                    case ChooseOption.Add:
                        AddNumber(ui, service, number);
                        break;

                    // Subtract
                    case ChooseOption.Subtract:
                        SubtractNumber(ui, service, number);
                        break;

                    // Multiply
                    case ChooseOption.Multiply:
                        MultiplyNumber(ui, service, number);
                        break;

                    // Division
                    case ChooseOption.Division:
                        DivisionNumber(ui, service, number);
                        break;

                    // Clear
                    case ChooseOption.Clear:
                        ClearNumber(ui, service, number);
                        break;

                    // CleanScreen
                    case ChooseOption.CleanScreen:
                        CleanScreen(ui, number);
                        break;

                    // EXIT
                    case ChooseOption.Exit:
                        ui.ShowMessage(Message.EXIT);
                        return;

                    // Error
                    default:
                        ui.ShowMessage(Message.OPTION_INCORRECT);
                        break;
                }
            };
        }

        private static void CleanScreen(UserInterface ui, Number number)
        {
            ui.CleanScreen();
            ui.ShowMenu();
            ui.ShowNumber(number);
        }

        private static void ClearNumber(UserInterface ui, Service service, Number number)
        {
            service.SetZeroNumber(number);
            ui.ShowNumber(number);
        }

        private static void DivisionNumber(UserInterface ui, Service service, Number number)
        {
            // 1. Get Number from UI
            var _number = ui.GetNumber();

            // 2. Perform the division operator
            try
            {
                service.Division(number, _number);
            }
            catch (DivideByZeroException e)
            {
                ui.ShowMessage(e.Message);

            }
            catch (Exception exception)
            {
                ui.ShowMessage(exception.Message);
            }

            // 3. Display the results on the screen
            ui.ShowNumber(number);
        }

        private static void MultiplyNumber(UserInterface ui, Service service, Number number)
        {
            // 1. Get Number from UI
            var _number = ui.GetNumber();

            // 2. Execute the multiplication operator
            service.Multiply(number, _number);

            // 3. Display the results on the screen
            ui.ShowNumber(number);
        }

        private static void SubtractNumber(UserInterface ui, Service service, Number number)
        {
            // 1. Get Number from UI
            var _number = ui.GetNumber();

            // 2. Execute the subtraction operator
            service.Subtract(number, _number);

            // 3. Display the results on the screen
            ui.ShowNumber(number);
        }

        private static void AddNumber(UserInterface ui, Service service, Number number)
        {
            // 1. Get Number from UI
            var _number = ui.GetNumber();

            // 2. Execute the addition operator
            service.Add(number, _number);

            // 3. Display the results on the screen
            ui.ShowNumber(number);
        }
    }
}
