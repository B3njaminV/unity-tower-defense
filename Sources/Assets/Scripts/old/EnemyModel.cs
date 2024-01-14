using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel : MonoBehaviour
{
    private GameObject _object;
    public float Speed { get; private set; }
    public Vector3 Direction { get; private set; }

    private IEnemyMovement _movement;

    public EnemyModel(GameObject obj, float speed, Vector3 direction, IEnemyMovement movement)
    {
        _object = obj;
        Speed = speed;
        Direction = direction;
        _movement = movement;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _object.transform.position += _movement.deplacement();
    }
}
