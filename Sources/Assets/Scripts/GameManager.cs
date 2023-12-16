using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager _instance;

    public int score = 0;

    private List<EnemyModel> _enemies;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameManager();
                DontDestroyOnLoad(_instance.gameObject);
                // On détruit pas l'objet GameManager quand on change de scène
            }
            return _instance;
        }
    }

    public int GetScore()
    {
        return score;
    }

    // Start is called before the first frame update
    void Start()
    {
        _enemies = new List<EnemyModel>();       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Avancer()
    {
        Debug.Log("Avancer");
    }

    internal void Reculer()
    {
        Debug.Log("Reculer");
    }

    public void AddEnemy(EnemyModel enemy)
    {
        _enemies.Add(enemy);
    }

    public void SpawnEnemy()
    {
        GameObject enemy = GameObject.CreatePrimitive(PrimitiveType.Cube);
        enemy.AddComponent<EnemyModel>();
        AddEnemy(enemy.GetComponent<EnemyModel>());
    }
}
