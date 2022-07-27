using Lxqtpr.Calculator.Factories;
using Lxqtpr.Calculator.Shell;
using Lxqtpr.Calculator.Shell.Operations;
using Lxqtpr.Calculator.Shell.Providers;
using Lxqtpr.Calculator.Shell.Services;
using Lxqtpr.Calculator.Shell.Services.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lxqtpr.Calculator;

public class DependencyContainer
{
    internal static IServiceProvider GetContainer()
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
        services.AddTransient<OutputSelectionFactory>();
        services.AddTransient<OutputProvider>();
        services.AddOptions<ApplicationSettings>();
        services.Configure<ApplicationSettings>(configuration.GetSection(nameof(ApplicationSettings)));

        services.AddTransient<IOperation, AdditionOperation>();
        services.AddTransient<IOperation, SubtractOperation>();
        services.AddTransient<IOperation, MultiplicationOperation>();
        services.AddTransient<IOperation, DivisionOperation>();
        
        return services.BuildServiceProvider();
    }
}