using System;
using System.Threading;

abstract class Activity
{
    private string _name;
    private string _description;
    private int _durationSeconds;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void Start()
    {
        Console.Clear();
        Console.WriteLine($"Starting: {_name}");
        Console.WriteLine(_description);
        Console.Write("How many seconds would you like for this session? ");
        if (int.TryParse(Console.ReadLine(), out int seconds))
        {
            _durationSeconds = seconds;
        }
        else
        {
            Console.WriteLine("Invalid input, defaulting to 30 seconds.");
            _durationSeconds = 30;
        }

        Console.WriteLine("Get ready...");
        Spinner(3);
        RunActivity(_durationSeconds);
        Console.WriteLine();
        Console.WriteLine("Well done! You have completed the activity.");
        Console.WriteLine($"Activity: {_name} | Duration: {_durationSeconds} seconds");
        Spinner(3);
    }

    protected abstract void RunActivity(int durationSeconds);

    protected void Spinner(int seconds)
    {
        string[] seq = { "|", "/", "-", "\\" };
        int total = seconds * 4;
        for (int i = 0; i < total; i++)
        {
            Console.Write(seq[i % seq.Length]);
            Thread.Sleep(250);
            Console.Write('\r');
        }
    }

    protected void Countdown(int seconds)
    {
        for (int i = seconds; i >= 1; i--)
        {
            Console.Write(i + " ");
            Thread.Sleep(1000);
            Console.Write('\r');
        }
        Console.Write(new string(' ', 10) + "\r");
    }
}
