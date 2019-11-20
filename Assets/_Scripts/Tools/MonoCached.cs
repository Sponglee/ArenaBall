using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoCached : MonoBehaviour
{
    //Update/Fixed/Late caches for replacement
    public static List<MonoCached> ticks = new List<MonoCached>();
    public static List<MonoCached> fixedTicks = new List<MonoCached>();
    public static List<MonoCached> lateTicks = new List<MonoCached>();

    //Add to update list when object is enabled
    private void OnEnable()
    {
        ticks.Add(this);
    }

    //Remove from update list when disabled
    private void OnDisable()
    {
        ticks.Remove(this);
    }

    //Update replacements
    public void Tick()
    {
        OnTick();
    }

    public void FixedTick()
    {
        OnFixedTick();
    }

    public void LateTick()
    {
        OnLateTick();
    }


    //Updateallbacks for flexibility
    public virtual void OnTick()
    {

    }


    //Updateallbacks for flexibility
    public virtual void OnFixedTick()
    {

    }


    //Updateallbacks for flexibility
    public virtual void OnLateTick()
    {

    }

}
