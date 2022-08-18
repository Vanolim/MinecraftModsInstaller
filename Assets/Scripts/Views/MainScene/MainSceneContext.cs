using System;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneContext : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private MainView _mainView;
    [SerializeField] private PrivacyPolicyView _privacyPolicyView;
    [SerializeField] private InstallationInstructionView _installationInstructionView;
    [SerializeField] private OpenFile _openFile;

    [SerializeField] private string _ruTextInstallationInstructionButton;
    [SerializeField] private string _engTextInstallationInstructionButton;
    
    [SerializeField] private string _ruPrivacyPolicyButton;
    [SerializeField] private string _engPrivacyPolicyButton;
    
    [SerializeField] private string _ruButtonLanguage;
    [SerializeField] private string _engButtonLanguage;

    [SerializeField] private string _ruName;
    [SerializeField] private string _engName;

    [SerializeField] private string _ruPrivacyPoliceHeader;
    [SerializeField] private string _engPrivacyPoliceHeader;
    
    [SerializeField] private string _ruPrivacyPoliceText;
    [SerializeField] private string _engPrivacyPoliceText;
    
    [SerializeField] private string _ruInstallationInstructionHeaderText;
    [SerializeField] private string _engInstallationInstructionHeaderText;
    
    [SerializeField] private string _ruInstallationInstructionText;
    [SerializeField] private string _engInstallationInstructionText;
    

    private Languages _currentLanguage = Languages.RU;
    private readonly List<IChangeLanguage> _changedLanguages = new List<IChangeLanguage>();

    public OpenFile OpenFile => _openFile;
    
    public event Action OnClickMod;

    public void Init()
    {
        _canvas.worldCamera = Camera.main;
        InitMainView();
        InitPrivacyPoliceView();
        InitInstallationInstructionView();
    }

    private void InitMainView()
    {
        List<LanguageText> languageTextsInstallationInstructionButton = new List<LanguageText>();
        languageTextsInstallationInstructionButton.Add(new LanguageText(_ruTextInstallationInstructionButton, Languages.RU));
        languageTextsInstallationInstructionButton.Add(new LanguageText(_engTextInstallationInstructionButton, Languages.ENG));

        List<LanguageText> languageTextsPrivacyPoliceButton = new List<LanguageText>();
        languageTextsPrivacyPoliceButton.Add(new LanguageText(_ruPrivacyPolicyButton, Languages.RU));
        languageTextsPrivacyPoliceButton.Add(new LanguageText(_engPrivacyPolicyButton, Languages.ENG));

        List<LanguageText> languageTextsLanguageButton = new List<LanguageText>();
        languageTextsLanguageButton.Add(new LanguageText(_ruButtonLanguage, Languages.RU));
        languageTextsLanguageButton.Add(new LanguageText(_engButtonLanguage, Languages.ENG));
        
        List<LanguageText> nameTexts = new List<LanguageText>();
        nameTexts.Add(new LanguageText(_ruName, Languages.RU));
        nameTexts.Add(new LanguageText(_engName, Languages.ENG));

        _mainView.Init(languageTextsInstallationInstructionButton, languageTextsPrivacyPoliceButton, languageTextsLanguageButton, nameTexts);
        _mainView.OnLanguageChangeButton += ChangeLanguage;
        _mainView.OnPrivacyPoliceButton += OpenPrivacyPolicyView;
        _mainView.OnInstallationInstructionButton += OpenInstallationInstructionView;
        _mainView.OnNameModeButton += SendEventClickMod;
        _changedLanguages.Add(_mainView);
    }

    private void InitPrivacyPoliceView()
    {
        List<LanguageText> privacyPoliceHeader = new List<LanguageText>();
        privacyPoliceHeader.Add(new LanguageText(_ruPrivacyPoliceHeader, Languages.RU));
        privacyPoliceHeader.Add(new LanguageText(_engPrivacyPoliceHeader, Languages.ENG));
        
        List<LanguageText> privacyPoliceText = new List<LanguageText>();
        privacyPoliceText.Add(new LanguageText(_ruPrivacyPoliceText, Languages.RU));
        privacyPoliceText.Add(new LanguageText(_engPrivacyPoliceText, Languages.ENG));
        
        _privacyPolicyView.Init(privacyPoliceHeader, privacyPoliceText);
        _privacyPolicyView.OnBack += OpenMainView;
        _changedLanguages.Add(_privacyPolicyView);
    }

    private void InitInstallationInstructionView()
    {
        List<LanguageText> instructionHeaderText = new List<LanguageText>();
        instructionHeaderText.Add(new LanguageText(_ruInstallationInstructionHeaderText, Languages.RU));
        instructionHeaderText.Add(new LanguageText(_engInstallationInstructionHeaderText, Languages.ENG));
        
        List<LanguageText> instructionPolicyText = new List<LanguageText>();
        instructionPolicyText.Add(new LanguageText(_ruInstallationInstructionText, Languages.RU));
        instructionPolicyText.Add(new LanguageText(_engInstallationInstructionText, Languages.ENG));
        
        _installationInstructionView.Init(instructionHeaderText, instructionPolicyText);
        _installationInstructionView.OnBack += OpenMainView;
        _changedLanguages.Add(_installationInstructionView);
    }

    private void OpenMainView()
    {
        _mainView.gameObject.SetActive(true);
        _privacyPolicyView.gameObject.SetActive(false);
        _installationInstructionView.gameObject.SetActive(false);
    }

    private void OpenPrivacyPolicyView()
    {
        _mainView.gameObject.SetActive(false);
        _privacyPolicyView.gameObject.SetActive(true);
        _installationInstructionView.gameObject.SetActive(false);
    }

    private void OpenInstallationInstructionView()
    {
        _mainView.gameObject.SetActive(false);
        _privacyPolicyView.gameObject.SetActive(false);
        _installationInstructionView.gameObject.SetActive(true);
    }

    private void ChangeLanguage()
    {
        if (_currentLanguage == Languages.RU)
            _currentLanguage = Languages.ENG;
        else
            _currentLanguage = Languages.RU;

        foreach (var changedLanguage in _changedLanguages)
        {
            changedLanguage.ChangeLanguage(_currentLanguage);
        }
    }

    private void SendEventClickMod()
    {
        OnClickMod?.Invoke();
    }
}