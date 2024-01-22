using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeableController : MonoBehaviour, ILifeEventSender
{

    // ----------- From Editor :
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
    // --------------

    private LifeableModel _model;
    private LifeableView _view;
    private List<ILifeEventListener> _listeners = new List<ILifeEventListener>();

    protected virtual void Start()
    {
        _model = new LifeableModel(maxLife);
        _view = new LifeableView(lifeOkColor, lifeLowColor, lifeSlider, lifeFillImage);
    }
    
    public void TakeDamages(int damages)
    {
        _model.TakeDamages(damages);
        _view.TakeDamages(_model.CurrentRatio);
        if (!_model.isAlive())
        {
            Death();
        }
    }

    protected virtual void Death()
    {
        foreach (ILifeEventListener listener in _listeners)
        {
            listener.OnDeath();
        }
    }

    public void AddLifeEventListener(ILifeEventListener lst)
    {
        _listeners.Add(lst);
    }
}
