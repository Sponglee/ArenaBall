using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateRotator : MonoCached
{
    [SerializeField] private bool IsRotating = true;

    private Transform _transform;
    [SerializeField] private float _speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        FunctionHandler.OnGameOver += StopWalls;
        _transform = transform;
    }

    private void Update()
    {
        if(IsRotating)
            _transform.Rotate(Vector3.up, Time.deltaTime * _speed);
    }

    public void StopWalls()
    {
        IsRotating = false;
    }


}


