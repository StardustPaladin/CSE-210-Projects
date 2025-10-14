using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void DisplayScore()
    {
        int level = GetLevel();
        string rank = GetRank();
        int pointsNeeded = GetPointsToNextLevel();
        
        Console.WriteLine("======================================");
        Console.WriteLine($"Score: {_score} points");
        Console.WriteLine($"Level {level}: {rank}");
        
        if (level < 5)
        {
            Console.WriteLine($"{pointsNeeded} points until next level");
        }
        else
        {
            Console.WriteLine("MAX LEVEL!");
        }
        
        Console.WriteLine("======================================");
    }

    private int GetLevel()
    {
        if (_score < 1000) return 1;
        if (_score < 2500) return 2;
        if (_score < 5000) return 3;
        if (_score < 10000) return 4;
        return 5;
    }

    private string GetRank()
    {
        int level = GetLevel();
        if (level == 1) return "Novice";
        if (level == 2) return "Apprentice";
        if (level == 3) return "Journeyman";
        if (level == 4) return "Expert";
        return "Master";
    }

    private int GetPointsToNextLevel()
    {
        if (_score < 1000) return 1000 - _score;
        if (_score < 2500) return 2500 - _score;
        if (_score < 5000) return 5000 - _score;
        if (_score < 10000) return 10000 - _score;
        return 0;
    }

    public void DisplayGoals()
    {
        Console.WriteLine("\n=== YOUR GOALS ===");
        
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals created yet.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("=== CREATE NEW GOAL ===");
        Console.WriteLine("Select goal type:");
        Console.WriteLine("1. Simple Goal (completed once)");
        Console.WriteLine("2. Eternal Goal (never complete)");
        Console.WriteLine("3. Checklist Goal (complete X times)");
        Console.WriteLine("4. Negative Goal (bad habit)");
        Console.Write("\nChoice: ");
        
        string choice = Console.ReadLine();
        
        Console.Write("Goal name: ");
        string name = Console.ReadLine();
        
        Console.Write("Description: ");
        string description = Console.ReadLine();

        if (choice == "1")
        {
            Console.Write("Points: ");
            int points = int.Parse(Console.ReadLine());
            _goals.Add(new SimpleGoal(name, description, points));
            Console.WriteLine("Goal created!");
        }
        else if (choice == "2")
        {
            Console.Write("Points per time: ");
            int points = int.Parse(Console.ReadLine());
            _goals.Add(new EternalGoal(name, description, points));
            Console.WriteLine("Goal created!");
        }
        else if (choice == "3")
        {
            Console.Write("Points per time: ");
            int points = int.Parse(Console.ReadLine());
            Console.Write("How many times to complete: ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("Bonus points: ");
            int bonus = int.Parse(Console.ReadLine());
            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
            Console.WriteLine("Goal created!");
        }
        else if (choice == "4")
        {
            Console.Write("Points to lose: ");
            int points = int.Parse(Console.ReadLine());
            _goals.Add(new NegativeGoal(name, description, points));
            Console.WriteLine("Goal created!");
        }
        else
        {
            Console.WriteLine("Invalid choice!");
        }
    }

    public void RecordEvent()
    {
        Console.WriteLine("\n=== RECORD EVENT ===");
        
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available!");
            return;
        }

        Console.WriteLine("Select a goal:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
        }
        
        Console.Write("\nChoice: ");
        int choice = int.Parse(Console.ReadLine());
        
        if (choice > 0 && choice <= _goals.Count)
        {
            Goal selectedGoal = _goals[choice - 1];
            int oldLevel = GetLevel();
            
            selectedGoal.RecordEvent();
            
            if (selectedGoal is NegativeGoal)
            {
                _score = _score - selectedGoal.GetPoints();
            }
            else if (selectedGoal is ChecklistGoal checklistGoal)
            {
                _score = _score + checklistGoal.GetPoints();
                
                if (checklistGoal.GetIsComplete() && 
                    checklistGoal.GetCurrentCount() == checklistGoal.GetTargetCount())
                {
                    _score = _score + checklistGoal.GetBonusPoints();
                }
            }
            else if (!selectedGoal.GetIsComplete() || selectedGoal is EternalGoal)
            {
                _score = _score + selectedGoal.GetPoints();
            }
            
            int newLevel = GetLevel();
            if (newLevel > oldLevel)
            {
                Console.WriteLine("\n*** LEVEL UP! ***");
                Console.WriteLine($"You are now Level {newLevel}: {GetRank()}!");
            }
        }
        else
        {
            Console.WriteLine("Invalid choice!");
        }
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
        
        Console.WriteLine("Goals saved!");
    }

    public void LoadGoals(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found!");
            return;
        }

        _goals.Clear();
        
        string[] lines = File.ReadAllLines(filename);
        
        _score = int.Parse(lines[0]);
        
        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] parts = line.Split(':');
            string goalType = parts[0];
            string[] data = parts[1].Split('|');
            
            if (goalType == "SimpleGoal")
            {
                string name = data[0];
                string description = data[1];
                int points = int.Parse(data[2]);
                bool isComplete = bool.Parse(data[3]);
                
                SimpleGoal goal = new SimpleGoal(name, description, points);
                if (isComplete)
                {
                    goal.RecordEvent();
                }
                _goals.Add(goal);
            }
            else if (goalType == "EternalGoal")
            {
                string name = data[0];
                string description = data[1];
                int points = int.Parse(data[2]);
                
                _goals.Add(new EternalGoal(name, description, points));
            }
            else if (goalType == "ChecklistGoal")
            {
                string name = data[0];
                string description = data[1];
                int points = int.Parse(data[2]);
                bool isComplete = bool.Parse(data[3]);
                int target = int.Parse(data[4]);
                int current = int.Parse(data[5]);
                int bonus = int.Parse(data[6]);
                
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus, current, isComplete));
            }
            else if (goalType == "NegativeGoal")
            {
                string name = data[0];
                string description = data[1];
                int points = int.Parse(data[2]);
                
                _goals.Add(new NegativeGoal(name, description, points));
            }
        }
        
        Console.WriteLine("Goals loaded!");
    }
}