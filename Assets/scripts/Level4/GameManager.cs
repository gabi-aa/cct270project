using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int numCleaned = 0;
    public DoorNext door;
    public int limit = 20;
    [SerializeField] private GameObject UIpanel;

    void Start()
    {
        UIpanel.SetActive(false);
    }

    public void UpdateScore()
    {
        numCleaned++;
        if (numCleaned == limit)
        {
            door.locked = false;
            UIpanel.SetActive(true);
        }
    }
}
