using System;
using System.Collections.Generic;

public class Resume
{
    public string _name;
    public List<Job> _jobs = new List<Job>();

    public Resume() { }

    public Resume(string name)
    {
        _name = name;
    }

    public void Display()
    {
        Console.WriteLine(_name);
        foreach (var job in _jobs)
        {
            job.Display();
        }
    }
}
