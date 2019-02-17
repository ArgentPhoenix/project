using System;
using System.Collections.Generic;
using System.Text;

namespace Calc
{
    public class CalcView
    {
        public void PrintResult(CalcModel calcModel)
        {
            Console.WriteLine("Result: " + calcModel.Result);
        }

        public void GetData(CalcModel calcModel)
        {
            try
            {
                Console.WriteLine("First operand:");
                calcModel.FirstOperand = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Second operand:");
                calcModel.SecondOperand = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Operation type:");
                calcModel.Operation = GetOperation(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static Operation GetOperation(string inputString)
        {
            try
            {
                var typeOperation = Convert.ToChar(inputString);
                switch (typeOperation)
                {
                    case '+':
                        return Operation.Add;
                    case '-':
                        return Operation.Subtract;
                    case '*':
                        return Operation.Multipy;
                    case '/':
                        return Operation.Divide;
                    case '^':
                        return Operation.Pow;
                    default:
                        Console.WriteLine("Incorrect type of operation");
                        return Operation.ErrorOperation;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Incorrect type of operation");
                return Operation.ErrorOperation;
            }
            
        }
    }
}
