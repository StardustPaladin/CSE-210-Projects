using System;

class Program
{
    static void Main(string[] args)
    {
    Random randomGenerator = new Random();
    int magicNumber = randomGenerator.Next(1, 101); // 1 to 100 inclusive
    // Console.WriteLine($"(For testing) Magic number is: {magicNumber}");

        Console.WriteLine("Welcome! Guess the magic number between 1 and 100:");
        int guess = -1;
        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }
    }
}