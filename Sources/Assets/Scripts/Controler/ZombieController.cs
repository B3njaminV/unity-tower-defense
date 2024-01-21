using System;
using System.Collections;
using UnityEngine;

public class ZombieController : MonoBehaviour, ILifeEventListener
{
    // ----------------- From Editor
    [SerializeField]
    [Range(0f, 10f)]
    private float speed = 5;

    [SerializeField]
    [Min(1)]
    private int attack = 5;
    // -----------------------------

    public static int NbDeath { get; set; } = 0;

    private LifeableController lifeController;

    private ZombieModel _model;
    private ZombieView _view;

    // Start is called before the first frame update
    void Start()
    {
        lifeController = GetComponent<LifeableController>();
        lifeController.AddLifeEventListener(this);
        _model = new ZombieModel(attack, speed);
        _view = new ZombieView(GetComponent<Rigidbody2D>(), GetComponent<Animator>());
    }

    // Update is called once per frame
    void Update()
    {
        if (_model.IsDead) { return; }
        _view.UpdateMotion(ZombieModel.KnockbackForce, _model.Speed, _model.CanMove);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {

        if (_model.IsDead) { return; }

        // Take damages from bullet
        if (collision.gameObject.CompareTag("Bullet"))
        {
            var bullet = collision.gameObject.GetComponent<bulletScript>();

            _view.Damages();
            lifeController.TakeDamages(bullet.getDamages());

            // reset attack time
            _model.ResetAttackTime();
            _model.ResetDamageTime();
            bullet.Remove();
        }

        // Attack plant
        else if (collision.gameObject.CompareTag("Plant") && _model.CanAttack)
        {
            Attack(collision.gameObject.GetComponent<LifeableController>());
        }

    }

    private void Attack(LifeableController range)
    {
        _view.Attack();
        _model.Attack();
        StartCoroutine(WillGiveDamages(range));
    }

    private IEnumerator WillGiveDamages(LifeableController range)
    {
        yield return new WaitForSeconds(0.3f);
        range.TakeDamages(attack);
    }

    private IEnumerator WillDie()
    {
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }

    public void OnDeath()
    {
        NbDeath++;
        StartCoroutine(WillDie());
        _view.Death();
        _model.IsDead = true;
        GetComponent<CapsuleCollider2D>().enabled = false;
    }
}
