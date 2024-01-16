using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    [SerializeField] private Slider slider;
    
    void Start()
    {
        slider.value = 0;
    }

    void Update()
    {
        slider.value += 0.2f * Time.deltaTime;
    }

}
