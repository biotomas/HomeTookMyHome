﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepAction : ActionHandler
{
    public AudioSource audioSource;
    public AudioClip roosterSound;
    
    public override void HandleAction()
    {
        StartCoroutine(waiter());
    }
    
    IEnumerator waiter()
    {
        GameMasterScript.instance.changeCameraTo(4);
        
        yield return new WaitForSeconds(3);
        
        audioSource.clip = roosterSound;
        audioSource.Play();
        
        yield return new WaitForSeconds(2);
        
        GameMasterScript.instance.changeCameraTo(5);
    }
}