using UnityEngine;

public class DialogStartAction : ActionHandler
{
    public DialogSpawner dialogSpawner;
    public int which;
    
    public override void HandleAction()
    {
        if (which == 0) {
            if (GameMasterScript.instance.getFlag("-c-openDoor1")) {
                return;
            }
        }
        dialogSpawner.startDialog(which);
    }
}
