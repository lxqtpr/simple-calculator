using Lxqtpr.Calculator.Services.Base;

namespace Lxqtpr.Calculator.Services;

public class CalculatorProvider
{
    private readonly IOutputService _outputService;

    public CalculatorProvider(IOutputService outputService)
    {
        _outputService = outputService;
    }
    
    public float? Compute(float number1, float number2, OperandType operand)
    {
        switch (operand)
        {
            case OperandType.Addition:
                return number1 + number2;
            case OperandType.Subtraction:
                return number1 - number2;
            case OperandType.Multiplication:
                return number1 * number2;
            case OperandType.Division:
                if (number2 != 0) return number1 / number2;
                _outputService.Print("Devide by zero. Error.");
                return null;
        }
        return null;
    }
}