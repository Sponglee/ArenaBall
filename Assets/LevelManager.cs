using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public int levelGoal;

    public int levelIndex;
    public bool LevelComplete = false; 

    private void Start()
    {
        
    }
}
