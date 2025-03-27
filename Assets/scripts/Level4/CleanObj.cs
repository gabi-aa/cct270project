using UnityEngine;
using UnityEngine.Events;

public class CleanObj : MonoBehaviour, IInteractable
{
    public string promptText = "Press E to clean";
    public UnityEvent onInteract;

    public string GetInteractionText()
    {
        return promptText;
    }

    public void Interact()
    {
        Destroy(this.gameObject);
    }
}