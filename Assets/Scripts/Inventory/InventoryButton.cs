using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryButton : MonoBehaviour
{
    public GameObject inventory;

    public AudioSource audioSource;
    public AudioClip openSound;
    
    private void OnMouseDown()
    {
        inventory.GetComponent<Inventory>().Open();
        audioSource.clip = openSound;
        audioSource.Play();
    } 
}
