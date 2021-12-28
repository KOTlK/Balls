using System;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class Localization
{
    private Languages _language;
    private Dictionary<string, string> _localization;

    public Localization()
    {
        TryLoadSavedLanguage();
    }

    public event Action LanguageChanged;

    public void ChangeLanguage(Languages language)
    {
        _language = language;
        LoadLanguage(language);
        SaveLanguage();
        LanguageChanged?.Invoke();
    }

    public string FindString(string stringName)
    {
        if (_localization.ContainsKey(stringName))
        {
            return _localization[stringName];
        }else
        {
            return stringName;
        }
        
    }

    private void LoadLanguage(Languages language)
    {
        var text = Resources.Load($"Localization/{language}") as TextAsset;
        var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(text.text);
        _localization = dict;
    }

    private void SaveLanguage()
    {
        PlayerPrefs.SetInt("language", (int)_language);
    }

    private void TryLoadSavedLanguage()
    {
        if (PlayerPrefs.HasKey("language"))
        {
            ChangeLanguage((Languages)PlayerPrefs.GetInt("language"));
        } else
        {
            ChangeLanguage(Languages.English);
        }
    }
}


public enum Languages
{
    English = 0,
    Russian = 1,

}
