using UnityEngine;

public class UnityDataSaver : IDataSaver
{
    public void SaveFloat(string key, int value)
    {
        PlayerPrefs.SetFloat(key, value);
    }

    public void SaveInt(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
    }

    public void SaveString(string key, string value)
    {
        PlayerPrefs.SetString(key, value);
    }


    public float? LoadFloat(string key)
    {
        return PlayerPrefs.HasKey(key) ? PlayerPrefs.GetFloat(key) : null;
    }

    public int? LoadInt(string key)
    {
        return PlayerPrefs.HasKey(key) ? PlayerPrefs.GetInt(key) : null;
    }

    public string LoadString(string key)
    {
        return PlayerPrefs.HasKey(key) ? PlayerPrefs.GetString(key) : null;
    }


}
