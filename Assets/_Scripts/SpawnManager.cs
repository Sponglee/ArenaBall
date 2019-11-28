using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : Singleton<SpawnManager>
{
    [SerializeField] private GameObject ballPref;
    [SerializeField] private float levelDiameter = 3f;

    public Transform ballHolder;
    public int numberOfBalls = 3;

    [SerializeField]
    private int ballCount = 0;
    public int BallCount
    {
        get
        {
            return ballCount;
        }

        set
        {
            if (value <= 0)
            {
                ballCount = 0;
                CheckSpawn();
            }
            else
                ballCount = value;
        }
    }


    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            SpawnWave();
        }
    }

    public void SpawnWave()
    {
        for (int i = 0; i < numberOfBalls; i++)
        {
            SpawnBall();
        }
        
    }



    public void SpawnBall()
    {
        Instantiate(ballPref, transform.position +  new Vector3(Random.Range(-levelDiameter, levelDiameter), Random.Range(-levelDiameter, levelDiameter),
            Random.Range(-levelDiameter, levelDiameter)), Quaternion.identity, ballHolder);
        BallCount++;
    }


    public void DetatchBall(Transform target)
    {
        target.SetParent(null);
        target.GetComponent<MeshCollider>().isTrigger = true;
        BallCount--;
    }

    public void CheckSpawn()
    {
        if(ballHolder.childCount == 0)
        {
            SpawnWave();
        }
    }
}
