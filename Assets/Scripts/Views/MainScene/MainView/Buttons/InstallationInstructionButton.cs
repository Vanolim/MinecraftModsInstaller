using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class InstallationInstructionButton : MainViewButtons
{
    public InstallationInstructionButton(List<LanguageText> languageTexts, Button button, TMP_Text text) 
        : base(languageTexts, button, text)
    {
    }
}