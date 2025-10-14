using System;

public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints) 
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _currentCount = 0;
        _bonusPoints = bonusPoints;
    }

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints, int currentCount, bool isComplete) 
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _currentCount = currentCount;
        _bonusPoints = bonusPoints;
        
        if (isComplete)
        {
            SetComplete(true);
        }
    }

    public int GetTargetCount()
    {
        return _targetCount;
    }

    public int GetCurrentCount()
    {
        return _currentCount;
    }

    public int GetBonusPoints()
    {
        return _bonusPoints;
    }

    public override void RecordEvent()
    {
        if (GetIsComplete())
        {
            Console.WriteLine($"This goal has already been completed!");
            return;
        }

        _currentCount++;
        Console.WriteLine($"You recorded '{GetName()}' and earned {GetPoints()} points!");
        
        if (_currentCount >= _targetCount)
        {
            SetComplete(true);
            Console.WriteLine($"Bonus! You completed '{GetName}' and earned {_bonusPoints} bonus points!");
        }
    }

    public override string GetDetailsString()
    {
        string status = GetIsComplete() ? "[X]" : "[ ]";
        return $"{status} {GetName()} - {GetDescription()} (Completed {_currentCount}/{_targetCount} times)";
    }

    public override string GetGoalType()
    {
        return "ChecklistGoal";
    }

    public override string GetStringRepresentation()
    {
        return $"{GetGoalType()}:{GetName()}|{GetDescription()}|{GetPoints()}|{GetIsComplete()}|{_targetCount}|{_currentCount}|{_bonusPoints}";
    }
}