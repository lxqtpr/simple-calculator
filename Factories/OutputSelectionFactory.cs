using Lxqtpr.Calculator.Services;
using Lxqtpr.Calculator.Services.Base;

namespace Lxqtpr.Calculator.Factories;

public class OutputSelectionFactory
{
    private readonly IEnumerable<IOutputService> _outputService;

    public OutputSelectionFactory(IEnumerable<IOutputService> outputServices)
    {
        _outputService = outputServices;
    }

    public IOutputService GetOutputService(bool isUserConsole = true)
    {
        if (isUserConsole)
        {
            return _outputService.First(x => x.GetType() == typeof(ConsoleOutputService));
        }
        return _outputService.First(x => x.GetType() == typeof(MessageBoxOutputService));

    }
}