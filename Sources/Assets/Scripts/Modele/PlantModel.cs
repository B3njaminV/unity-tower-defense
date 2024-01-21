

public class PlantModel
{

    public float ZombieDetectionLength { get; set; }
    public float AttackCooldown { get; set; }
    public float LastAttackTime { get; set; }

    public PlantModel(
        float zombieDetectionLength,
        float attackCooldown
        ) 
    { 
        AttackCooldown = attackCooldown;
        ZombieDetectionLength = zombieDetectionLength;
    }
}
