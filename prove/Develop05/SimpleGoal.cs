using System;

public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points) 
        : base(name, description, points)
    {
    }

    public override void RecordEvent()
    {
        if (!GetIsComplete())
        {
            SetComplete(true);
            Console.WriteLine($"Congratulations! You completed '{GetName()}' and earned {GetPoints()} points!");
        }
        else
        {
            Console.WriteLine($"This goal has already been completed!");
        }
    }

    public override string GetGoalType()
    {
        return "SimpleGoal";
    }

    public override string GetStringRepresentation()
    {
        return $"{GetGoalType()}:{base.GetStringRepresentation()}";
    }
}