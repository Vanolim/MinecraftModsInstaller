using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainView : MonoBehaviour, IChangeLanguage
{
    [SerializeField] private Button _installationInstructionButton;
    [SerializeField] private TMP_Text _installationInstructionText;
    [SerializeField] private Button _privacyPoliceButton;
    [SerializeField] private TMP_Text _privacyPoliceText;
    [SerializeField] private Button _languageChangeButton;
    [SerializeField] private TMP_Text _languageChangeText;
    [SerializeField] private Button _nameModeButton;
    [SerializeField] private TMP_Text _nameModeText;

    private readonly List<MainViewButtons> _mainViewButtons = new List<MainViewButtons>();

    public event Action OnLanguageChangeButton;
    public event Action OnPrivacyPoliceButton;
    public event Action OnInstallationInstructionButton;
    public event Action OnNameModeButton;

    public void Init(List<LanguageText> textInstallationInstructionButton, 
        List<LanguageText> textPrivacyPoliceButton,
        List<LanguageText> textLanguageButton,
        List<LanguageText> textName)
    {
        InstallationInstructionButton installationInstructionButton = new InstallationInstructionButton(
            textInstallationInstructionButton, _installationInstructionButton, _installationInstructionText);
        installationInstructionButton.OnButton += OpenInstallationInstruction;

        PrivacyPolicyButton privacyPolicyButton = new PrivacyPolicyButton(
            textPrivacyPoliceButton, _privacyPoliceButton, _privacyPoliceText);

        LanguageButton languageButton = new LanguageButton(
            textLanguageButton, _languageChangeButton, _languageChangeText);

        NameModeButton nameModeButton = new NameModeButton(
            textName, _nameModeButton, _nameModeText);


        _mainViewButtons.Add(installationInstructionButton);
        _mainViewButtons.Add(privacyPolicyButton);
        _mainViewButtons.Add(languageButton);
        _mainViewButtons.Add(nameModeButton);
        _languageChangeButton.onClick.AddListener(delegate { OnLanguageChangeButton?.Invoke(); });
        _privacyPoliceButton.onClick.AddListener(delegate { OnPrivacyPoliceButton?.Invoke(); });
        _installationInstructionButton.onClick.AddListener(delegate { OnInstallationInstructionButton?.Invoke(); });
        _nameModeButton.onClick.AddListener(delegate { OnNameModeButton?.Invoke(); });
    }

    private void OpenInstallationInstruction()
    {
        
    }

    public void ChangeLanguage(Languages language)
    {
        foreach (var mainViewButton in _mainViewButtons)
        {
            mainViewButton.ChangeLanguage(language);
        }
    }
}