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
        UpdateSlider(0.1f * Time.deltaTime);
    }

    private void UpdateSlider(float nombre)
    {
        slider.value = nombre;
    }


}
