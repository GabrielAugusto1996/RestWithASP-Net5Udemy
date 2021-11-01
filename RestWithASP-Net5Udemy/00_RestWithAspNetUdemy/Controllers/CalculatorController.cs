using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RestWithASP_Net5Udemy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult ExecuteSum(double firstNumber, double secondNumber)
        {
                return Ok(firstNumber + secondNumber);
        }

        [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
        public IActionResult ExecuteSubtraction(double firstNumber, double secondNumber)
        {
                return Ok(firstNumber - secondNumber);
        }

        [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
        public IActionResult ExecuteMultiplication(double firstNumber, double secondNumber)
        {
                return Ok(firstNumber * secondNumber);
        }

        [HttpGet("divi/{firstNumber}/{secondNumber}")]
        public IActionResult ExecuteDivision(double firstNumber, double secondNumber)
        {
                return Ok(firstNumber * secondNumber);
        }

        [HttpGet("average/{firstNumber}/{secondNumber}")]
        public IActionResult ExecuteAverage(double firstNumber, double secondNumber)
        {
                return Ok((firstNumber + secondNumber) / 2);
        }
    }
}
