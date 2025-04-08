using UnityEngine;
using UnityEngine.Events;

public class CleanObj : MonoBehaviour, IInteractable
{
    public string promptText = "Press E to clean";
    public UnityEvent onInteract;
    public GameObject real;

    public string GetInteractionText()
    {
        return promptText;
    }

    public void Interact()
    {
        real.SetActive(true);
        Destroy(this.gameObject);
    }
}