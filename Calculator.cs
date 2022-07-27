using Lxqtpr.Calculator.Factories;
using Lxqtpr.Calculator.Shell.Providers;
using Microsoft.Extensions.DependencyInjection;

namespace Lxqtpr.Calculator
{
    internal static class Calculator
    {
        private static void Main(string[] args)
        {
            var serviceProvider = DependencyContainer.GetContainer();
            
            var inputFloatProvider = serviceProvider.GetRequiredService<InputFloatProvider>();
            var inputOperandProvider = serviceProvider.GetRequiredService<InputOperandProvider>();
            var outputSelectionFactory = serviceProvider.GetRequiredService<OutputSelectionFactory>();

            var outputService = outputSelectionFactory.GetOutputService();
            
            outputService.Print("Calculator v4.0.0");

            outputService.Print("Enter first number (float)");
            var number1 = inputFloatProvider.GetNumber();

            outputService.Print("Enter second number (float)");
            var number2 = inputFloatProvider.GetNumber();

            var operation = inputOperandProvider.GetOperand();
            if (operation is null)
            {
                outputService.Print("Wrong operand. Good bue");
                return;
            }

            var result = operation.Execute(number1, number2);
            outputService.Print(result.ToString("F"));
        }
    }
    
}

