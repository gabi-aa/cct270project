 using UnityEngine;
using UnityEngine.Rendering;

public class FPSControlelr : MonoBehaviour
{
    public float WalkSpeed = 5f;
    public float SprintMultiplier = 2f;
    public float JumpForce = 5f;
    public float GroundCheckDistance = 1f;
    public float LookSensX = 1f;
    public float LookSensY = 1f;
    public float MinYLookAngle = -90f;
    public float MaxYLookAngle = 90f;
    public float Gravity = -9f;
    private Vector3 velocity;
    private float verticalRotation = 0f;
    public Transform PlayerCamera;
    private CharacterController characterController;

    void Awake()
    {
       characterController = GetComponent<CharacterController>();
       Cursor.lockState = CursorLockMode.Locked;

    }

    void Update()
    {
        float horizontalMov = Input.GetAxisRaw("Horizontal");
        float verticalMov = Input.GetAxisRaw("Vertical");

        Vector3 moveDirection = transform.forward * verticalMov + transform.right * horizontalMov;
        moveDirection.Normalize();

        float speed = WalkSpeed;
      

        characterController.Move(moveDirection * speed * Time.deltaTime);

        velocity.y += Gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);

        if (PlayerCamera != null)
        {
            float mouseX = Input.GetAxis("Mouse X") * LookSensX;
            float mouseY = Input.GetAxis("Mouse Y") * LookSensY;

            verticalRotation -= mouseY;
            verticalRotation = Mathf.Clamp(verticalRotation, MinYLookAngle, MaxYLookAngle);

            PlayerCamera.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
            transform.Rotate(Vector3.up * mouseX);



        }
    }
    bool isGrounded()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, GroundCheckDistance))
        {
            return true;
        }
        return false;
    }
}
