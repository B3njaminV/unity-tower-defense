using System;
using UnityEngine;

namespace Assets.Scripts
{
    internal class EnemySpeed : IEnemyMovement
    {
        Vector3 IEnemyMovement.deplacement()
        {
            return new Vector3(0, 0, 0.1f);
        }
    }
}
