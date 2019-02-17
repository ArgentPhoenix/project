using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using CalcApi.Models;
using System.Globalization;

namespace CalcApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalcController : ControllerBase
    {
        CalcModel calcModel = new CalcModel();

        // GET api/calc/5/add/2
        [HttpGet("{firstOperand}/{stringOperation}/{secondOperand}")]
        public ActionResult<int> Get(int firstOperand, string stringOperation, int secondOperand)
        {
            try
            {
                var operation = GetOperation(stringOperation);
                calcModel.FirstOperand = firstOperand;
                calcModel.SecondOperand = secondOperand;
                calcModel.Operation = operation;
                if (calcModel.Operation != Operation.ErrorOperation)
                {
                    Calculate(calcModel);

                }
                else
                {
                    return BadRequest();
                }
                return calcModel.Result;
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // POST api/calc
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/calc/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/calc/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        public static Operation GetOperation(string inputString)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            try
            {
                return (Operation) Enum.Parse(typeof(Operation), textInfo.ToTitleCase(inputString));
            }
            catch (Exception ex)
            {
                return Operation.ErrorOperation;
            }

        }

        public static void Calculate(CalcModel calcModel)
        {
            try
            {
                switch (calcModel.Operation)
                {
                    case Operation.Add:
                        calcModel.Result = calcModel.FirstOperand + calcModel.SecondOperand;
                        break;
                    case Operation.Subtract:
                        calcModel.Result = calcModel.FirstOperand - calcModel.SecondOperand;
                        break;
                    case Operation.Multipy:
                        calcModel.Result = calcModel.FirstOperand * calcModel.SecondOperand;
                        break;
                    case Operation.Divide:
                        calcModel.Result = calcModel.FirstOperand / calcModel.SecondOperand;
                        break;
                    case Operation.Pow:
                        calcModel.Result = (int) Math.Pow(calcModel.FirstOperand, calcModel.SecondOperand);
                        break;
                    default:
                        calcModel.Result = Int32.MinValue;
                        break;
                }
            }
            catch (Exception ex)
            {
                calcModel.Result = Int32.MinValue;
            }
        }
    }
}
