using System;
using System.Collections.Generic;

// Very simple Scripture memorizer for beginners.
// Classes: Reference, Word, Scripture, Program

class Reference
{
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = verse;
        _endVerse = verse;
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    public override string ToString()
    {
        if (_startVerse == _endVerse)
            return $"{_book} {_chapter}:{_startVerse}";
        return $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
    }
}
class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public override string ToString()
    {
        if (!_isHidden) return _text;

        // show underscores for letters, keep punctuation
        char[] chars = new char[_text.Length];
        for (int i = 0; i < _text.Length; i++)
        {
            chars[i] = char.IsLetter(_text[i]) ? '_' : _text[i];
        }
        return new string(chars);
    }
}
class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        var parts = text.Split(' ');
        foreach (var p in parts) _words.Add(new Word(p));
    }

    public string Display()
    {
        string result = _reference.ToString() + "\n";
        for (int i = 0; i < _words.Count; i++)
        {
            result += _words[i].ToString();
            if (i < _words.Count - 1) result += " ";
        }
        return result;
    }

    public void HideRandomWord()
    {
        if (_words.Count == 0) return;
        Random rnd = new Random();
        int idx = rnd.Next(0, _words.Count);
        _words[idx].Hide();
    }

    public bool AllWordsHidden()
    {
        foreach (var w in _words) if (!w.IsHidden()) return false;
        return true;
    }

    public void Reset()
    {
        foreach (var w in _words) w.Show();
    }

    // helper: number of hidden words
    public int GetHiddenCount()
    {
        int count = 0;
        foreach (var w in _words) if (w.IsHidden()) count++;
        return count;
    }

    // helper: total words
    public int GetTotalWords()
    {
        return _words.Count;
    }
}
class Program
{
    static void Main(string[] args)
    {
        // Personal touch: greet user and get preference
        Console.Write("Welcome! What's your name? ");
        string name = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(name)) name = "Friend";

        Console.Write($"Hi {name}! How many words should be hidden each step? (1-3, default 3): ");
        int hideCount = 3;
        var hcInput = Console.ReadLine();
        if (int.TryParse(hcInput, out int hc))
        {
            if (hc >= 1 && hc <= 3) hideCount = hc;
        }

        // Simple single scripture example
        var reference = new Reference("John", 3, 16);
        var text = "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.";
        var scripture = new Scripture(reference, text);

        // encouraging messages
        string[] cheers = new string[] { "Great job!", "Keep it up!", "Nice work!", "You're doing well!" };
        var rnd = new Random();

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.Display());

            int hidden = scripture.GetHiddenCount();
            int total = scripture.GetTotalWords();
            double pct = total == 0 ? 0 : (100.0 * hidden / total);
            Console.WriteLine($"\nProgress: {hidden}/{total} words hidden ({pct:0.0}% )");

            if (scripture.AllWordsHidden())
            {
                Console.WriteLine($"\nAll words hidden. Well done, {name}!");
                break;
            }

            Console.WriteLine("\nPress Enter to hide words, or type 'quit' to exit.");
            var input = Console.ReadLine();
            if (input != null && input.ToLower() == "quit") break;

            // hide hideCount words per Enter
            for (int i = 0; i < hideCount; i++) scripture.HideRandomWord();

            // small personalized encouragement
            Console.WriteLine(cheers[rnd.Next(cheers.Length)] + " (press Enter to continue)");
            Console.ReadLine();
        }
    }
}