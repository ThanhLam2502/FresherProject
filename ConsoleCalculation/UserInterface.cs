using System;

namespace ConsoleCalculation
{
    public enum Operator
    {
        Add = 1,
        Subtract,
        Multiply,
        Division,
        Clear,
        CleanScreen,
        Exit,

    }
    internal class UserInterface
    {
        internal Operator GetOptionOperator()
        {
            // 1. Show menu : Add, Subtract, Multiply, Division
            //ShowMenu();

            // 2. The user chooses an option
            int choose = GetNumberOption();

            // 3. Based on the option, return the operation
            Operator op = new Operator();
            switch (choose)
            {
                case 43:
                case (int)Operator.Add:
                    op = Operator.Add;
                    break;

                case 45:
                case (int)Operator.Subtract:
                    op = Operator.Subtract;
                    break;

                case 42:
                case (int)Operator.Multiply:
                    op = Operator.Multiply;
                    break;

                case 47:
                case (int)Operator.Division:
                    op = Operator.Division;
                    break;

                case (int)Operator.Clear:
                    op = Operator.Clear;
                    break;

                case (int)Operator.CleanScreen:
                    op = Operator.CleanScreen;
                    break;

                case (int)Operator.Exit:
                    op = Operator.Exit;
                    break;

                default:
                    break;
            }
            return op;
        }


        private int GetNumberOption()
        {
            while (true)
            {
                int number;
                Console.WriteLine();
                Console.Write("Enter a option: ");
                var userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "+":
                        return Convert.ToChar(userInput);
                    case "-":
                        return Convert.ToChar(userInput);
                    case "*":
                        return Convert.ToChar(userInput);
                    case "/":
                        return Convert.ToChar(userInput);
                }
                var isNumber = int.TryParse(userInput, out number);

                if (isNumber)
                    return number;
                else
                    ShowMessage(Message.OPTION_INCORRECT);
            }
        }

        internal void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        internal void CleanScreen()
        {
            Console.Clear();
        }

        internal void ShowMenu()
        {
            Console.WriteLine("====MENU====");
            Console.WriteLine("1. ADD");
            Console.WriteLine("2. SUBTRACT");
            Console.WriteLine("3. MULTIPLY");
            Console.WriteLine("4. DIVISION");
            Console.WriteLine("5. CLEAR");
            Console.WriteLine("6. CLEAN SCREEN");
            Console.WriteLine("7. EXIT");
        }

        internal int GetNumberUserInput()
        {
            while (true)
            {
                int input;
                Console.Write("Enter a number: ");
                var isIntInput = int.TryParse(Console.ReadLine(), out input);

                if (isIntInput)
                    return input;
            }
        }

        internal void ShowResult(int result)
        {
            Console.WriteLine("Resuilt: {0}", result);
        }
    }
}