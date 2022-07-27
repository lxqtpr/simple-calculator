using Lxqtpr.Calculator.Services.Base;

namespace Lxqtpr.Calculator.Services;

public class MessageBoxOutputService: OutputServiceBase
{
    protected override void Output(string message)
    {
        MessageBox.Show(message);  
    }
}