using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    void OnMouseUp()
    {
        SceneManager.LoadScene("room");
    } 

}
