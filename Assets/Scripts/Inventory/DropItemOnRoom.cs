using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemOnRoom : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (GameMasterScript.instance.CurrentHeldItem != null)
            {
                GameMasterScript.instance.CurrentHeldItem.Release();
                GameMasterScript.instance.CurrentHeldItem = null;
            }
        }
    }
}
