using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateManager : MonoBehaviour
{


    private void Update()
    {
        for (int i = 0; i < MonoCached.ticks.Count; i++)
        {
            MonoCached.ticks[i].Tick();
        }
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < MonoCached.fixedTicks.Count; i++)
        {
            MonoCached.fixedTicks[i].FixedTick();
        }
    }


    private void LateUpdate()
    {
        for (int i = 0; i < MonoCached.lateTicks.Count; i++)
        {
            MonoCached.lateTicks[i].LateTick();
        }
    }


}
