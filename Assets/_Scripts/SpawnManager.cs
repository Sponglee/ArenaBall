using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : Singleton<SpawnManager>
{
    [SerializeField] private GameObject ballPref;
    [SerializeField] private float levelDiameter = 3f;

    public Transform ballHolder;
   




    public void SpawnBall()
    {
        Instantiate(ballPref, transform.position +  new Vector3(Random.Range(-levelDiameter, levelDiameter), Random.Range(-levelDiameter, levelDiameter),
            Random.Range(-levelDiameter, levelDiameter)), Quaternion.identity, ballHolder);
    }
}
