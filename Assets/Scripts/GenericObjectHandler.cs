using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericObjectHandler : ObjectHandler {
    public override void HandleAction()
    {
        
    }

    public override void HandleTrigger(GameObject other)
    {
        
    }

    public override void HandleDrag()
    {
        
    }

    public override void HandleInvestigate()
    {
        print("our hero tried to investigate this object but failed to do so because the game developers didn't intend this");
    }
}
