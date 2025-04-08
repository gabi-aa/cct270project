using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InteractionUI : MonoBehaviour
{
    private Camera main;
    [SerializeField] private GameObject UIpanel;
    [SerializeField] private TMP_Text prompt;
    public bool isDisplayed = false;
    
    void Start()
    {
        main = Camera.main; //cache   
        UIpanel.SetActive(false);
    }

    // Update is called once per frame
    /*void Update()
    {
        var rotation = main.transform.rotation;
        transform.LookAt(transform.position + rotation * Vector3.forward, rotation * Vector3.up);
    }*/

    public void setup(string promptext)
    {
        prompt.text = promptext;
        UIpanel.SetActive(true);
        isDisplayed = true;
    }

    public void close()
    {
        isDisplayed = false;
        UIpanel.SetActive(false);
    }
}
