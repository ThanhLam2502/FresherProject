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
        private CalculatorModel calculatorUI;
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
            string text = "Ans ";
            
            switch (op)
            {
                case Operator.Add:
                    calculatorUI.Calculation += calculatorUI.Value;
                    text = calculatorUI.Calculation + " + " + calculatorUI.Calculation;
                    break;
                case Operator.Subtract:
                    calculatorUI.Calculation += calculatorUI.Value; // + calculatorUI.Calculation;
                    break;
                case Operator.Multiply:
                    calculatorUI.Calculation += " * ";
                    break;
                case Operator.Division:
                    calculatorUI.Calculation += " / ";
                    break;
            }
            //txtResult.Text = text;
            //txtResult.Text = ShowCalculation(calculator, calculatorUI);
        }

        private string ShowCalculation(CalculatorModel calculator, CalculatorModel calculatorUI)
        {
            var UI = string.IsNullOrEmpty(calculatorUI.Calculation) ? "0" : calculatorUI.Calculation;
            return $"{UI}{Environment.NewLine} {calculator.Calculation}";
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            CalculationResults(calculator, calculatorUI);
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
                    service.Add(calculator, calculatorUI);
                    break;
            }
            calculatorUI.Calculation = "";
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
           
        }
    }
}
