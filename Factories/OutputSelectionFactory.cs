using Lxqtpr.Calculator.Shell.Services;
using Lxqtpr.Calculator.Shell.Services.Base;
using Microsoft.Extensions.Options;

namespace Lxqtpr.Calculator.Factories;

public class OutputSelectionFactory
{
    private readonly IEnumerable<IOutputService> _outputService;
    private readonly ApplicationSettings _applicationSettings;
    
    public OutputSelectionFactory(IEnumerable<IOutputService> outputServices, IOptions<ApplicationSettings> options)
    {
        _outputService = outputServices;
        _applicationSettings = options.Value;
    }

    public IOutputService GetOutputService(bool isUserConsole = true)
    {
        var value = _applicationSettings.DefaultService;
        return value switch
        {
            "Console" => _outputService.First(x => x.GetType() == typeof(ConsoleOutputService)),
            "File" => _outputService.First(x => x.GetType() == typeof(FileOutputService)),
            _ => throw new ArgumentNullException()
        };
    }
}