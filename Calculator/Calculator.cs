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
        private CalculatorService service;
        public Calculator()
        {
            InitializeComponent();

            calculatorUI = new CalculatorModel();
            service = new CalculatorService();
        }

        private void Calculator_Load(object sender, EventArgs e)
        {
            txtResult.Text = ShowCalculation(calculatorUI);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            BtnOperatorClick(Operator.Add, calculatorUI);
        }

        private void btnSubtract_Click(object sender, EventArgs e)
        {
            BtnOperatorClick(Operator.Subtract, calculatorUI);
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            BtnOperatorClick(Operator.Multiply, calculatorUI);
        }

        private void btnDivision_Click(object sender, EventArgs e)
        {
            BtnOperatorClick(Operator.Division, calculatorUI);
        }

        private void BtnOperatorClick(Operator op, CalculatorModel calculatorUI)
        {
            var Op = string.Empty;
            calculatorUI.Op = op;
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
            txtResult.Text = ShowCalculation(calculatorUI);
            calculatorUI.Value = 0;

        }

        private string ShowCalculation(CalculatorModel calculatorUI)
        {
            return $"{calculatorUI.Calculation}{Environment.NewLine} {calculatorUI.Result}";
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            CalculationResults(calculatorUI);
            calculatorUI.Calculation = "";
            calculatorUI.Value = 0;
            txtResult.Text = ShowCalculation(calculatorUI);
        }

        private void CalculationResults(CalculatorModel calculatorUI)
        {
            switch (calculatorUI.Op)
            {
                case Operator.Add:
                    service.Add(calculatorUI);
                    break;
                case Operator.Subtract:
                    service.Subtract(calculatorUI);
                    break;
                case Operator.Multiply:
                    service.Multiply(calculatorUI);
                    break;
                case Operator.Division:
                    service.Division(calculatorUI);
                    break;
                case Operator.None:
                    service.SetValue(calculatorUI);
                    break;
            }

        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            BtnNumberClick(0, calculatorUI);
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            BtnNumberClick(1, calculatorUI);
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            BtnNumberClick(2, calculatorUI);
        }

        private void btnThree_Click(object sender, EventArgs e)
        {
            BtnNumberClick(3, calculatorUI);
        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            BtnNumberClick(4, calculatorUI);
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            BtnNumberClick(5, calculatorUI);
        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            BtnNumberClick(6, calculatorUI);
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            BtnNumberClick(7, calculatorUI);
        }

        private void btnEight_Click(object sender, EventArgs e)
        {
            BtnNumberClick(8, calculatorUI);
        }

        private void btnNine_Click(object sender, EventArgs e)
        {
            BtnNumberClick(9, calculatorUI);
        }

        private void BtnNumberClick(int number, CalculatorModel calculatorUI)
        {
            calculatorUI.Value = calculatorUI.Value * 10 + number;
            calculatorUI.Calculation += number.ToString();

            txtResult.Text = ShowCalculation(calculatorUI);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            calculatorUI.Calculation = string.Empty;
            calculatorUI.Result = 0;
            txtResult.Text = ShowCalculation(calculatorUI);
        }
    }
}