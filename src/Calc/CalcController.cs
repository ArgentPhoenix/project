using System;
using System.Text;

namespace Calc
{
    public class CalcController
    {
        private CalcModel calcModel;
        private CalcView calcView;

        public CalcController(CalcModel calcModel, CalcView calcView)
        {
            this.calcModel = calcModel;
            this.calcView = calcView;
        }

        public void Update()
        {
            calcView.GetData(calcModel);
            calcModel.Result = Calculate(calcModel.FirstOperand, calcModel.SecondOperand, calcModel.Operation);
            if (!Double.IsNaN(calcModel.Result))
            {
                calcView.PrintResult(calcModel);
            }
        }

        public static double Calculate(double firstOperand, double secondOperand, Operation operation)
        {
            try { 
                switch (operation)
                {
                    case Operation.Add:
                        return firstOperand + secondOperand;
                    case Operation.Subtract:
                        return firstOperand - secondOperand;
                    case Operation.Multipy:
                        return firstOperand * secondOperand;
                    case Operation.Divide:
                        return firstOperand / secondOperand;
                    case Operation.Pow:
                        return Math.Pow(firstOperand, secondOperand);
                    default:
                        return Double.NaN;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Double.NaN;
            }
        }
    }
}
