using UnityEngine;

public class GameOverCollisionScript : MonoBehaviour
{
    public LevelAdvencementController lac;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ennemy")
        {
            lac.LevelLost();
        }

        AudioScript.Instance.SwitchToGameOverSong();
    }
}
