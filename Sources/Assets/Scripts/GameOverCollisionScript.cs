using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverCollisionScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ennemy")
        {
            GameObject.Find("GameOver").GetComponent<Canvas>().enabled = true;
            Time.timeScale = 0;
        }
    }
}
