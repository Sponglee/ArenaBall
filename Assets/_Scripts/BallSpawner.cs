using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : Singleton<BallSpawner>
{
    [SerializeField] private GameObject ballPref;
    [SerializeField] private float levelDiameter = 3f;
    [SerializeField] private Transform ballHolder;
   




    public void SpawnBall()
    {
        Instantiate(ballPref, transform.position +  new Vector3(Random.Range(-levelDiameter, levelDiameter), Random.Range(-levelDiameter, levelDiameter),
            Random.Range(-levelDiameter, levelDiameter)), Quaternion.identity, ballHolder);
    }
}
