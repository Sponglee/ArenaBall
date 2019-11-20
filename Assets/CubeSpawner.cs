using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : Singleton<CubeSpawner>
{

    public GameObject cubePref;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10000; i++)
        {
            Instantiate(cubePref, new Vector3(Random.Range(-100, 100), Random.Range(-100, 100), Random.Range(-100, 100)), Quaternion.identity);
        }
    }

  
}
