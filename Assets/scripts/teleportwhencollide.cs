using UnityEngine;
using System.Collections;

public class TeleportOnCollision : MonoBehaviour
{
    private CharacterController characterController;
    private MonoBehaviour fpsController;
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        fpsController = GetComponent<FPSControlelr>();
    }
    public Transform teleportLocation;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            
            fpsController.enabled = false;
            characterController.enabled = false;
            transform.position = teleportLocation.position;
            StartCoroutine(ReenableController());
        }
    }
    private IEnumerator ReenableController()
    {
        yield return new WaitForSeconds(0.1f); 
        characterController.enabled = true;
        fpsController.enabled = true;

    }
}
//reference: https://codepal.ai/code-generator/query/uNzb2Vh9/csharp-teleport-on-collision