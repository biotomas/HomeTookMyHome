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
                
                // Move inventory icon, but not to the phone room
                if (i != 6) {
                    inventoryIcon.transform.position = cameras[i].ScreenToWorldPoint(new Vector3(cameras[i].pixelWidth * 9 / 10, cameras[i].pixelHeight * 1 / 8));
                }

                // If we get to the kitchen and ordered spaghett, then they will arrive now
                if (i == 3 && getFlag("-c-ordered")) {
                    SpawnSpaghett();
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

    public void setFlag(string name, bool value = true) {
        if (value) {
            flags.Add(name);
        }
        else {
            flags.Remove(name);
        }
    }
    
    
    // ==================================================

    private void SpawnSpaghett() {
        Vector3 spaghettPosition = cameras[3].ScreenToWorldPoint(new Vector3(cameras[3].pixelWidth / 2,
            cameras[3].pixelHeight / 2));
        GameObject newSpaghett = Instantiate(spaghett, spaghettPosition, Quaternion.identity);
        newSpaghett.GetComponent<TakeSpaghett>().dialogSpawner =
            spaghett.GetComponent<TakeSpaghett>().dialogSpawner;
        newSpaghett.GetComponent<DynamicObject>().audioSource =
            spaghett.GetComponent<DynamicObject>().audioSource;
        audioSource.clip = deliveryThreeFifty;
        audioSource.Play();
        setFlag("-c-ordered", false);
    }

}
