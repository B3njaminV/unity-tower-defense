using UnityEngine;

public class PlantView
{
    private Animator _anim;
    private Transform _bulletSpawnPosition;
    private GameObject _bulletPrefab;

    public PlantView(
        Animator anim, Transform bulletSpawnPosition, GameObject bulletPrefab
        )
    {
        _anim = anim;
        _bulletSpawnPosition = bulletSpawnPosition;
        _bulletPrefab = bulletPrefab;
    }

    public void Attack()
    {
        _anim.SetTrigger("Attack");
        MonoBehaviour.Instantiate(_bulletPrefab, _bulletSpawnPosition);
    }


    // Cast a ray straight forward detecting Ennemy layer
    public RaycastHit2D ThrowRaycastToDetectEnnemies(Vector3 pos, float length)
    {
        return Physics2D.Raycast(pos, Vector2.right, length, LayerMask.GetMask("Ennemy"));
    }

}
