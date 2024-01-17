using UnityEngine;

public interface IDataSaver
{
    public void SaveInt(string key, int value);
    public void SaveFloat(string key, int value);
    public void SaveString(string key, string value);


    public int? LoadInt(string key);
    public float? LoadFloat(string key);
    public string LoadString(string key);
}
