using UnityEngine;
using UnityEngine.Events;

public class DrugInteraction : MonoBehaviour
{
    public string interactionText = "Press E to Medicate";
    public UnityEvent onInteract;

    public string GetInteractionText()
    {
        return interactionText;
    }

    public bool Interact()
    {
        onInteract.Invoke();
        return true;
    }
}
