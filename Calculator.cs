using Lxqtpr.Calculator.Providers;
using Lxqtpr.Calculator.Services;

namespace Lxqtpr.Calculator
{
    internal static class Calculator
    {
        static void Main(string[] args)
        {
            var outputService = new OutputService();
            var inputStringService = new InputStringService();
            var inputService = new InputFloatProvider(outputService, inputStringService);
            var inputOperandService = new InputOperandProvider(outputService, inputStringService);
            var calculatorService = new CalculatorService(outputService);
                
            outputService.Print("Calculator v1.0.0");

            outputService.Print("Enter first number (float)");
            var number1 = inputService.GetNumber();

            outputService.Print("Enter second number (float)");
            var number2 = inputService.GetNumber();

            var operand = inputOperandService.GetOperand();
            if (operand == OperandType.None)
            {
                outputService.Print("Wrong operand. Good bue");
                return;
            }

            var result = calculatorService.Calculate(number1, number2, operand);
            if (result is not null)
            {
                outputService.Print(result.Value.ToString("F"));
            }
            
        }
        
        
    }
}

