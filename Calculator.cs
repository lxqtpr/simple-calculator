using Lxqtpr.Calculator.Factories;
using Lxqtpr.Calculator.Providers;
using Lxqtpr.Calculator.Services;
using Lxqtpr.Calculator.Services.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lxqtpr.Calculator
{
    internal static class Calculator
    {
        private static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var services = new ServiceCollection();
            services.AddTransient<IOutputService, ConsoleOutputService>();  
            services.AddTransient<IOutputService, FileOutputService>();  
            services.AddTransient<InputStringService>();
            services.AddTransient<InputFloatProvider>();
            services.AddTransient<InputOperandProvider>();
            services.AddTransient<CalculatorProvider>();
            services.AddTransient<OutputSelectionFactory>();
            services.AddTransient<OutputProvider>();
            services.AddOptions<ApplicationSettings>();
            services.Configure<ApplicationSettings>(configuration.GetSection(nameof(ApplicationSettings)));
            
            var serviceProvider = services.BuildServiceProvider();
            
            var inputFloatProvider = serviceProvider.GetRequiredService<InputFloatProvider>();
            var inputOperandProvider = serviceProvider.GetRequiredService<InputOperandProvider>();
            var calculatorProvider = serviceProvider.GetRequiredService<CalculatorProvider>();
            var outputSelectionFactory = serviceProvider.GetRequiredService<OutputSelectionFactory>();

            var outputService = outputSelectionFactory.GetOutputService();
            
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
                var provider = serviceProvider.GetRequiredService<OutputProvider>();
                provider.Print(result.Value.ToString("F"));
            }
        }
    }
}

