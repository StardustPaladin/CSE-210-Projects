using System;

public abstract class Goal
{
    private string _name;
    private string _description;
    private int _points;
    private bool _isComplete;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
        _isComplete = false;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetDescription()
    {
        return _description;
    }

    public int GetPoints()
    {
        return _points;
    }

    public bool GetIsComplete()
    {
        return _isComplete;
    }

    protected void SetComplete(bool complete)
    {
        _isComplete = complete;
    }

    public abstract void RecordEvent();

    public virtual bool IsComplete()
    {
        return _isComplete;
    }

    public virtual string GetDetailsString()
    {
        string status = _isComplete ? "[X]" : "[ ]";
        return $"{status} {_name} - {_description}";
    }

    public virtual string GetStringRepresentation()
    {
        return $"{_name}|{_description}|{_points}|{_isComplete}";
    }

    public abstract string GetGoalType();
}