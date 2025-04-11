using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public bool locked = true;

    public void LeaveLevel()
    {
        if (!locked)
        {
            SceneManager.LoadScene("MainHub");
        }
    }
}
