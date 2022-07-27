using Lxqtpr.Calculator.Services.Base;

namespace Lxqtpr.Calculator.Providers;

public class OutputProvider
{
    private readonly IEnumerable<IOutputService> _outputServices;

    public OutputProvider(IEnumerable<IOutputService> outputServices)
    {
        _outputServices = outputServices;
    }

    public void Print(string message)
    {
        if (_outputServices.Any())
        {
            foreach (var outputService in _outputServices)
            {
                outputService.Print(message);
            }
        }
    }
}