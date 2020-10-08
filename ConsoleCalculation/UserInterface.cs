using System;

namespace ConsoleCalculation
{
    internal class UserInterface
    {
        internal Operator GetInputOperator()
        {
            //var input = GetIntergerInput();
            //switch
            return Operator.Add;
        }
        internal void DisplayMenu()
        {
            Console.WriteLine("===============MENU===============");
            Console.WriteLine("1. ADD");
            Console.WriteLine("2. SUBTRACT");
            Console.WriteLine("3. MULTIPLY");
            Console.WriteLine("4. DIVISION");
        }
    }
}