using System;
using System.Collections.Generic;

namespace Foundation4
{
    class Program
    {
        static void Main(string[] args)
        {
            var activities = new List<Activity>();

            // Create one of each activity (using miles)
            activities.Add(new RunningActivity("03 Nov 2022", 30, 3.0)); // 3.0 miles in 30 min
            activities.Add(new CyclingActivity("03 Nov 2022", 30, 12.0)); // 12 mph average for 30 min
            activities.Add(new SwimmingActivity("03 Nov 2022", 30, 20)); // 20 laps in 30 min

            // Display summaries
            foreach (var act in activities)
            {
                Console.WriteLine(act.GetSummary());
            }
        }
    }
}