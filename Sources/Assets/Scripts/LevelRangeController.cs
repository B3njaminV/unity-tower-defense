using UnityEngine;
using UnityEngine.UI;

public class LevelRangeController : MonoBehaviour
{
    
    private Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void SetCurrentLevelAdvencement(float levelAdvencement)
    {
        slider.value = levelAdvencement;
    }
}
