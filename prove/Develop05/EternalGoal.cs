using System;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) 
        : base(name, description, points)
    {
    }

    public override void RecordEvent()
    {
        Console.WriteLine($"You recorded '{GetName()}' and earned {GetPoints()} points!");
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetDetailsString()
    {
        return $"[ ] {GetName()} - {GetDescription()}";
    }

    public override string GetGoalType()
    {
        return "EternalGoal";
    }

    public override string GetStringRepresentation()
    {
        return $"{GetGoalType()}:{base.GetStringRepresentation()}";
    }
}