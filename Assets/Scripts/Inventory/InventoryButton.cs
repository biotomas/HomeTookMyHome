﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryButton : MonoBehaviour
{
    public GameObject inventory;
    
    private void OnMouseDown()
    {
        inventory.GetComponent<Inventory>().Open();
    } 
}