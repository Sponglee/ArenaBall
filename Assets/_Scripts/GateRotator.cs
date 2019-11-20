using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateRotator : MonoCached
{

    private Transform _transform;
    [SerializeField] private float _speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        _transform = transform;
    }

    private void Update()
    {
        _transform.Rotate(Vector3.up, Time.deltaTime * _speed);
    }
}
