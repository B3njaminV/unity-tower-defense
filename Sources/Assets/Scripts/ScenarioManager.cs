using System.Collections;
using UnityEngine;

public class ScenarioManager : MonoBehaviour
{
    private SO_Scenario scenario;

    private float startingTime;
    private GameObject[] spawners;

    private int nextSpawn = 0;

    public float ElapsedTime { get { return Time.time - startingTime; } }

    public int StartingRessources {  get { return scenario.startingRessources; } }

    private void Awake()
    {
        scenario = GameManager.Instance.GetNextLevel();
        spawners = GameObject.FindGameObjectsWithTag("ZombieSpawner");
    }

    // Start is called before the first frame update
    void Start()
    {
        startingTime = Time.time;
        // shuffle spawners
        ListShuffler.Shuffle(spawners);
    }

    // Update is called once per frame
    void Update()
    {
        if(scenario == null || nextSpawn >= scenario.spawns.Count) { return; }

        SO_Scenario.ZombieSpawn currentSpawn = scenario.spawns[nextSpawn];

        if (ElapsedTime >= currentSpawn.spawnTime )
        {
            // Spawn Zombie
            if((int)currentSpawn.line < spawners.Length && currentSpawn.ZombieType < scenario.zombies.Count)
            {
                Instantiate(scenario.zombies[currentSpawn.ZombieType], spawners[(int)currentSpawn.line].GetComponent<Transform>());
            }
            nextSpawn++;
        }
    }

    public int GetNumberOfZombiesInScenario()
    {
        return scenario.spawns.Count;
    }

}
