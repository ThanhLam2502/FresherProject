using System;

namespace ConsoleCalculation
{
    
    internal class UserInterface
    {
        internal ChooseOption GetOptionOperator()
        {
            // 1. Show menu : Add, Subtract, Multiply, Division
            //ShowMenu();

            // 2. The user chooses an option
            int choose = GetNumberOption();

            // 3. Based on the option, return the operation
            ChooseOption op = new ChooseOption();
            switch (choose)
            {
                case 43:
                case (int)ChooseOption.Add:
                    op = ChooseOption.Add;
                    break;

                case 45:
                case (int)ChooseOption.Subtract:
                    op = ChooseOption.Subtract;
                    break;

                case 42:
                case (int)ChooseOption.Multiply:
                    op = ChooseOption.Multiply;
                    break;

                case 47:
                case (int)ChooseOption.Division:
                    op = ChooseOption.Division;
                    break;

                case (int)ChooseOption.Clear:
                    op = ChooseOption.Clear;
                    break;

                case (int)ChooseOption.CleanScreen:
                    op = ChooseOption.CleanScreen;
                    break;

                case (int)ChooseOption.Exit:
                    op = ChooseOption.Exit;
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
                #region 2nd option
                //switch (userInput)
                //{
                //    case "+":
                //        return Convert.ToChar(userInput);
                //    case "-":
                //        return Convert.ToChar(userInput);
                //    case "*":
                //        return Convert.ToChar(userInput);
                //    case "/":
                //        return Convert.ToChar(userInput);
                //} 
                #endregion
                var isNumber = int.TryParse(userInput, out number);

                if (isNumber)
                    return number;
                else
                    ShowMessage(Message.OPTION_INCORRECT);
            }
        }

        internal void ShowMessage(string message)
        {
            Console.WriteLine(message); Console.WriteLine();
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

        internal Number GetNumber()
        {
            var number = new Number();
            number.Value = GetNumberUserInput();
            return number;
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

        internal void ShowNumber(Number number)
        {
            Console.WriteLine("Resuilt: {0}", number.Value);
        }
    }
}