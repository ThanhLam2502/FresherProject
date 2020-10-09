namespace ConsoleCalculation
{
    internal class Service
    {
        internal Service()
        {
        }
        internal int Add(int result, int input)
        {
            return result + input;
        }

        internal int Subtract(int result, int input)
        {
            return result - input;
        }

        internal int Division(int result, int input)
        {   
            if (input == 0)   
                throw new System.DivideByZeroException();
            return result / input;
        }

        internal int Multiply(int result, int input)
        {
            return result * input;
        }

        internal void SetResult(ref int result)
        {
            result = 0;
        }
    }
}