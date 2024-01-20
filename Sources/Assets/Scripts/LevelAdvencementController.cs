using UnityEngine;

public class LevelAdvencementController : MonoBehaviour
{
    [SerializeField]
    private LevelRangeController levelRange;

    [SerializeField]
    private ScenarioManager scenarioManager;

    public Canvas GameOverCnv;
    public Canvas MainCnv;
    public Canvas WinCnv;

    private int nbTotalZombies;

    private void Start()
    {
        Time.timeScale = 1.0f;
        ZombieScript.NbDeath = 0;
        nbTotalZombies = scenarioManager.GetNumberOfZombiesInScenario();
    }
    private void Update()
    {
        float advencement = ZombieScript.NbDeath / (float)nbTotalZombies;
        levelRange.SetCurrentLevelAdvencement(advencement);
        if(advencement >= 1f)
        {
            LevelWin();
        }
    }

    private void LevelWin()
    {
        GameManager.Instance.LevelWin();
        MainCnv.enabled = false;
        WinCnv.enabled = true;
        gameObject.SetActive(false);
    }

    public void LevelLost()
    {
        MainCnv.enabled = false;
        GameOverCnv.enabled = true;
        Time.timeScale = 0;
    }
}
