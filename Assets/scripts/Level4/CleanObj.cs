using UnityEngine;
using UnityEngine.Events;

public class CleanObj : MonoBehaviour, IInteractable
{
    public string promptText = "Press E to clean";
    public UnityEvent onInteract;
    public GameObject real;
    public PlaySound sound;
    public float vol;

    public string GetInteractionText()
    {
        return promptText;
    }

    public void Interact()
    {
        sound.Play(vol);
        real.SetActive(true);
        Destroy(this.gameObject);
    }
}