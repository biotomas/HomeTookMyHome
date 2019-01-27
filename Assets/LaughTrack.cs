using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaughTrack : MonoBehaviour
{

    public AudioClip[] laughs;
    public AudioSource source;
    public int minInterval = 5;
    private int lastLaugh;
    
    // Start is called before the first frame update
    void Start()
    {
        lastLaugh = 0;
    }

    // Update is called once per frame
    void Update()
    {
        int now = (int)Time.unscaledTime;
        if (now - lastLaugh - minInterval > (int)Random.Range(0,5)) {
            source.clip = laughs[(int)Random.Range(0,3)];
            source.Play();
            lastLaugh = now;
        }


        
    }
}
