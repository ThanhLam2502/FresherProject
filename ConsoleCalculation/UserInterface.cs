using System;

namespace ConsoleCalculation
{
    internal class UserInterface
    {
        internal Operator GetInputOperator()
        {
            var input = GetIntergerInput();
            //switch
            return Operator.Add;
        }
        internal int GetIntergerInput(string text)
        {
            while (true)
                try
                {
                    Console.Write(text);
                    return Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    continue;
                };
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