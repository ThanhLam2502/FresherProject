using System;
using System.Collections;


namespace Calculator
{

    class CalculatorService
    {
        internal void Add(CalculatorModel calculator, CalculatorModel calculatorUI)
        {
            calculator.Value += calculatorUI.Value;
        }

        internal void Subtract(CalculatorModel calculator, CalculatorModel calculatorUI)
        {
            calculator.Value -= calculatorUI.Value;
        }

        internal void Multiply(CalculatorModel calculator, CalculatorModel calculatorUI)
        {
            calculator.Value *= calculatorUI.Value;
        }

        internal void Division(CalculatorModel calculator, CalculatorModel calculatorUI)
        {
            if (calculatorUI.Value == 0)
                throw new DivideByZeroException();
            calculator.Value /= calculatorUI.Value;
        }

        internal void SetValue(CalculatorModel calculator, CalculatorModel calculatorUI)
        {
            calculator.Value = calculatorUI.Value;
        }
       
    }
}
