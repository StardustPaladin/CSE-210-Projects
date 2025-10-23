using System;

class Program
{
    static void Main(string[] args)
    {
        var video = new Video("Learning C#", "Alice", 360);
        video.AddComment(new Comment("Bob", "Great explanation!"));
        video.AddComment(new Comment("Carol", "Thanks, very helpful."));

        Console.WriteLine(video.GetDetails());
        Console.WriteLine();
        Console.WriteLine("Comments:");
        Console.WriteLine("Total comments: " + video.GetNumberOfComments());
    }
}