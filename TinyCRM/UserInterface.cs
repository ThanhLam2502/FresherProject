using System;

namespace TinyCRM
{
    internal class UserInterface
    {
        public UserInterface()
        {
        }

        internal Operations GetOperation()
        {
            while (true)
            {
                Console.WriteLine("Please enter an option (1, 2, 3, 4, 0 to exit): ");
                var option = Console.ReadLine();
                int optionValue;
                if (int.TryParse(option, out optionValue))
                {
                    if (optionValue >= 0 && optionValue <= 4)
                        return (Operations)optionValue;
                }
            }
        }

        internal Customer EnterCustomerInfo()
        {
            throw new NotImplementedException();
        }

        internal void ShowMessage(string v)
        {
            throw new NotImplementedException();
        }
    }
}