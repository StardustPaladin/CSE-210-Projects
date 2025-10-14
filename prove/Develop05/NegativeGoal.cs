using System;

public class NegativeGoal : Goal
{
    public NegativeGoal(string name, string description, int points) 
        : base(name, description, points)
    {
    }

    public override void RecordEvent()
    {
        Console.WriteLine($"You recorded '{GetName()}' and lost {GetPoints()} points.");
        Console.WriteLine("Stay strong! You can overcome this!");
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetDetailsString()
    {
        return $"[ ] {GetName()} - {GetDescription()} (Bad Habit: -{GetPoints()} points)";
    }

    public override string GetGoalType()
    {
        return "NegativeGoal";
    }

    public override string GetStringRepresentation()
    {
        return $"{GetGoalType()}:{base.GetStringRepresentation()}";
    }
}