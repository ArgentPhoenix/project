using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calc.Tests
{
    [TestClass]
    public class CalcTests
    {
        [TestMethod]
        public void Calculate_3and5andAdd_8returned()
        {
            // arrange
            double firstOperand = 3.0;
            double secondOperand = 5.0;
            Operation operation = Operation.Add;
            double expected = 8;
            // act
            double actual = CalcController.Calculate(firstOperand, secondOperand, operation);
            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetOperation_plus_returnedAdd()
        {
            // arrange
            string operation = "+";
            Operation expected = Operation.Add;
            // act
            Operation actual = CalcView.GetOperation(operation);
            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}
