using UnityEngine;

public class PlantScript : MonoBehaviour
{
    private Animator anim;

    [SerializeField]
    private Transform BulletSpawnPosition;

    [SerializeField]
    private GameObject bulletPrefab;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        InvokeRepeating("Attack", 5, 5);
    }

    private void Attack()
    {
        anim.SetTrigger("Attack");
        Instantiate(bulletPrefab, BulletSpawnPosition);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
