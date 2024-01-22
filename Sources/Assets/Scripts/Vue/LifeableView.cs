using UnityEngine;
using UnityEngine.UI;

public class LifeableView
{
    private Color _lifeOkColor;
    private Color _lifeLowColor;
    private Slider _lifeSlider;
    private Image _lifeFillImage;

    public LifeableView(
    Color lifeOkColor, Color lifeLowColor,
    Slider lifeSlider, Image lifeFillImage
    )
    {
        _lifeOkColor = lifeOkColor;
        _lifeLowColor = lifeLowColor;
        _lifeSlider = lifeSlider;
        _lifeFillImage = lifeFillImage;

        if (_lifeFillImage != null && _lifeOkColor != null)
        {
            _lifeFillImage.color = _lifeOkColor;
        }
        if (_lifeSlider != null)
        {
            _lifeSlider.gameObject.SetActive(false);
        }
    }

    public void TakeDamages(float ratio)
    {
        if (_lifeSlider != null && _lifeFillImage != null && _lifeLowColor != null)
        {
            _lifeSlider.gameObject.SetActive(true);
            _lifeSlider.value = ratio;

            if (ratio < 0.5f)
            {
                _lifeFillImage.color = _lifeLowColor;
            }
        }
    }
}
