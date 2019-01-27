using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WindowDrag : CombineHandler
{
    public Sprite brokenWindow;
    public AudioSource audioSource;
    public AudioClip breakSound;
    public AudioClip endingSound;

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
                Destroy(other);
                StartCoroutine(hammerEnding());
            }
            else
            {
                // taunt player
            }
        }

        
    }
    
    
    IEnumerator hammerEnding()
    {
        audioSource.clip = endingSound;
        audioSource.Play();
        
        yield return new WaitForSeconds(5);
        
        SceneManager.LoadScene("credits");
    }
}
