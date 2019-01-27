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
    public AudioClip dial, occupied, itcrowd;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void dialButton(int button) {
        Debug.Log("Dialed " + button);
        if (button == -2) {
            GameMasterScript.instance.changeCameraTo(2);
            parent.SetActive(false);
            return;
        }
        if (button > 0) {
            source.clip = dial;
            source.Play();
            text.text += button;
        } else {
            Debug.Log("dialing " + text.text);
            if (text.text.Equals("1189998819991197253")) {
                source.clip = itcrowd;
                source.Play();
                text.text = "";
                return;
            }
            if (text.text.Equals("523367")) {
                dialogSpawner.startDialog(4);
                text.text = "";
                return;
            }
            source.clip = occupied;
            source.Play();
            text.text = "";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
