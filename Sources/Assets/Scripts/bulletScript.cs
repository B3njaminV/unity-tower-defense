using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    [SerializeField]
    [Min(1)]
    private float speed = 1f;

    [SerializeField]
    [Min(1)]
    private int damages = 10;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.right * speed);
    }

    public int getDamages() { return damages; }
    public void setDamages(int damages)
    {
        this.damages = damages;
    }
}
