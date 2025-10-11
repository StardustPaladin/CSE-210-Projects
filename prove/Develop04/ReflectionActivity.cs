using System;
using System.Collections.Generic;

class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you achieved a personal goal.",
        "Think of a time when you made someone smile.",
        "Think of a time when you overcame a fear."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    private Random _rng = new Random();

    public ReflectionActivity() : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.") { }

    protected override void RunActivity(int durationSeconds)
    {
        Console.WriteLine("Consider the following prompt:");
        string prompt = _prompts[_rng.Next(_prompts.Count)];
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine("When you have something in mind, press Enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        Countdown(5);

        int elapsed = 0;
        int questionIndex = 0;
        while (elapsed < durationSeconds)
        {
            if (questionIndex >= _questions.Count) questionIndex = 0;
            Console.WriteLine($"> {_questions[questionIndex]}");
            questionIndex++;
            int waitTime = Math.Min(10, durationSeconds - elapsed);
            Countdown(waitTime);
            elapsed += waitTime;
            Console.WriteLine();
        }
    }
}
