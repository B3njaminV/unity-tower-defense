using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DifficulteControler : MonoBehaviour
{
    [SerializeField] public Slider slider;
    private Option _niveau;

    void Start()
    {
        _niveau = new Option();
        _niveau.niveauStrategy = new OptionDifficile();
        _niveau.points = 0;
    }

    void Update()
    {
        _niveau.progression += _niveau.niveauStrategy.AccelerationPoints * Time.deltaTime;
        slider.value = _niveau.progression;

        Debug.Log(_niveau.progression);
    }
}
