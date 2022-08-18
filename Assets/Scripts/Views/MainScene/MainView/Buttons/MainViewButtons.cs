using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine.UI;

public abstract class MainViewButtons : IChangeLanguage
{
    private readonly List<LanguageText> _languageTexts = new List<LanguageText>();
    private readonly Button _button;
    private readonly TMP_Text _text;

    public event Action OnButton;

    public MainViewButtons(List<LanguageText> languageTexts, Button button, TMP_Text text)
    {
        _languageTexts = languageTexts;
        _button = button;
        _text = text;
    }

    public void Init()
    {
        _button.onClick.AddListener(delegate { OnButton?.Invoke(); });
    }
    
    public void ChangeLanguage(Languages language)
    {
        _text.text = (_languageTexts.First(x => x.Language == language)).Text;
    }

    //protected abstract void ChangeView(LanguageText languageText);

    public void Dispose()
    {
        _button.onClick.RemoveListener(delegate { OnButton?.Invoke(); });
    }
}