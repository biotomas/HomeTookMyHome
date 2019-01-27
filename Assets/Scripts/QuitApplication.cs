using UnityEngine;
using System.Collections;

// Quits the player when the user hits escape

public class QuitApplication : MonoBehaviour
{
    void OnMouseUp()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
