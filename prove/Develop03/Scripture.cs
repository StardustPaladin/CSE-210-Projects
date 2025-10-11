using System;
using System.Collections.Generic;

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
