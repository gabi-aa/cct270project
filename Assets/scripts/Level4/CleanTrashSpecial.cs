using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class CleanTrashSpecial : MonoBehaviour, IInteractable
{
    // This is for objects that are cleared away. 
    public string promptText = "Press E to clean";
    public GameObject next;
    public UnityEvent onInteract;
    public PlaySound sound;

    public string GetInteractionText()
    {
        return promptText;
    }

    public void Interact()
    {
        int layer = LayerMask.NameToLayer("Interactable");
        next.layer = layer;
        sound.Play();
        Destroy(this.gameObject);
    }
}
