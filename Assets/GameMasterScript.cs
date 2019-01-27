using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMasterScript : MonoBehaviour
{
    public static GameMasterScript instance;

    public Camera[] cameras;

    public GameObject inventoryIcon;

    public GameObject spaghett;

    //public DialogSpawner dialogSpawner;
    //public int spaghettDialog;

    public AudioSource audioSource;
    public AudioClip deliveryThreeFifty;
    
    

    public DynamicObject CurrentHeldItem { get; set; }

    
    public void changeCameraTo(int index) {
        for (int i = 0; i < cameras.Length; i++) {
            if (i == index) {
                cameras[i].enabled = true;
                inventoryIcon.transform.position = cameras[i].ScreenToWorldPoint(new Vector3(cameras[i].pixelWidth - 40, 32));

                if (i == 3 && getFlag("-c-ordered") && !getFlag("-c-delivered"))
                {
                    spaghett.transform.position = cameras[i].ScreenToWorldPoint(new Vector3(cameras[i].pixelWidth / 2, cameras[i].pixelHeight / 2));
                    audioSource.clip = deliveryThreeFifty;
                    audioSource.Play();
                    setFlag("-c-delivered");
                }
            } else {
                cameras[i].enabled = false;
            }
        }
    }

    private HashSet<string> flags;

    public void Start() {
        instance = this;
        flags = new HashSet<string>();
        changeCameraTo(0);
    }
    
    public bool getFlag(string name) {
        return flags.Contains(name);
    }

    public void setFlag(string name) {
        flags.Add(name);
    }

}
