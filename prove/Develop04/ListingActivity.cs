using System;
using System.Collections.Generic;

class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?"
    };

    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.") { }

    protected override void RunActivity(int durationSeconds)
    {
        Random rnd = new Random();
        string prompt = _prompts[rnd.Next(_prompts.Count)];
        Console.WriteLine(prompt);
        Console.WriteLine("You will have a few seconds to think, then start listing items. Press Enter after each item.");
        Console.WriteLine("Get ready...");
        Spinner(3);
        Console.WriteLine($"Start listing for {durationSeconds} seconds. Press Enter after each.");
        int start = Environment.TickCount;
        List<string> items = new List<string>();
        while ((Environment.TickCount - start) / 1000 < durationSeconds)
        {
            Console.Write("- ");
            string line = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(line)) items.Add(line);
        }
        Console.WriteLine($"You listed {items.Count} items.");
    }
}
