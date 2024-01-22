using System;

public class LifeableModel
{

    private int _maxLife;
    private int _currentLife;

    public int CurrentLife {  get { return _currentLife; } }
    public float CurrentRatio { get { return _currentLife / (float)_maxLife; } }

    public LifeableModel(
        int maxLife
        ) 
    {
        _maxLife = maxLife;
        _currentLife = _maxLife;
    }

    public void TakeDamages(int damages)
    {
        _currentLife = Math.Max(_currentLife - damages, 0);
    }
    public bool isAlive()
    {
        return _currentLife > 0;
    }
}
