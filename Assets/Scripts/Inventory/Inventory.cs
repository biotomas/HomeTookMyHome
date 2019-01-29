using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI; 
using UnityEngine.Experimental.UIElements.StyleSheets;

public class Inventory : MonoBehaviour
{
    public GameObject inventoryItemPrefab;
    public GameObject uiContent;


    public AudioSource audioSource;
    public AudioClip takeSound;
    
    
    private bool _isOpen = false;
    public bool IsOpen
    {
        get { return _isOpen; }
    }


    private List<GameObject> items = new List<GameObject>();
    

    
    // Start is called before the first frame update
    void Start()
    {
        Close();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Open()
    {
        //gameObject.SetActive(true);
        GetComponent<Canvas>().enabled = true;
        uiContent.transform.position = new Vector3(0, 0, 0);
        
        foreach (GameObject invItem in items)
        {
            invItem.transform.SetParent(null);
        }

        
        _isOpen = true;

        int rowLength = 10;
        int i = 0;
        int gap = Screen.width / (rowLength+1);
        int startHeight = -gap;
        
        foreach (GameObject invItem in items)
        {
            invItem.transform.position = new Vector3(gap + (i % rowLength)*gap, startHeight - (i/rowLength)*gap, 0);
            invItem.transform.localScale = new Vector3(0.5f, 0.5f, 1);
            invItem.transform.SetParent(uiContent.transform);
            i++;
        }
    }

    public void Close()
    {
        GetComponent<Canvas>().enabled = false;
        _isOpen = false;
    }



    /*
    public void PutItem(String itemName)
    {
        // todo implement
        // find prefab (?) by name and then call putitem(gameobject)
    }
    */
    
    public void PutItem(GameObject item)
    {
        print("you put " + item.name + " into the inventory");
        
        // create inventory item from gameobject and add it to list
        GameObject newItem = Instantiate(inventoryItemPrefab, Vector3.zero, Quaternion.identity);
        newItem.name = item.name;
        Image img = newItem.GetComponent<Image>();
        img.sprite = item.GetComponent<SpriteRenderer>().sprite;
        newItem.GetComponent<InventoryItem>().objectPrefab = item;
        newItem.transform.position = Vector3.zero;
        newItem.transform.SetParent(uiContent.transform);

        audioSource.clip = takeSound;
        audioSource.Play();
        
        items.Add(newItem);
    }

    public void DeleteItem(GameObject item)
    {
        items.Remove(item);
        Destroy(item);       
    }

    /*
    public void DeleteItem(String itemName)
    {
        foreach (GameObject go in items)
        {
            if (go.name.StartsWith(itemName))
            {
                DeleteItem(go);
                break;
            }
        }
    }
    */

    public Boolean ContainsItem(String itemName)
    {
        foreach (GameObject go in items)
        {
            if (go.name.StartsWith(itemName))
            {
                return true;
            }
        }

        return false;
    }
}
