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
        levelRange.SetCurrentLevelAdvencement(ZombieScript.NbDeath / (float)nbTotalZombies);
    }
}
