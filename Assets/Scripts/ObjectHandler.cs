using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectHandler : MonoBehaviour
{
    
    /*
     * Implement these handlers to define object behaviour
     */
    
    public abstract void HandleAction();

    public abstract void HandleTrigger(GameObject other);

    public abstract void HandleDrag();

    public abstract void HandleInvestigate();

    
    /*
     * Convenience methods
     */
    
    public bool isInInventory()
    {
        return GetComponent<DynamicObject>().IsInInventory;
    }
}
