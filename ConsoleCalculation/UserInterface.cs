using System;

namespace ConsoleCalculation
{
    public enum Operator
    {
        Add = 1,
        Subtract,
        Multiply,
        Division,
        Exit,
    }
    internal class UserInterface
    {
        internal Operator GetInputOperator()
        {
            // 1. Show menu : Add, Subtract, Multiply, Division
            ShowMenu();

            // 2. The user chooses an option
            int choose = GetChooseInput();

            // 3. Based on the option, return the operation
            Operator op = new Operator();
            switch (choose)
            {
                case (int)Operator.Add:
                    op = Operator.Add;
                    break;

                case (int)Operator.Subtract:
                    op = Operator.Subtract;
                    break;

                case (int)Operator.Multiply:
                    op = Operator.Multiply;
                    break;

                case (int)Operator.Division:
                    op = Operator.Division;
                    break;

                case (int)Operator.Exit:
                    op = Operator.Exit;
                    break;

                default:
                    break;
            }
            return op;
        }

        private int GetChooseInput()
        {
            while (true)
            {
                int input;
                var isIntInput = int.TryParse(Console.ReadLine(), out input);

                if (isIntInput)
                    return input;
            }
        }

        internal void ShowMenu()
        {
            Console.WriteLine("====MENU====");
            Console.WriteLine("1. ADD");
            Console.WriteLine("2. SUBTRACT");
            Console.WriteLine("3. MULTIPLY");
            Console.WriteLine("4. DIVISION");
            Console.WriteLine();
        }

        internal int GetUserInput()
        {
            throw new NotImplementedException();
        }

        internal void ShowResult(int result)
        {
            throw new NotImplementedException();
        }
    }
}