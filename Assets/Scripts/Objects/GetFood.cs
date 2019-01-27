using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetFood : CombineHandler
{
    public AudioSource audioSource;
    public AudioClip squealSound;
    
    public override void HandleCombination(GameObject other)
    {
        if (other.name.StartsWith("Spaghett"))
        {
            audioSource.clip = squealSound;
            audioSource.Play();
            other.transform.position = new Vector3(-10000, -10000, 0);
        }
    }
}
