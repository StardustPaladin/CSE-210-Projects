using System;

class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.") { }

    protected override void RunActivity(int durationSeconds)
    {
        int elapsed = 0;
        while (elapsed < durationSeconds)
        {
            Console.Write("Breathe in...");
            Countdown(4);
            elapsed += 4;
            if (elapsed >= durationSeconds) break;
            Console.WriteLine("Breathe out...");
            Countdown(6);
            elapsed += 6;
        }
    }
}
