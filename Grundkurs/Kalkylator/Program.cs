namespace Kalkylator;

class Program
{
    static void Main()
    {
        bool keepRunning = true;
        while (keepRunning)
        {
            Console.Write("Write expression: ");
            string? expression = Console.ReadLine();
            while (string.IsNullOrEmpty(expression))
            {
                Console.WriteLine("Please insert valid expression (separated by spaces).");
                Console.Write("Write expression: ");
                expression = Console.ReadLine();
            }

            string[] expressionParts = expression.Split(
                ' ',
                StringSplitOptions.TrimEntries &
                StringSplitOptions.RemoveEmptyEntries
                );

            if (expressionParts.Length == 3)
            {
                if (
                    double.TryParse(expressionParts[0], out double a) &&
                    double.TryParse(expressionParts[2], out double b)
                )
                {
                    double result;
                    bool validOperator = true;
                    switch (expressionParts[1])
                    {
                        case "+":
                            result = KalkylatorOps.Add(a, b);
                            break;
                        case "-":
                            result = KalkylatorOps.Subtract(a, b);
                            break;
                        case "*":
                            result = KalkylatorOps.Multiply(a, b);
                            break;
                        case "/":
                            result = KalkylatorOps.Divide(a, b);
                            break;
                        default:
                            Console.WriteLine(
                                "Please insert valid expression (separated by spaces)."
                                );
                            validOperator = false;
                            result = 0;
                            break;
                    }
                    if (validOperator)
                    {
                        Console.WriteLine($"= {result}");
                        Console.Write("Go again? (y/n): ");
                        string? continueAnswer = Console.ReadLine();
                        while (
                            string.IsNullOrEmpty(continueAnswer) ||
                            (
                                !continueAnswer.Equals(
                                "y",
                                StringComparison.CurrentCultureIgnoreCase
                                ) &&
                                !continueAnswer.Equals(
                                "n",
                                StringComparison.CurrentCultureIgnoreCase
                                )
                            )
                            )
                        {
                            Console.WriteLine("Please insert a valid option.");
                            Console.Write("Go again? (y/n): ");
                            continueAnswer = Console.ReadLine();
                        }
                        if (continueAnswer.Equals(
                                "n",
                                StringComparison.CurrentCultureIgnoreCase
                                ))
                        {
                            keepRunning = false;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Please insert valid numbers.");
                }
            }
            else
            {
                Console.WriteLine("Please insert valid expression (separated by spaces).");
            }
        }
    }
}
