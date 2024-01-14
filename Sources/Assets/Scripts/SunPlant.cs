using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunPlant : MonoBehaviour
{
    public GameObject sunPrefab;
    [SerializeField]
    private Transform[] sunSpawners;
    [SerializeField]
    private float growCooldown = 5;

    private Animator animator;
    private float lastGrowTime;
    private GameObject currentSun = null;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        lastGrowTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentSun == null && Time.time - lastGrowTime > growCooldown)
        {
            animator.SetTrigger("Grow");
            lastGrowTime = Time.time;
            StartCoroutine(spawnSun());
        }
    }

    private IEnumerator spawnSun()
    {
        yield return new WaitForSeconds(0.7f);
        currentSun = Instantiate(sunPrefab, sunSpawners[Random.Range(0, sunSpawners.Length)]);
    }
}
