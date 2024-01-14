using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Scenario", menuName = "ScriptableObjects/Scenario")]
public class SO_Scenario : ScriptableObject
{
    [System.Serializable]
    public class ZombieSpawn
    {
        [SerializeField]
        [Min(0f)]
        public float spawnTime = 0;
        [SerializeField]
        public GameLineEnum line = GameLineEnum.Col1;
        [SerializeField]
        [Min(0)]
        public int ZombieType = 0;
    }
    [System.Serializable]
    public class PlantAvilable
    {
        [SerializeField]
        public GameObject prefab;
        [SerializeField]
        public uint price;
    }

    [SerializeField]
    [Min(50)]
    public int startingRessources = 50;

    [SerializeField]
    public List<ZombieSpawn> spawns;

    [SerializeField]
    public List<PlantAvilable> plants;

    [SerializeField]
    public List<GameObject> zombies;

}
