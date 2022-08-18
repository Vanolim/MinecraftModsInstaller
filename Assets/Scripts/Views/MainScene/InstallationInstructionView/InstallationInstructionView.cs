using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InstallationInstructionView : MonoBehaviour, IChangeLanguage, IMovedBack
{
    [SerializeField] private TMP_Text _instructionHeader;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Button Back;
    
    private List<LanguageText> _instructionHeaderText;
    private List<LanguageText> _instructionPolicyText;

    public event Action OnBack;
    
    public void Init(List<LanguageText> instructionHeaderText, List<LanguageText> instructionPolicyText)
    {
        _instructionHeaderText = instructionHeaderText;
        _instructionPolicyText = instructionPolicyText;
        
        Back.onClick.AddListener(delegate { OnBack?.Invoke(); });
    }

    public void ChangeLanguage(Languages language)
    {
        _instructionHeader.text = (_instructionHeaderText.First(x => x.Language == language)).Text;
        _text.text = (_instructionPolicyText.First(x => x.Language == language)).Text;
    }
}