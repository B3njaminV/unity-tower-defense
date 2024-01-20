using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverCollisionScript : MonoBehaviour
{
    public LevelAdvencementController lac;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ennemy")
        {
            lac.LevelLost();
        }
    }
}
