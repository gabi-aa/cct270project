using UnityEngine;

public class CursorUnlocked : MonoBehaviour
{
    void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Debug.Log("I am here");
        //Your code here
    }
}
