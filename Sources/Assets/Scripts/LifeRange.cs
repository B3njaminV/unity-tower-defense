using System;
using UnityEngine;
using UnityEngine.UI;

public class LifeRange : MonoBehaviour
{
    [SerializeField]
    private Color lifeOkColor;
    [SerializeField]
    private Color lifeLowColor;

    [SerializeField]
    private Slider lifeSlider;
    [SerializeField]
    private Image lifeFillImage;

    [SerializeField]
    [Min(1)]
    private int maxLife = 100;

    private int currentLife;

    // Start is called before the first frame update
    void Start()
    {
        currentLife = maxLife;
        lifeFillImage.color = lifeOkColor;
    }
    
    public void TakeDamages(int damages)
    {
        currentLife = Math.Max(currentLife - damages, 0);
        float ratio = currentLife / (float)maxLife; ;
        lifeSlider.value = ratio;

        if (ratio < 0.5f) { 
            lifeFillImage.color = lifeLowColor; 
        }

        if (currentLife <= 0) {
            Death();
        }
    }

    private void Death()
    {
        Destroy(this.gameObject);
    }

}
