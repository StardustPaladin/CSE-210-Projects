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
