using System;

class Program
{
    static void Main(string[] args)
    {
    Console.WriteLine("Welcome to the Number Analyzer");
    List<int> numbers = new List<int>();
    int number;
    Console.WriteLine("Enter a series of numbers, type 0 when finished:");
        do
        {
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());
            if (number != 0)
            {
                numbers.Add(number);
            }
        } while (number != 0);

        int sum = numbers.Sum();
        double average = numbers.Count > 0 ? numbers.Average() : 0;
        int max = numbers.Count > 0 ? numbers.Max() : 0;

    Console.WriteLine($"The sum is: {sum}");
    Console.WriteLine($"The average is: {average}");
    Console.WriteLine($"The largest number is: {max}");
    Console.WriteLine("Thanks for using the Number Analyzer! Have a great day!");
    }
}