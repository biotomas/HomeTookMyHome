using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandyScript : MonoBehaviour
{

    public Text text;
    public AudioSource source;
    public GameObject parent;
    public DialogSpawner dialogSpawner;
    public AudioClip dial, occupied, itcrowd, startCallSound;
    // Start is called before the first frame update
    void Start()
    {
        text.text = "";
    }

    public void dialButton(int button) {
        Debug.Log("Dialed " + button);
        if (button == -2) {
            GameMasterScript.instance.changeCameraTo(2);
            parent.SetActive(false);
            return;
        }
        if (button >= 0) {
            source.clip = dial;
            source.Play();
            text.text += button;
        } else {
            StartCoroutine(startCall(text.text));
            Debug.Log("dialing " + text.text);
        }
    }


    
    IEnumerator startCall(String number)
    {
        source.clip = startCallSound;
        source.Play();
                
        yield return new WaitForSeconds(2);
                
        placeCall(number);
    }

    void placeCall(String number) {
        if (text.text.Equals("01189998819991197253")) {
            source.clip = itcrowd;
            source.Play();
            text.text = "";
            return;
        }
        
        if (text.text.Equals("523367")) {
            source.Stop();
            dialogSpawner.startDialog(4);
            text.text = "";
            return;
        }
        
        source.clip = occupied;
        source.Play();
        text.text = "";
    }
}
