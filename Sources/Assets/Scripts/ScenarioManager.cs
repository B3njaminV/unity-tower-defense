using System.Collections;
using UnityEngine;

public class ScenarioManager : MonoBehaviour
{

    [SerializeField]
    private SO_Scenario scenario;

    private float startingTime;
    private GameObject[] spawners;

    private int nextSpawn = 0;

    public float ElapsedTime { get { return Time.time - startingTime; } }

    // Start is called before the first frame update
    void Start()
    {
        startingTime = Time.time;
        spawners = GameObject.FindGameObjectsWithTag("ZombieSpawner");
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
