namespace Lxqtpr.Calculator.Shell.Services.Base;

public abstract class OutputServiceBase: IOutputService
{
    public void Print(string message)
    {
        if (message == null) throw new ArgumentNullException(nameof(message));
        Output(message);
    }

    protected abstract void Output(string message);
}
