using Lxqtpr.Calculator.Services;

namespace Lxqtpr.Calculator.Providers;

public class InputOperandProvider
{
    private readonly OutputService _outputService;
    private readonly InputStringService _inputStringService;

    public InputOperandProvider(OutputService outputService, InputStringService inputStringService)
    {
        _inputStringService = inputStringService;
        _outputService = outputService;
    }
    
    public OperandType GetOperand()
    {
        _outputService.Print("Enter operand + - * /");
        var operandString = _inputStringService.GetStringFromUser();

        return operandString switch
        {
            "+" => OperandType.Addition,
            "-" => OperandType.Subtraction,
            "*" => OperandType.Multiplication,
            "/" => OperandType.Division,
            _ => OperandType.None,
        };

    }
}