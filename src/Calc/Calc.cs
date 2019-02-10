using System;
using System.Collections.Generic;

namespace Calc
{
    public enum Operation
    {
        Add = '+',
        Subtract = '-',
        Multipy = '*',
        Divide = '/',
        Pow = '^',
        ErrorOperation
    }

    class Calc
    {
        static void Main(string[] args)
        {
            var exit = "";
            while (exit != "exit")
            {
                CalcModel calcModel = new CalcModel();
                CalcView calcView = new CalcView();
                CalcController calcController = new CalcController(calcModel, calcView);
                calcController.Update();
                Console.WriteLine("Enter \"exit\" to exit program or anykey for continue");
                exit = Console.ReadLine();
            }
        }
    }
}
