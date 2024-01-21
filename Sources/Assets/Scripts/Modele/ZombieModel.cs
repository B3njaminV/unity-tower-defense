using UnityEngine;

public class ZombieModel
{

    public const float WalkCooldownAfterDamage = 1f;
    public const float KnockbackForce = .1f;
    public bool IsDead { get; set; } = false;
    public float Speed { get; private set; }

    private const float _attackCooldown = 3f;
    public int AttackVal { get; private set; }

    private float _lastAttackTime;
    private float _lastDamageTime;

    public bool CanMove { get { return Time.time - _lastDamageTime > WalkCooldownAfterDamage; } }
    public bool CanAttack { get { return Time.time - _lastAttackTime > _attackCooldown; } }

    public ZombieModel(
        int attack, float speed
        ) 
    { 
        AttackVal = attack;
        Speed = speed;
        _lastAttackTime = Time.time - _attackCooldown;
    }

    public void ResetAttackTime()
    {
        _lastAttackTime = Time.time;
    }
    public void ResetDamageTime()
    {
        _lastDamageTime = Time.time;
    }
    public void Attack()
    {
        _lastAttackTime = Time.time;
    }
}
