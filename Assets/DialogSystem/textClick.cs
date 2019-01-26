using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textClick : MonoBehaviour
{
    public GameObject parent;
    public string[] dialog;

    public AudioClip[] soundClips;
    public AudioSource audioSource;



    public Text question, answ1, answ2;
    public GameObject ansb1,ansb2;
    int currentq;

    public void Start() {
        currentq = 0;
        setDialogText();
    }

    private void setDialogText() {
        question.text = dialog[currentq];
        audioSource.clip = soundClips[currentq];
        audioSource.Play();
        if (currentq+1 < dialog.Length) {
            ansb1.SetActive(true);
            answ1.text = getMessage(dialog[currentq+1]);
        } else {
            ansb1.SetActive(false);
            Destroy(parent, audioSource.clip.length+1);
            
        }
        if (currentq+2 < dialog.Length && dialog[currentq+2] != "") {
            ansb2.SetActive(true);
            answ2.text = getMessage(dialog[currentq+2]);
        } else {
            ansb2.SetActive(false);
        }
    }

    public string getMessage(string code) {
        int pos = code.IndexOf(' ');
        return code.Substring(pos+1);
    }

    public void selectAnswer(int id) {
        string nexts = dialog[currentq+id].Split(' ')[0];
        int next = int.Parse(nexts);
        currentq = next;
        setDialogText();
    }
   
}
