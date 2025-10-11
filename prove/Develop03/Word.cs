using System;

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
