using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Welcome! What's your name? ");
        string name = Console.ReadLine();
        Console.WriteLine($"Hello, {name}! Choose an activity:");

        bool running = true;
        while (running)
        {
            Console.WriteLine("1) Breathing\n2) Reflection\n3) Listing\n4) Quit");
            Console.Write("Choice: ");
            string c = Console.ReadLine();
            Activity act = null;
            if (c == "1") act = new BreathingActivity();
            else if (c == "2") act = new ReflectionActivity();
            else if (c == "3") act = new ListingActivity();
            else if (c == "4") break;
            else { Console.WriteLine("Invalid choice"); continue; }

            act.Start();
            Console.WriteLine("Press Enter to return to the menu...");
            Console.ReadLine();
        }

        Console.WriteLine($"Goodbye, {name}! Take care.");
    }
}
