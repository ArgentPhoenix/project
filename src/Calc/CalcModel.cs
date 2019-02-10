using System;
using System.Collections.Generic;
using System.Text;

namespace Calc
{
    public class CalcModel
    {
        public double FirstOperand { get; set; }
        public double SecondOperand { get; set; }
        public double Result { get; set; }
        public Operation Operation { get; set; }
    }
}
