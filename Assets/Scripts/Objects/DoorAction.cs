using UnityEngine;

namespace Objects
{
    public class DoorAction : ActionHandler
    {
        public DialogSpawner dialogSpawner;
        public int which;

        public override void HandleAction()
        {
            if (which == 3 && GameMasterScript.instance.getFlag("-c-openDoor1")) {
                Debug.Log("entering bathroom");
                GameMasterScript.instance.changeCameraTo(1);
                return;
            }
            dialogSpawner.startDialog(which);
        }
    }
}
