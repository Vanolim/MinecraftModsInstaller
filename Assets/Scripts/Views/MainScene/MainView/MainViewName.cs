using System.Collections.Generic;
using System.Linq;
using TMPro;

public class MainViewName : IChangeLanguage
{
    private readonly List<LanguageText> _languageTexts = new List<LanguageText>();
    private readonly TMP_Text _text;

    public MainViewName(List<LanguageText> languageText, TMP_Text text)
    {
        _languageTexts = languageText;
        _text = text;
    }
    
    public void ChangeLanguage(Languages language)
    {
        _text.text = (_languageTexts.First(x => x.Language == language)).Text;
    }
}