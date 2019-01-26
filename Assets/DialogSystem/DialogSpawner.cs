using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogSpawner : MonoBehaviour
{
    public GameObject[] dialogs;

    public void startDialog(int index) {
        for (int i =0; i < dialogs.Length; i++) {
            if (dialogs[i].activeSelf) {
                return;
            }
        }
        dialogs[index].SetActive(true);
    }
}
