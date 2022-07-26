namespace Lxqtpr.Calculator.Services;

public class CalculatorService
{
    private readonly OutputService _outputService;

    public CalculatorService(OutputService outputService)
    {
        _outputService = outputService;
    }
    
    public float? Calculate(float number1, float number2, OperandType operand)
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