using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
        CalculatorModel calculatorUI;
        private CalculatorModel calculator;
        private CalculatorService service;
        public Calculator()
        {
            InitializeComponent();

            calculatorUI = new CalculatorModel();
            calculator = new CalculatorModel();

            service = new CalculatorService();
        }

        private void Calculator_Load(object sender, EventArgs e)
        {
            txtResult.Text = ShowCalculation(calculator, calculatorUI);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            BtnOperatorClick(Operator.Add, calculator, calculatorUI);
        }

        private void btnSubtract_Click(object sender, EventArgs e)
        {
            BtnOperatorClick(Operator.Subtract, calculator, calculatorUI);
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            BtnOperatorClick(Operator.Multiply, calculator, calculatorUI);
        }

        private void btnDivision_Click(object sender, EventArgs e)
        {
            BtnOperatorClick(Operator.Division, calculator, calculatorUI);
        }

        private void BtnOperatorClick(Operator op, CalculatorModel calculator, CalculatorModel calculatorUI)
        {
            // 1. Show UI
            var Op = string.Empty;

            calculatorUI.Op = op;
            calculatorUI.Value = 0;
            calculatorUI.Calculation = "Ans ";

            switch (calculatorUI.Op)
            {
                case Operator.Add:
                    Op = "+";
                    break;
                case Operator.Subtract:
                    Op = "-";
                    break;
                case Operator.Multiply:
                    Op = "*";
                    break;
                case Operator.Division:
                    Op = "/";
                    break;
                case Operator.None:
                    break;
            }

            calculatorUI.Calculation += " " + Op + " ";
            txtResult.Text = ShowCalculation(calculator, calculatorUI);
        }

        private string ShowCalculation(CalculatorModel calculator, CalculatorModel calculatorUI)
        {
            return $"{calculatorUI.Calculation}{Environment.NewLine} {calculator.Value}";
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            // 1. Calculation
            CalculationResults(calculator, calculatorUI);

            // 2. Set UI
            calculatorUI.Value = 0;
            calculatorUI.Calculation = "";
            calculatorUI.Op = Operator.None;

            // 3. Show
            txtResult.Text = ShowCalculation(calculator, calculatorUI);
        }

        private void CalculationResults(CalculatorModel calculator, CalculatorModel calculatorUI)
        {
            switch (calculatorUI.Op)
            {
                case Operator.Add:
                    service.Add(calculator, calculatorUI);
                    break;
                case Operator.Subtract:
                    service.Subtract(calculator, calculatorUI);
                    break;
                case Operator.Multiply:
                    service.Multiply(calculator, calculatorUI);
                    break;
                case Operator.Division:
                    service.Division(calculator, calculatorUI);
                    break;
                case Operator.None:
                    service.SetValue(calculator, calculatorUI);
                    break;
            }

        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            BtnNumberClick(0, calculator, calculatorUI);
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            BtnNumberClick(1, calculator, calculatorUI);
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            BtnNumberClick(2, calculator, calculatorUI);
        }

        private void btnThree_Click(object sender, EventArgs e)
        {
            BtnNumberClick(3, calculator, calculatorUI);
        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            BtnNumberClick(4, calculator, calculatorUI);
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            BtnNumberClick(5, calculator, calculatorUI);
        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            BtnNumberClick(6, calculator, calculatorUI);
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            BtnNumberClick(7, calculator, calculatorUI);
        }

        private void btnEight_Click(object sender, EventArgs e)
        {
            BtnNumberClick(8, calculator, calculatorUI);
        }

        private void btnNine_Click(object sender, EventArgs e)
        {
            BtnNumberClick(9, calculator, calculatorUI);
        }

        private void BtnNumberClick(int number, CalculatorModel calculator, CalculatorModel calculatorUI)
        {
            calculatorUI.Value = calculatorUI.Value * 10 + number;
            calculatorUI.Calculation += number.ToString();

            txtResult.Text = ShowCalculation(calculator, calculatorUI);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            calculator.Value = 0;
            calculatorUI.Calculation = string.Empty;

            txtResult.Text = ShowCalculation(calculator, calculatorUI);
        }
    }
}
