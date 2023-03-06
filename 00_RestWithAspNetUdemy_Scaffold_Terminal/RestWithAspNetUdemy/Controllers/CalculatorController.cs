using Microsoft.AspNetCore.Mvc;

namespace RestWithAspNetUdemy.Controllers;

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
    public IActionResult Sum(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);

            return Ok(sum.ToString());
        }
        return BadRequest("Invalid input");
    }

    [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
    public IActionResult Subtraction(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sum = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);

            return Ok(sum.ToString());
        }
        return BadRequest("Invalid input");
    }

    [HttpGet("times/{firstNumber}/{secondNumber}")]
    public IActionResult Times(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sum = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);

            return Ok(sum.ToString());
        }
        return BadRequest("Invalid input");
    }

    [HttpGet("divide/{firstNumber}/{secondNumber}")]
    public IActionResult Divide(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber) && ConvertToDecimal(secondNumber) != 0)
        {
            var sum = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);

            return Ok(sum.ToString());
        }
        return BadRequest("Invalid input");
    }

    [HttpGet("average/{firstNumber}/{secondNumber}")]
    public IActionResult Average(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sum = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;

            return Ok(sum.ToString());
        }
        return BadRequest("Invalid input");
    }

    [HttpGet("sqrt/{number}")]
    public IActionResult SquareRadius(string number)
    {
        if (IsNumeric(number))
        {
            var sum = Math.Sqrt((double)(ConvertToDecimal(number)));

            return Ok(sum.ToString());
        }
        return BadRequest("Invalid input");
    }
    private bool IsNumeric(string strNumber)
    {
        double number;
        bool isNumber = double.TryParse(
            strNumber,
            System.Globalization.NumberStyles.Any,
            System.Globalization.NumberFormatInfo.InvariantInfo,
            out number);

        return isNumber;
    }

    private decimal ConvertToDecimal(string strNumber)
    {
        decimal decimalValue;

        if (decimal.TryParse(strNumber, out decimalValue))
        {
            return decimalValue;
        }

        return 0;
    }

}
