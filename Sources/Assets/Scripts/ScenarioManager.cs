using System.Collections.Generic;
using UnityEngine;

public class ScenarioManager : MonoBehaviour
{
    [System.Serializable]
    public class Zombie_Prefab_Association
    {
        public ZombiesEnum zombieType;
        public GameObject zombiePrefab;
    }
    public List<Zombie_Prefab_Association> LzombiesPrefabs;

    private SO_Scenario scenario;

    private float startingTime;
    private GameObject[] spawners;

    private Dictionary<ZombiesEnum, GameObject> zombiesPrefabs = new Dictionary<ZombiesEnum, GameObject>();

    private int nextSpawn = 0;

    public float ElapsedTime { get { return Time.time - startingTime; } }

    public int StartingRessources {  get { return scenario.startingRessources; } }

    private void Awake()
    {
        scenario = GameManager.Instance.GetNextLevel();
        spawners = GameObject.FindGameObjectsWithTag("ZombieSpawner");
        foreach (var zp in LzombiesPrefabs) {
            zombiesPrefabs.Add(zp.zombieType, zp.zombiePrefab);
        }
        LzombiesPrefabs = null;
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
            if((int)currentSpawn.line < spawners.Length)
            {
                Instantiate(zombiesPrefabs[currentSpawn.ZombieType], spawners[(int)currentSpawn.line].GetComponent<Transform>());
            }
            nextSpawn++;
        }
    }

    public int GetNumberOfZombiesInScenario()
    {
        return scenario.spawns.Count;
    }

    public List<SO_Scenario.PlantAvilable> GetUsablePlants()
    {
        return scenario.plants;
    }

}
