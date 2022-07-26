namespace Lxqtpr.Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Calculator v1.0.0");

            Console.WriteLine("Enter first number (float)");
            var number1 = GetNumber();

            Console.WriteLine("Enter second number (float)");
            var number2 = GetNumber();

            var operand = GetOperand();
            if (operand == OperandType.None)
            {
                Console.WriteLine("Wrong operand. Good bue");
                return;
            }

            var result = Calculate(number1, number2, operand);

            Console.WriteLine(result);
        }

        private static float? Calculate(float number1, float number2, OperandType operand)
        {
            switch (operand)
            {
                case OperandType.Addition:
                    return number1 + number2;
                case OperandType.Subtraction:
                    return number1 - number2;
                case OperandType.Multiplication:
                    return number1 * number2;
                case OperandType.Division:
                    if (number2 == 0)
                    {
                        Console.WriteLine("Divide by zero. Error");
                        return null;
                    }
                    return number1 / number2;
            }

            return null;
        }

        private static OperandType GetOperand()
        {
            Console.WriteLine("Enter operand + - * /");
            var operandString = Console.ReadLine();

            return operandString switch
            {
                "+" => OperandType.Addition,
                "-" => OperandType.Subtraction,
                "*" => OperandType.Multiplication,
                "/" => OperandType.Division,
                _ => OperandType.None,
            };

        }
        private static float GetNumber()
        {

            float number;
            bool isInputValid;
            do
            {
                var numberString = Console.ReadLine();
                var isOkNumber = float.TryParse(numberString, out number);
                isInputValid = isOkNumber;
                if (!isOkNumber)
                {
                    Console.WriteLine("Wrong number, please try again");
                }

            } while (!isInputValid);

            return number;
        }
    }
}

