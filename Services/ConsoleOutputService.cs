using Lxqtpr.Calculator.Services.Base;

namespace Lxqtpr.Calculator.Services;

public class ConsoleOutputService: OutputServiceBase
{
    protected override void Output(string message)
    {
        Console.WriteLine(message);
    }
}

