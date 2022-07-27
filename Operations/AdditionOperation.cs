
namespace Lxqtpr.Calculator.Shell.Operations;

public class AdditionOperation : IOperation
{
    public string Name => "Addition";
     
    public string ShortName => "+";
     
    public string Description => "Adds to numbers operation";
     
    public float Execute(float number1, float number2)
    {
        return number1 + number2;
    }
}