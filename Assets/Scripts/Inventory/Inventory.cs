using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class Inventory : MonoBehaviour
{
    private bool _isOpen = false;
    public bool IsOpen
    {
        get { return _isOpen; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Open()
    {
        //gameObject.SetActive(true);
        GetComponent<Canvas>().enabled = true;
        _isOpen = true;
    }

    public void Close()
    {
        GetComponent<Canvas>().enabled = false;
        _isOpen = false;
    }
    

    public void PutItem(GameObject item)
    {
        print("you put " + item.name + " into the inventory");
    }

    public void DeleteItem(GameObject item)
    {
        // todo implement
        print("yadda yadda");
    }

    public void DeleteItem(String itemName)
    {
        // todo implement
    }
}
