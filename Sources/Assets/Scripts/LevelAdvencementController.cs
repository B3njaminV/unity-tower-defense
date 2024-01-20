using UnityEngine;

public class LevelAdvencementController : MonoBehaviour
{
    [SerializeField]
    private LevelRangeController levelRange;

    [SerializeField]
    private ScenarioManager scenarioManager;

    private int nbTotalZombies;

    private void Start()
    {
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
        gameObject.SetActive(false);
    }
}
