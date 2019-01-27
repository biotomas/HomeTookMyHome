using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeSpaghett : TakeToInventoryHandler
{
    public DialogSpawner dialogSpawner;
    public int which;
    
    public override void HandleTake()
    {
        dialogSpawner.startDialog(which);
    }
}
