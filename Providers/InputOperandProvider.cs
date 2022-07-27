using Lxqtpr.Calculator.Factories;
using Lxqtpr.Calculator.Shell.Services;
using Lxqtpr.Calculator.Shell.Services.Base;

namespace Lxqtpr.Calculator.Shell.Providers;

public class InputOperandProvider
{
    private readonly IOutputService _outputService;
    private readonly InputStringService _inputStringService;
    private readonly IEnumerable<IOperation> _operations;

    public InputOperandProvider(
        OutputSelectionFactory outputSelectionFactory,
        InputStringService inputStringService,
        IEnumerable<IOperation> operations
        )
    {
        _inputStringService = inputStringService;
        _operations = operations;
        _outputService = outputSelectionFactory.GetOutputService();
    }
    
    public IOperation? GetOperand()
    {
        if (!_operations.Any())
        {
            return null;
        }

        var messages = _operations.Select(x => $"[{x.ShortName}] {x.Name}. {x.Description}");
        
        _outputService.Print("Select operation:");
        _outputService.Print(string.Join("\n", messages));
        
        var operandString = _inputStringService.GetStringFromUser();
        
        return _operations.FirstOrDefault(x => x.ShortName.Equals(operandString));
    }
}