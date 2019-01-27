using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepAction : ActionHandler
{
    public AudioSource audioSource;
    public AudioClip roosterSound;
    public AudioClip snoringSound;

    public AudioClip endingSound;

    public Inventory inventory;

    public Sprite dirtySprite;

    public DialogSpawner dialogSpawner;
    public int dirtyBedDialog;
    
    
    public override void HandleAction()
    {
        StartCoroutine(waiter());
    }
    
    IEnumerator waiter()
    {
        GameMasterScript.instance.changeCameraTo(4);
        
        audioSource.clip = snoringSound;
        audioSource.Play();
        
        yield return new WaitForSeconds(4);
        
        audioSource.clip = roosterSound;
        audioSource.Play();
        
        yield return new WaitForSeconds(2);
        
        GameMasterScript.instance.changeCameraTo(5);

        if (inventory.ContainsItem("Spaghett"))
        {
            print("slept with spaghett");
            GetComponent<SpriteRenderer>().sprite = dirtySprite;
            
            audioSource.clip = endingSound;
            audioSource.Play();
            
            yield return new WaitForSeconds(8);
            
            // change to ending
            // TODO
        }
    }
}
