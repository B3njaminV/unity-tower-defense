using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILifeEventListener
{
    public void OnDeath();
    public void OnDamagesTaken(int currentLife, int maxLife) { }
}
