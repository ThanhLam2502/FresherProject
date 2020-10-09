using System;

namespace ConsoleCalculation
{
    internal class Service
    {
        internal Service()
        {
        }

        internal void SetZeroNumber(Number number)
        {
            number.Value = 0;
        }

        internal void Add(Number number, Number addNumber)
        {
            number.Value += addNumber.Value;
        }

        internal void Subtract(Number number, Number subNumber)
        {
            number.Value -= subNumber.Value;
        }

        internal void Multiply(Number number, Number multiNumber)
        {
            number.Value *= multiNumber.Value;
        }

        internal void Division(Number number, Number divNumber)
        {
            if (divNumber.Value == 0)
                throw new DivideByZeroException();
            number.Value /= number.Value;
        }
    }
}