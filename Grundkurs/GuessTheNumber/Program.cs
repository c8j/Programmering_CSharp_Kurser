namespace GuessTheNumber;

class Program
{
    static void Main()
    {
        Random rng = new();
        bool roundEnd;
        uint counter;
        bool exitTriggered = false;
        int number;
        string? continueAnswer;
        while (!exitTriggered)
        {
            number = rng.Next(1, 101);
            roundEnd = false;
            counter = 0;
            while (!roundEnd)
            {
                Console.Write("Insert number guess: ");
                if (!int.TryParse(Console.ReadLine(), out int guess))
                {
                    Console.WriteLine("Please insert a valid number.");
                }
                else
                {
                    counter++;
                    if (guess < number)
                    {
                        Console.WriteLine("Higher");
                    }
                    else if (guess > number)
                    {
                        Console.WriteLine("Lower");
                    }
                    else
                    {
                        Console.WriteLine(
                            $"Correct! Guessed in {counter} {(counter > 1 ? "tries" : "try")}."
                            );
                        roundEnd = true;
                        Console.Write("Go again? (y/n): ");
                        continueAnswer = Console.ReadLine();
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
                                "y",
                                StringComparison.CurrentCultureIgnoreCase
                                ))
                        {
                            //do nothing special.. idk lol
                        }
                        else if (continueAnswer.Equals(
                                "n",
                                StringComparison.CurrentCultureIgnoreCase
                                ))
                        {
                            exitTriggered = true;
                        }
                    }
                }
            }
        }
    }
}
