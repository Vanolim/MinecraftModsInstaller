using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PrivacyPolicyView : MonoBehaviour, IChangeLanguage, IMovedBack
{
    [SerializeField] private TMP_Text _policyHeader;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Button Back;

    private List<LanguageText> _policyHeaderText;
    private List<LanguageText> _textPolicyText;

    public event Action OnBack;

    public void Init(List<LanguageText> policyHeaderText, List<LanguageText> textPolicyText)
    {
        _policyHeaderText = policyHeaderText;
        _textPolicyText = textPolicyText;
        
        Back.onClick.AddListener(delegate { OnBack?.Invoke(); });
    }

    public void ChangeLanguage(Languages language)
    {
        _policyHeader.text = (_policyHeaderText.First(x => x.Language == language)).Text;
        _text.text = (_textPolicyText.First(x => x.Language == language)).Text;
    }
}