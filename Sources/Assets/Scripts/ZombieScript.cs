using System;
using System.Collections;
using UnityEngine;

public class ZombieScript : LifeRange
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

    private float knockbackForce = .1f;

    private Animator animator;

    private bool isDead = false;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        lastAttackTime = Time.time - attackCooldown;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead) { return; }

        float veloc = - rb.velocity.x;
        if(veloc < -knockbackForce) 
        { 
            rb.velocity = new Vector2(-knockbackForce, 0f);
            veloc = -knockbackForce;
        }

        animator.SetFloat("Speed", veloc);
        if (Time.time - lastDamageTime > WalkCooldownAfterDamage && veloc < speed)
        {
            rb.AddForce(Vector2.left);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {

        if (isDead) { return; }

        // Take damages from bullet
        if (collision.gameObject.CompareTag("Bullet"))
        {
            var bullet = collision.gameObject.GetComponent<bulletScript>();

            animator.SetTrigger("Damages");
            rb.velocity = Vector2.zero;
            lastDamageTime = Time.time;
            this.TakeDamages(bullet.getDamages());

            // reset attack time
            lastAttackTime = Time.time;
            bullet.Remove();
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

    protected override void Death()
    {
        StartCoroutine(WillDie());
        animator.SetTrigger("Death");
        isDead = true;
        GetComponent<CapsuleCollider2D>().enabled = false;
    }

    private IEnumerator WillDie()
    {
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }
}
