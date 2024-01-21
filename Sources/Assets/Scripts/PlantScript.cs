using UnityEngine;

public class PlantScript : MonoBehaviour, ILifeEventListener
{
    private Animator anim;

    [SerializeField]
    private Transform BulletSpawnPosition;

    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private float zombieDetectionLength = 70;

    [SerializeField]
    [Min(1)]
    private float attackCooldown = 5f;
    private float lastAttackTime;

    void Start()
    {
        anim = GetComponent<Animator>();
        GetComponent<LifeableController>().AddLifeEventListener(this);
    }

    private void Attack()
    {
        anim.SetTrigger("Attack");
        Instantiate(bulletPrefab, BulletSpawnPosition);
        lastAttackTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        // Cast a ray straight forward detecting Ennemy layer
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, zombieDetectionLength, LayerMask.GetMask("Ennemy"));

        // If it hits an ennemy
        if (hit.collider != null && Time.time - lastAttackTime > attackCooldown && hit.collider.gameObject.CompareTag("Ennemy"))
        {
            Attack();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector2.right * zombieDetectionLength);
    }

    public void OnDeath()
    {
        Destroy(gameObject);
    }
}
