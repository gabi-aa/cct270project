using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

interface IInteractable
{
    public void Interact();
}

public class Clean : MonoBehaviour
{
    public Transform interactorSource;
    public float interactRange = 0.5f;
    public int cleanedCount = 0;
    private readonly Collider[] colliders = new Collider[3];
    [SerializeField] private LayerMask interactorMask;
    [SerializeField] private int numFound;
    [SerializeField] private GameManager manager;

    // Update is called once per frame
    void Update()
    {
        numFound = Physics.OverlapSphereNonAlloc(interactorSource.position, interactRange, colliders, interactorMask);
        if(numFound > 0 )
        {
            var interactable = colliders[0].GetComponent<IInteractable>();
            if( interactable != null && Keyboard.current.eKey.wasPressedThisFrame)
            {
                manager.UpdateScore();
                interactable.Interact();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactorSource.position, interactRange);
    }
}
