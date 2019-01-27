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

    public GameObject kitchenImage;
    
    private bool isBroken = false;
    
    public override void HandleCombination(GameObject other)
    {
        Vector2 size = kitchenImage.GetComponent<SpriteRenderer>().size;
        
        if (other.name.StartsWith("Hammer"))
        {
            audioSource.clip = breakSound;
            audioSource.Play();
            //kitchenImage.transform.localScale = new Vector3(0.3505571f, 0.3505571f, 0.3505571f);
            kitchenImage.GetComponent<SpriteRenderer>().size = size;
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
