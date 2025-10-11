using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Personal touch: greet user and get preference
        Console.Write("Welcome! What's your name? ");
        string name = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(name)) name = "Friend";

        Console.Write($"Hi {name}! How many words should be hidden each step? (1-3, default 3): ");
        int hideCount = 3;
        var hcInput = Console.ReadLine();
        if (int.TryParse(hcInput, out int hc))
        {
            if (hc >= 1 && hc <= 3) hideCount = hc;
        }

        // Simple single scripture example
        var reference = new Reference("John", 3, 16);
        var text = "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.";
        var scripture = new Scripture(reference, text);

        // encouraging messages
        string[] cheers = new string[] { "Great job!", "Keep it up!", "Nice work!", "You're doing well!" };
        var rnd = new Random();

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.Display());

            int hidden = scripture.GetHiddenCount();
            int total = scripture.GetTotalWords();
            double pct = total == 0 ? 0 : (100.0 * hidden / total);
            Console.WriteLine($"\nProgress: {hidden}/{total} words hidden ({pct:0.0}% )");

            if (scripture.AllWordsHidden())
            {
                Console.WriteLine($"\nAll words hidden. Well done, {name}!");
                break;
            }

            Console.WriteLine("\nPress Enter to hide words, or type 'quit' to exit.");
            var input = Console.ReadLine();
            if (input != null && input.ToLower() == "quit") break;

            // hide hideCount words per Enter
            for (int i = 0; i < hideCount; i++) scripture.HideRandomWord();

            // small personalized encouragement
            Console.WriteLine(cheers[rnd.Next(cheers.Length)] + " (press Enter to continue)");
            Console.ReadLine();
        }
    }
}