using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

interface IInteractable
{
    public void Interact();
    public string GetInteractionText();
}

public class Clean : MonoBehaviour
{
    public Transform interactorSource;
    public float interactRange = 0.5f;
    public int cleanedCount = 0;
    public InteractionUI UI;

    private readonly Collider[] colliders = new Collider[3];

    [SerializeField] private LayerMask interactorMask;
    [SerializeField] private int numFound;
    [SerializeField] private GameManager manager;

    private IInteractable interactable;

    // Update is called once per frame
    void Update()
    {
        numFound = Physics.OverlapSphereNonAlloc(interactorSource.position, interactRange, colliders, interactorMask);

        if (numFound > 0)
        {
            interactable = colliders[0].GetComponent<IInteractable>();

            if (interactable != null)
            {
                if (!UI.isDisplayed) { UI.setup(interactable.GetInteractionText()); }

                if (Keyboard.current.eKey.wasPressedThisFrame)
                {
                    manager.UpdateScore();
                    interactable.Interact();
                    UI.close();
                }

            }
        }
        else
        {
            if (interactable != null) { interactable = null; }
            if (UI.isDisplayed) { UI.close(); }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactorSource.position, interactRange);
    }
}
