using UnityEngine;
using TMPro;
using UnityEngine.Rendering;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public Camera PlayerCamera;
    public float InteractionDist = 3f;
    public GameObject interactionText;
    public Volume DrugVolume; // Reference to your Volume
    private InteractObject currentInteractable;
    private float InteractionScore = 0;

    public ObjectiveManager objectiveManager; // Reference to the ObjectiveManager script

    private bool filterApplied = false;

    void Start()
    {
        if (DrugVolume != null)
        {
            DrugVolume.enabled = false; // Disable it initially
        }
        else
        {
            Debug.LogError("DrugVolume is not assigned!");
        }
    }

    void Update()
    {
        // Handle raycast for interactions
        Ray ray = PlayerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, InteractionDist))
        {
            InteractObject interactableObject = hit.collider.GetComponent<InteractObject>();
            if (interactableObject != null && interactableObject != currentInteractable)
            {
                currentInteractable = interactableObject;
                interactionText.SetActive(true);
                TextMeshProUGUI textComponent = interactionText.GetComponent<TextMeshProUGUI>();
                if (textComponent != null)
                {
                    textComponent.text = currentInteractable.GetInteractionText();
                }
            }
        }
        else
        {
            currentInteractable = null;
            interactionText.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.E) && currentInteractable != null)
        {
            InteractionScore += 1;
            Debug.Log(InteractionScore);
            bool isDrug = currentInteractable.Interact();
            if (isDrug)
            {
                Debug.Log($"Drug interaction detected. Score updated to {InteractionScore}.");

                // Update objectives if InteractionScore matches the number of objectives
                if (objectiveManager != null)
                {
                    objectiveManager.CompleteObjective();
                }

                // Check if InteractionScore reaches 4 and activate the DrugVolume
                if (InteractionScore >= 4 && !filterApplied)
                {
                    ActivateVolume();
                }
            }
        }
    }

    void ActivateVolume()
    {
        if (DrugVolume != null)
        {
            DrugVolume.enabled = true; // Simply enable the component
            filterApplied = true; // Prevent reactivation
            Debug.Log("DrugVolume component activated.");
        }
        else
        {
            Debug.LogError("DrugVolume reference is missing!");
        }
    }
}
