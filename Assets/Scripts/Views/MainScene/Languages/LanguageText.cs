public struct LanguageText
{
    public string Text { get; }
    public Languages Language { get; }
    
    public LanguageText(string text, Languages languages)
    {
        Text = text;
        Language = languages;
    }
}