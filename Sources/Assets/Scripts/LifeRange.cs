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
    protected virtual void Start()
    {
        currentLife = maxLife;
        if(lifeFillImage != null && lifeOkColor != null)
        {
            lifeFillImage.color = lifeOkColor;
        }
    }
    
    public void TakeDamages(int damages)
    {
        currentLife = Math.Max(currentLife - damages, 0);
        float ratio = currentLife / (float)maxLife;
        if(lifeSlider != null && lifeFillImage != null && lifeLowColor != null)
        {
            lifeSlider.value = ratio;

            if (ratio < 0.5f)
            {
                lifeFillImage.color = lifeLowColor;
            }
        }

        if (!isAlive()) {
            Death();
        }
    }

    protected virtual void Death()
    {
        Destroy(this.gameObject);
    }

    protected bool isAlive()
    {
        return currentLife > 0;
    } 

}
