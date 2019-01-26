using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogSpawner : MonoBehaviour
{
    public GameObject[] dialogs;

    public void startDialog(int index) {
        Instantiate(dialogs[index]);
    }
}
