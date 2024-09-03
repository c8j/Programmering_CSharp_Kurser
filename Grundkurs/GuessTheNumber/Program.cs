namespace GuessTheNumber;

class Program
{
    static void Main()
    {
        int number = new Random().Next(0, 100);
        bool guessed = false;
        uint counter = 0;
        while (!guessed)
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
                    guessed = true;
                }
            }
        }
    }
}
