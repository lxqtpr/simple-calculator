﻿using Lxqtpr.Calculator.Services;
using Lxqtpr.Calculator.Services.Base;

namespace Lxqtpr.Calculator.Providers;

public class InputOperandProvider
{
    private readonly IOutputService _outputService;
    private readonly InputStringService _inputStringService;

    public InputOperandProvider(IOutputService outputService, InputStringService inputStringService)
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