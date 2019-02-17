using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalcApi.Models
{
    public class CalcModel
    {
        public int FirstOperand { get; set; }
        public int SecondOperand { get; set; }
        public int Result { get; set; }
        public Operation Operation { get; set; }
    }
}
