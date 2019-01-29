using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHammerAction : ActionHandler
{
    public GameObject hammer;

    public AudioSource audioSource;
    public AudioClip spawnHammerSound;
    
    public override void HandleAction()
    {
        if (!GameMasterScript.instance.getFlag("gotHammer"))
        {
            hammer.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GameMasterScript.instance.setFlag("gotHammer");
            audioSource.clip = spawnHammerSound;
            audioSource.Play();
        }
    }
}
