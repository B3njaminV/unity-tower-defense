using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager _instance;

    public int score = 0;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
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
}
