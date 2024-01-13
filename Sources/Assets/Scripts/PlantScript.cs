using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantScript : MonoBehaviour
{
    private Animator anim;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Attack()
    {
        anim.SetTrigger("Attack");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
