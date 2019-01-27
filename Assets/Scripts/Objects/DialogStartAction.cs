using UnityEngine;

public class DialogStartAction : ActionHandler
{
    public DialogSpawner dialogSpawner;
    public int which;
    
    public override void HandleAction()
    {
        dialogSpawner.startDialog(which);
    }
}
