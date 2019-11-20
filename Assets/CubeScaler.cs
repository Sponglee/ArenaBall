using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScaler : MonoCached
{

    Transform _transform;
    float _randomizer;
    bool IsVisible = false;

    private void Start()
    {
        _randomizer= Random.Range(0, 10f);
        _transform = transform;
    }


    private void OnBecameVisible()
    {
        IsVisible = true;
    }

    private void OnBecameInvisible()
    {
        IsVisible = false;
    }


    public override void OnTick()
    {
        if(IsVisible)
        {
            var val = Mathf.Sin(Time.time + _randomizer);
            _transform.localScale = Vector3.one * val;
        }
        
    }
}
