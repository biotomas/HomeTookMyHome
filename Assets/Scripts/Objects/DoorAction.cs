using UnityEngine;

namespace Objects
{
    public class DoorAction : ActionHandler
    {
        public AudioSource audioSource;
        public GameObject handyCanvas;
        public AudioClip doorSound;
        
        public DialogSpawner dialogSpawner;
        public int which;
        public int targetRoom = -1;

        public override void HandleAction()
        {
            // don't try to understand it
            if (dialogSpawner != null)
            {
                if (which == 3)
                {
                    if (!GameMasterScript.instance.getFlag("-c-openDoor1"))
                    {
                        dialogSpawner.startDialog(which);
                        return;
                    }
                }
                else
                {
                    dialogSpawner.startDialog(which);
                }
            }

            if (targetRoom == 6) {
                handyCanvas.SetActive(true);
            }
            
            if (targetRoom != -1)
            {
                audioSource.clip = doorSound;
                audioSource.Play();
                GameMasterScript.instance.changeCameraTo(targetRoom);
            }
            
        }
    }
}
