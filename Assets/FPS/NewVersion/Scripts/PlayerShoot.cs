using System;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    static public Action shootinput;
    static public Action reloadinput;
    [SerializeField] private KeyCode reloadkey;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            shootinput?.Invoke();
        }
        if (Input.GetKeyDown(reloadkey))
        {
            reloadinput?.Invoke();
        }

    }
}
