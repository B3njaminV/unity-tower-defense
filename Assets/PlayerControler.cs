using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // Saisie clavier pour avancer, reculer, droite gauche avec les touches ZQSD
        if(Input.GetKey(KeyCode.Z))
        {
            GameManager.Instance.Avancer();
        }
        if (Input.GetKey(KeyCode.S))
        {
            GameManager.Instance.Reculer();
        }

    }
}
