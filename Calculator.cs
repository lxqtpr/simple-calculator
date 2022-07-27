using Lxqtpr.Calculator.Factories;
using Lxqtpr.Calculator.Providers;
using Lxqtpr.Calculator.Services;
using Lxqtpr.Calculator.Services.Base;
using Microsoft.Extensions.DependencyInjection;

namespace Lxqtpr.Calculator
{
    internal static class Calculator
    {
        private static void Main(string[] args)
        {

            var services = new ServiceCollection();
            services.AddTransient<IOutputService, ConsoleOutputService>();
            services.AddTransient<IOutputService, MessageBoxOutputService>();
            services.AddTransient<InputStringService>();
            services.AddTransient<InputFloatProvider>();
            services.AddTransient<InputOperandProvider>();
            services.AddTransient<CalculatorProvider>();
            services.AddTransient<OutputSelectionFactory>();

            var serviceProvider = services.BuildServiceProvider();
            
            var outputServices = serviceProvider.GetServices<IOutputService>();
            var inputFloatProvider = serviceProvider.GetRequiredService<InputFloatProvider>();
            var inputOperandProvider = serviceProvider.GetRequiredService<InputOperandProvider>();
            var calculatorProvider = serviceProvider.GetRequiredService<CalculatorProvider>();

            var outputService = ProcessArguments(args, outputServices);
            
            outputService.Print("Calculator v4.0.0");

            outputService.Print("Enter first number (float)");
            var number1 = inputFloatProvider.GetNumber();

            outputService.Print("Enter second number (float)");
            var number2 = inputFloatProvider.GetNumber();

            var operand = inputOperandProvider.GetOperand();
            if (operand == OperandType.None)
            {
                outputService.Print("Wrong operand. Good bue");
                return;
            }

            var result = calculatorProvider.Compute(number1, number2, operand);
            if (result is not null)
            {
                outputService.Print(result.Value.ToString("F"));
            }
            
        }

        private static IOutputService ProcessArguments(string[] args, IEnumerable<IOutputService> outputServices)
        {
            if (!args.Any())
            {
                throw new ArgumentNullException();
            }
            var values = args[0].Split('=');
            if (values[1] == "console")
            {
              return outputServices.First(x => x.GetType() == typeof(ConsoleOutputService));
            }
            return outputServices.First(x => x.GetType() == typeof(MessageBoxOutputService));
            
        }
    }
}

