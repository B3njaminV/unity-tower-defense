using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public static GameManager Instance => instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);

    }
    private GameManager() { }

    public GameSaver Saver { get; private set; } = new GameSaver(new UnityDataSaver());

    [SerializeField]
    private List<SO_Scenario> _Scenarios = new List<SO_Scenario>();

    public int NbScenario { get { return _Scenarios.Count; } }

    public int CurrentLevel { get { return Saver.GetSavedLevel(); }}

    public SO_Scenario GetNextLevel()
    {
        int index = Saver.GetSavedLevel();
        return _Scenarios[index];
    }

    public void LevelWin()
    {
        int index = Saver.GetSavedLevel();
        Saver.UpdateCurrentLevelSave(++index);
    }

    public void ResetSave()
    {
        Saver.RemoveSave();
    }

}
