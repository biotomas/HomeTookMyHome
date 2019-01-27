using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogSpawner : MonoBehaviour
{
    public GameObject[] dialogs;
    public GameObject handyroom;

    public void startDialog(int index) {
        if (index == -5) {
            handyroom.SetActive(true);
            GameMasterScript.instance.changeCameraTo(5);
        }
        for (int i =0; i < dialogs.Length; i++) {
            if (dialogs[i].activeSelf) {
                return;
            }
        }
        Debug.Log("starting dialog nr "+index);
        dialogs[index].SetActive(true);
    }
}
