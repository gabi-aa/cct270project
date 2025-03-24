using UnityEngine;
using UnityEngine.SceneManagement;

public class drumkit : MonoBehaviour

{
    public void Back2Menu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    

}
