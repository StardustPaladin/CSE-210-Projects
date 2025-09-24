using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Entry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }
    public string Mood { get; set; }

    public override string ToString()
    {
        var moodPart = string.IsNullOrWhiteSpace(Mood) ? "" : $" [{Mood}]";
        return $"{Date} - {Prompt}{moodPart}\n{Response}";
    }
}

class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void Display()
    {
        Console.WriteLine("\n--- Journal Entries ---");
        Console.WriteLine($"Total entries: {_entries.Count}");
        foreach (var e in _entries)
        {
            Console.WriteLine(e.ToString());
            Console.WriteLine();
        }
    }

    public void Save(string filename)
    {
        try
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(_entries, options);
            File.WriteAllText(filename, json);

            // create a timestamped backup copy
            var dir = Path.GetDirectoryName(filename);
            if (string.IsNullOrEmpty(dir)) dir = Directory.GetCurrentDirectory();
            var backup = Path.Combine(dir, $"{Path.GetFileNameWithoutExtension(filename)}_{DateTime.Now:yyyyMMdd_HHmmss}{Path.GetExtension(filename)}");
            File.Copy(filename, backup);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving file: {ex.Message}");
        }
    }

    public void Load(string filename)
    {
        try
        {
            _entries.Clear();
            var json = File.ReadAllText(filename);
            var items = JsonSerializer.Deserialize<List<Entry>>(json);
            if (items != null) _entries.AddRange(items);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading file: {ex.Message}");
        }
    }
}

class Prompter
{
    private Random _rng = new Random();
    private List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "What challenged me today?",
        "What made me smile today?",
        "If I could do one thing over today, what would it be?",
        // personal touch: a creative prompt
        "What small win am I grateful for today? 😊"
    };

    public string GetRandomPrompt()
    {
        int idx = _rng.Next(0, _prompts.Count);
        return _prompts[idx];
    }
}

class Program
{
    static void Main(string[] args)
    {
        var journal = new Journal();
        var prompter = new Prompter();

        while (true)
        {
            Console.WriteLine("\nJournal Menu");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option: ");
            var choice = Console.ReadLine();

            if (choice == "1")
            {
                string prompt = prompter.GetRandomPrompt();
                Console.WriteLine($"Prompt: {prompt}");
                Console.Write("Your response: ");
                string response = Console.ReadLine();

                // personal touch: ask for a mood
                Console.WriteLine("Choose a mood: 1) 😊 2) 🙂 3) 😐 4) 😞 5) Other");
                Console.Write("Mood choice (1-5): ");
                var moodChoice = Console.ReadLine();
                string mood = moodChoice switch
                {
                    "1" => "Happy",
                    "2" => "Good",
                    "3" => "Neutral",
                    "4" => "Sad",
                    "5" => "Other",
                    _ => ""
                };
                if (mood == "Other")
                {
                    Console.Write("Describe your mood: ");
                    mood = Console.ReadLine();
                }

                var entry = new Entry { Date = DateTime.Now.ToString("yyyy-MM-dd"), Prompt = prompt, Response = response, Mood = mood };
                journal.AddEntry(entry);
                Console.WriteLine("Entry saved! ✨");

                // autosave personal touch: save to an autosave file after each entry
                try
                {
                    var autosave = "journal_autosave.json";
                    journal.Save(autosave);
                    Console.WriteLine($"Autosaved to {autosave}");
                }
                catch { }
            }
            else if (choice == "2")
            {
                journal.Display();
            }
            else if (choice == "3")
            {
                Console.Write("Enter filename to save: ");
                var filename = Console.ReadLine();
                journal.Save(filename);
                Console.WriteLine("Journal saved.");
            }
            else if (choice == "4")
            {
                Console.Write("Enter filename to load: ");
                var filename = Console.ReadLine();
                if (File.Exists(filename))
                {
                    journal.Load(filename);
                    Console.WriteLine("Journal loaded.");
                }
                else
                {
                    Console.WriteLine("File not found.");
                }
            }
            else if (choice == "5")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid option. Try again.");
            }
        }
    }
}