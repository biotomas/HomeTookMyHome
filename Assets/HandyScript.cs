using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandyScript : MonoBehaviour
{

    public Text text;
    public AudioSource source;
    public AudioClip dial, occupied, itcrowd;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void dialButton(int button) {
        if (button > 0) {
            source.clip = dial;
            source.Play();
            text.text += button;
        } else {
            if (text.text == "01189998819991197253") {
                source.clip = itcrowd;
                source.Play();
                text.text = "0";
                return;
            }
            if (text.text == "523367") {
                text.text = "0";
                //TODO spaghetti order
                return;
            }
            source.clip = occupied;
            source.Play();
            text.text = "0";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
