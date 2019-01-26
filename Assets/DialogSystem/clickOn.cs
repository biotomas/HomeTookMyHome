using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickOn : MonoBehaviour
{
    public DialogSpawner dialogSpawner;
    public int which;
    void OnMouseDown() {
        dialogSpawner.startDialog(which);
    }
}
