using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        var shapes = new List<Shape>
        {
            new Square("red", 4),
            new Rectangle("blue", 3, 5),
            new Circle("green", 2.5)
        };

        foreach (var s in shapes)
        {
            Console.WriteLine($"Color: {s.GetColor()}, Area: {s.GetArea():F2}");
        }
    }
}