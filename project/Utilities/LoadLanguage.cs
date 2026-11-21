namespace project.Localization;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class LoadLanguage
{
    private Dictionary<string, string> _texts;

    public string CurrentLanguage { get; private set; }
    public event Action LanguageChanged;

    public LoadLanguage(string language)
    {
        ChangeLanguage(language);
    }

    public void ChangeLanguage(string language)
    {
        if (language == CurrentLanguage)
        {
            return;
        }

        string path = Path.Combine(
            AppContext.BaseDirectory,
            "Localization",
            language + ".json");

        string json = File.ReadAllText(path);

        _texts = JsonSerializer.Deserialize<Dictionary<string, string>>(json)
            ?? throw new InvalidDataException("Invalid localization file.");
        CurrentLanguage = language;
        LanguageChanged?.Invoke();
    }

    public string Get(string key)
    {
        return _texts.TryGetValue(key, out string text)
            ? text
            : key;
    }
}
