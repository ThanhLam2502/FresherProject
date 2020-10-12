using System;
using System.Collections;


namespace Calculator
{

    class CalculatorService
    {
        internal void Add(CalculatorModel calculator)
        {
            calculator.Result += calculator.Value;
        }

        internal void Subtract(CalculatorModel calculator)
        {
            calculator.Result -= calculator.Value;
        }

        internal void Multiply(CalculatorModel calculator)
        {
            calculator.Result *= calculator.Value;
        }

        internal void Division(CalculatorModel calculator)
        {
            if (calculator.Value == 0)
                throw new DivideByZeroException();
            calculator.Result /= calculator.Value;
        }

        internal void SetValue(CalculatorModel calculator)
        {
            calculator.Result = calculator.Value;
        }
       
    }
}
