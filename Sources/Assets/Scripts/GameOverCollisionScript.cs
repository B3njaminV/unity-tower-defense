using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverCollisionScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D");
        if (collision.gameObject.tag == "Ennemy")
        {
            Debug.Log("Game Over");
        }
    }
}
