using UnityEngine;
using UnityEngine.Events;

public class CleanTrash : MonoBehaviour, IInteractable
{
    // This is for objects that are cleared away. 
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