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
