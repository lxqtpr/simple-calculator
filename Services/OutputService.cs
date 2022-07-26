namespace Lxqtpr.Calculator.Services;

public class OutputService
    {
        public void Print(string message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));
            Console.WriteLine(message);
        }
    }

