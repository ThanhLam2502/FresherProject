using System;

namespace ConsoleCalculation
{
    class Program
    {
        static void Main(string[] args)
        {
            UserInterface ui = new UserInterface();
            Service service = new Service();

            while (true)
            {
                ui.DisplayMenu();
                Operator op = ui.GetInputOperator();
                switch (op)
                {
                    case Operator.Add:
                        break;
                    case Operator.Subtract:
                        break;
                    case Operator.Multiply:
                        break;
                    case Operator.Division:
                        break;
                    default:
                        return;
                }
                break;
            }
        }
    }
}
