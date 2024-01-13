using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScript : MonoBehaviour
{

    private Rigidbody2D rb;

    [SerializeField]
    [Range(0f, 10f)]
    private float speed = 5;

    [SerializeField]
    [Min(1)]
    private int attack = 5;

    private float attackCooldown = 2f;
    private float lastAttackTime;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lastAttackTime = Time.time - attackCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.left * speed;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {


        // Abort if we already attacked recently.
        if (Time.time - lastAttackTime < attackCooldown) return;

        // CompareTag is cheaper than .tag ==
        if (collision.gameObject.CompareTag("Plant"))
        {
            collision.gameObject.GetComponent<LifeRange>().TakeDamages(attack);

            // Remember that we recently attacked.
            lastAttackTime = Time.time;
        }
    }
}
