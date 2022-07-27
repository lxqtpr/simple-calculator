using Lxqtpr.Calculator.Services;
using Lxqtpr.Calculator.Services.Base;

namespace Lxqtpr.Calculator.Providers;

public class InputFloatProvider
    {
        private readonly IOutputService _outputService;
        private readonly InputStringService _inputStringService;

        public InputFloatProvider(IOutputService outputService, InputStringService inputStringService)
        {
            _inputStringService = inputStringService;
            _outputService = outputService;
        }

       public float GetNumber()
        {
            float number;
            bool isInputValid;
            do {
                var numberString =  _inputStringService.GetStringFromUser();
                var isOkNumber = float.TryParse(numberString, out number);
                isInputValid = isOkNumber;
                if (!isOkNumber) _outputService.Print("Wrong number, please try again");
            } while (!isInputValid);

            return number;
        }
       
    }
    