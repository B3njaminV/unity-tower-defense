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

    private float attackCooldown = 3f;
    private float WalkCooldownAfterDamage = 1f;
    private float lastAttackTime;
    private float lastDamageTime;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lastAttackTime = Time.time - attackCooldown;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float veloc = Math.Abs(rb.velocity.x);
        animator.SetFloat("Speed", veloc);
        if (Time.time - lastDamageTime > WalkCooldownAfterDamage && veloc < speed)
        {
            rb.AddForce(Vector2.left);
        }
        //rb.velocity = Vector2.left * speed;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {

        // Take damages from bullet
        if (collision.gameObject.CompareTag("Bullet"))
        {
            animator.SetTrigger("Damages");
            rb.velocity = Vector2.zero;
            lastDamageTime = Time.time;

            // reset attack time
            lastAttackTime = Time.time;
            Destroy(collision.gameObject);
        }

        // Attack plant
        else if (collision.gameObject.CompareTag("Plant") && Time.time - lastAttackTime > attackCooldown)
        {
            Attack(collision.gameObject.GetComponent<LifeRange>());
        }

    }

    private void Attack(LifeRange range)
    {
        animator.SetTrigger("Attack");
        StartCoroutine(WillGiveDamages(range));

        // Remember that we recently attacked.
        lastAttackTime = Time.time;
    }

    private IEnumerator WillGiveDamages(LifeRange range)
    {
        yield return new WaitForSeconds(0.3f);
        range.TakeDamages(attack);
    }
}
