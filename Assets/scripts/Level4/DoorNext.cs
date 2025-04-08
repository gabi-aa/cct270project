using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class DoorNext : MonoBehaviour, IInteractable
{
    public string promptText = "Press E to leave";
    public string promptLocked = "I still have things to clean";
    public bool locked = true;
    public UnityEvent onInteract;

    public string GetInteractionText()
    {
        if (!locked)
        {
            return promptText;
        }
        return promptLocked;
    }

    public void Interact()
    {
        if (!locked)
        {
            SceneManager.LoadScene("MainHub");
        }
        
    }
}
