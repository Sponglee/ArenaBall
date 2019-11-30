using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public int levelGoal;

    public float Diameter = 3f;
    public int BallsToSpawn = 3;

    public int levelIndex;
    public bool LevelComplete = false; 

    private void Start()
    {
        
    }
}
