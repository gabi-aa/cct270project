using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorNext : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        SceneManager.LoadScene("MainHub");
    }
}
