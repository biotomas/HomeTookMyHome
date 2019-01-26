using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickOn : MonoBehaviour
{
    public DialogSpawner dialogSpawner;
    public int which;
    void OnMouseDown() {
        if (which == 3 && GameMasterScript.instance.getFlag("-c-openDoor1")) {
            Debug.Log("entering bathroom");
            GameMasterScript.instance.changeCameraTo(1);
            return;
        }
        dialogSpawner.startDialog(which);
    }
}
