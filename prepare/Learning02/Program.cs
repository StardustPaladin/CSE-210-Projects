using System;

class Program
{
	static void Main(string[] args)
	{
		// Step 1: create job1 and job2 and set member variables directly
		Job job1 = new Job();
		job1._company = "Microsoft";
		job1._jobTitle = "Software Engineer";
		job1._startYear = 2019;
		job1._endYear = 2022;

		Job job2 = new Job();
		job2._company = "Apple";
		job2._jobTitle = "Manager";
		job2._startYear = 2022;
		job2._endYear = 2023;

		// Display companies (initial test)
		Console.WriteLine(job1._company);
		Console.WriteLine(job2._company);

		// Now use Display method
		job1.Display();
		job2.Display();

		// Create resume and add jobs
		Resume myResume = new Resume();
		myResume._name = "Jane Doe";
		myResume._jobs.Add(job1);
		myResume._jobs.Add(job2);

		// Access and display first job title via dot notation
		Console.WriteLine(myResume._jobs[0]._jobTitle);

		// Finally display the full resume
		myResume.Display();
	}
}
