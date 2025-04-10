using UnityEngine;
using UnityEngine.Events;

public class CleanTrash : MonoBehaviour, IInteractable
{
    // This is for objects that are cleared away. 
    public string promptText = "Press E to clean";
    public UnityEvent onInteract;
    public PlaySound sound;
    public float vol;

    public string GetInteractionText()
    {
        return promptText;
    }

    public void Interact()
    {
        sound.Play(vol);
        Destroy(this.gameObject);
    }
}