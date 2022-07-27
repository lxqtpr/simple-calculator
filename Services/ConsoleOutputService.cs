using Lxqtpr.Calculator.Shell.Services.Base;

namespace Lxqtpr.Calculator.Shell.Services;

public class ConsoleOutputService: OutputServiceBase
{
    protected override void Output(string message)
    {
        Console.WriteLine(message);
    }
}

