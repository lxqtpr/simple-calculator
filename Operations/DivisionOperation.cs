namespace Lxqtpr.Calculator.Shell.Operations;

public class DivisionOperation : IOperation
{
    public string ShortName => "/";

    public string Name => "Division";

    public string Description => "Division two numbers operation";
    public float Execute(float number1, float number2)
    {
        if (number2 == 0d)
        {
            return 0;
        }

        return number1 / number2;
    }
}