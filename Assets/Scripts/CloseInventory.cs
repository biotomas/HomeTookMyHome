using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseInventory : MonoBehaviour
{
    void OnMouseDown()
    {
        GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>().Close();
    }
}
