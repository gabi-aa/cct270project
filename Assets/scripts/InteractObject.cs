using UnityEngine;
using UnityEngine.Events;

public class InteractObject : MonoBehaviour
{
    public string interactionText = "Press E to Interact";
    public UnityEvent onInteract;

    // Add a flag for whether this object is a drug
    public bool isDrug;

    public string GetInteractionText()
    {
        return interactionText;
    }

    public bool Interact()
    {
        onInteract.Invoke();
        return isDrug; // Return the drug status
    }
}