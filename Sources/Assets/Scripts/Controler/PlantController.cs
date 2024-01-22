using UnityEngine;

public class PlantController : MonoBehaviour, ILifeEventListener
{
    // -------------------- From Editor
    [SerializeField]
    private Transform BulletSpawnPosition;

    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private float zombieDetectionLength = 70;

    [SerializeField]
    [Min(1)]
    private float attackCooldown = 5f;
    // --------------------------------

    private PlantModel _model;
    private PlantView _view;

    void Start()
    {
        GetComponent<LifeableController>().AddLifeEventListener(this);
        _model = new PlantModel(zombieDetectionLength, attackCooldown);
        _view = new PlantView(GetComponent<Animator>(), BulletSpawnPosition, bulletPrefab);
    }

    private void Attack()
    {
        _view.Attack();
        _model.ResetAttackTime();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = _view.ThrowRaycastToDetectEnnemies(transform.position, _model.ZombieDetectionLength);

        // If it hits an ennemy
        if (hit.collider != null && Time.time - _model.LastAttackTime > _model.AttackCooldown && hit.collider.gameObject.CompareTag("Ennemy"))
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
