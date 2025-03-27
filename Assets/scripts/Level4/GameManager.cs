using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int numCleaned = 0;
    public GameObject door;

    public void UpdateScore()
    {
        numCleaned++;
        if (numCleaned == 4)
        {
            int layer = LayerMask.NameToLayer("Interactable");
            door.layer = layer;
            Debug.Log("Door has been unlocked.");
        }
    }
}
