using UnityEngine;
using System.Collections.Generic;

public class SoundAction : ActionHandler
{
    public AudioSource audioSource;
	public List<AudioClip> inspectionAudios;
    
    public override void HandleAction()
    {
        audioSource.clip = inspectionAudios[Random.Range(0, inspectionAudios.Count)];
        audioSource.Play();
    }
}
