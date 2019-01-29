using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoombaMove : MonoBehaviour {
    public float minimumX;
    public float maximumX;
    public float speed;
    
    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.localPosition.x < minimumX || gameObject.transform.localPosition.x > maximumX) {
            speed *= -1;
        }
        gameObject.transform.Translate(speed, 0, 0);
    }
}
