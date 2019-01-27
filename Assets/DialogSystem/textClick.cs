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

    public void OnEnable() {
        currentq = 0;
        setDialogText();
    }

    private void setDialogText() {
        question.text = dialog[currentq];
        if (soundClips.Length > currentq) {
            audioSource.clip = soundClips[currentq];
            audioSource.Play();
        }
        ansb1.SetActive(false);
        ansb2.SetActive(false);
        if (isSet(1)) {
            ansb1.SetActive(true);
            answ1.text = getMessage(dialog[currentq+1]);
        } else {
            if (audioSource.clip == null)
            {
                Invoke("deactivate", 2);     
            }
            else
            {
                Invoke("deactivate", audioSource.clip.length + 2);
            }
        }
        if (isSet(2)) {
            ansb2.SetActive(true);
            answ2.text = getMessage(dialog[currentq+2]);
        }
    }

    private bool isSet(int id) {
        if (currentq+id >= dialog.Length) {
            return false;
        }
        string msg = dialog[currentq+id];
        return msg.Length > 1;
    }

    private void deactivate() {
        parent.SetActive(false);
    }

    public string getMessage(string code) {
        int pos = code.IndexOf(' ');
        string msg = code.Substring(pos+1);
        Debug.Log("::" + msg + "::");
        if (msg.StartsWith("-c-")) {
            msg = msg.Substring(msg.IndexOf(' '));
        }
        return msg;
    }

    public void selectAnswer(int id) {
        string nexts = dialog[currentq+id].Split(' ')[0];
        if (dialog[currentq+id].Split(' ')[1].StartsWith("-c-")) {
            GameMasterScript.instance.setFlag(dialog[currentq+id].Split(' ')[1]);
        }
        Debug.Log("next "+nexts);
        int next = int.Parse(nexts);
        currentq = next;
        setDialogText();
    }
   
}
