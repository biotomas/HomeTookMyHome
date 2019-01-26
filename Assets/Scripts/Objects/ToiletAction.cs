using UnityEngine;
using System.Collections;

public class ToiletAction : ActionHandler
{
    public AudioSource audioSource;
	public System.Collections.Generic.List<AudioClip> inspectionAudios;
    
    public override void HandleAction()
    {
        StartCoroutine(waiter());
    }
    
    IEnumerator waiter()
    {
        audioSource.clip = inspectionAudios[0];
        audioSource.Play();
        
        GameMasterScript.instance.changeCameraTo(4);
        
        yield return new WaitForSeconds(5);
        
        audioSource.clip = inspectionAudios[1];
        audioSource.Play();
        
        yield return new WaitForSeconds(3);
        
        GameMasterScript.instance.changeCameraTo(1);
    }
}
