using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class ObjectiveManager : MonoBehaviour
{
    public TextMeshProUGUI objectiveText; // Reference to the UI text displaying objectives
    private List<string> objectives; // List of objectives
    private int currentObjectiveIndex = 0; // Track the current objective index

    void Start()
    {
        // Initialize objectives
        objectives = new List<string>
        {
            "Medicate from bedroom pills",
            "Medicate from bedroom tabs",
            "Medicate from bathroom pills",
            "Medicate from bathroom needle"
        };

        UpdateObjectiveUI(); // Display the first objective
    }

    // Call this method when an objective is completed
    public void CompleteObjective()
    {
        if (currentObjectiveIndex < objectives.Count)
        {
            Debug.Log($"Objective completed: {objectives[currentObjectiveIndex]}");
            currentObjectiveIndex++; // Move to the next objective

            if (currentObjectiveIndex < objectives.Count)
            {
                UpdateObjectiveUI(); // Update UI with the next objective
            }
            else
            {
                // All objectives are complete
                objectiveText.text = "All objectives completed!";
                Debug.Log("All objectives completed!");
            }
        }
    }

    // Update the UI with the current objective
    private void UpdateObjectiveUI()
    {
        if (currentObjectiveIndex < objectives.Count)
        {
            objectiveText.text = $"Objective: {objectives[currentObjectiveIndex]}";
        }
    }
}
