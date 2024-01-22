using UnityEngine;

public class RockPlantController : MonoBehaviour, ILifeEventListener
{

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<LifeableController>().AddLifeEventListener(this);
    }
    public void OnDeath()
    {
        Destroy(gameObject);
    }
}
