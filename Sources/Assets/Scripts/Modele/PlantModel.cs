

using UnityEngine;

public class PlantModel
{

    public float ZombieDetectionLength { get; set; }
    public float AttackCooldown { get; set; }
    public float LastAttackTime { get; private set; }

    public PlantModel(
        float zombieDetectionLength,
        float attackCooldown
        ) 
    { 
        AttackCooldown = attackCooldown;
        ZombieDetectionLength = zombieDetectionLength;
    }

    public void ResetAttackTime()
    {
        LastAttackTime = Time.time;
    }
}
