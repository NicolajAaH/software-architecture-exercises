using Microsoft.AspNetCore.Mvc;

namespace software_architecture_exercises1_1.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculatorController : ControllerBase
{

    private readonly ILogger<CalculatorController> _logger;

    public CalculatorController(ILogger<CalculatorController> logger)
    {
        _logger = logger;
    }

    [HttpPost("/calculate/{firstValue}/{symbol}/{secondValue}")]
    public Double Get(double firstValue, string symbol, double secondValue)
    {
        double res = 0;
        switch (symbol)
        {
            case "+":
                res = firstValue + secondValue;
                _logger.LogInformation("Addition: " + res);
                break;
            case "-":
                res = firstValue - secondValue;
                _logger.LogInformation("Subtraction: " + res);
                break;
            case "*":
                res = firstValue * secondValue;
                _logger.LogInformation("Multiplication: " + res);
                break;
            case "/":
                res = firstValue / secondValue;
                _logger.LogInformation("Division: " + res);
                break;
            default:
                _logger.LogInformation("Wrong input");
                break;
        }

        return res;
    }
}