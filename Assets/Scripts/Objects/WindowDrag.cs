using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowDrag : CombineHandler
{
    public Sprite brokenWindow;
    public AudioSource audioSource;
    public AudioClip breakSound;

    private bool isBroken = false;
    
    public override void HandleCombination(GameObject other)
    {        
        if (other.name.StartsWith("Hammer"))
        {
            audioSource.clip = breakSound;
            audioSource.Play();
            GetComponent<SpriteRenderer>().sprite = brokenWindow;
            Destroy(other);
            isBroken = true;
        }

        if (other.name.StartsWith("Home"))
        {
            if (isBroken)
            {
                // win game here
            }
            else
            {
                // taunt player
            }
        }

        
    }
}
