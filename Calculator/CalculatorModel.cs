namespace Calculator
{
    public class CalculatorModel
    {
        public Operator Op { get; internal set; } = Operator.None;
        public double Value { get; internal set; } = 0;
        public string Calculation { get; internal set; }
        public double Result { get; internal set; }
    }
}
