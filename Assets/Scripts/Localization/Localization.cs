using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Newtonsoft.Json;

public class Localization
{
    private Languages _language;
    private Dictionary<string, string> _localization;

    public Localization(Languages startLanguage)
    {
        _language = startLanguage;
        LoadLanguage(startLanguage);
    }

    public event Action LanguageChanged;

    public void ChangeLanguage(Languages language)
    {
        _language = language;
        LoadLanguage(language);
        LanguageChanged?.Invoke();
    }

    public string FindString(string stringName)
    {
        return _localization[stringName];
    }

    private void LoadLanguage(Languages language)
    {
        var text = Resources.Load($"Localization/{language}") as TextAsset;
        var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(text.text);
        _localization = dict;
    }

}


public enum Languages
{
    English,
    Russian,

}
