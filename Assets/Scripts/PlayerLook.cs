using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    public float mouseSensitivity = 50f;    // Final sensitivity used
    public Transform cam;                   // Camera transform (child of Player)

    private float xRotation = 0f;           // Vertical rotation accumulator
    private Vector2 lookInput;              // From input system (mouse delta)
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;   // Lock cursor to center
        Cursor.visible = false;                     // Hide cursor
    }

    void OnLook(InputValue value)                   // Action name "Look" -> OnLook
    {
        lookInput = value.Get<Vector2>();           // Read mouse delta (x, y)
    }
    void Update()
    {
        HandleMouseLook();                          // Apply look every frame
    }

    void HandleMouseLook()
    {
        float mouseX = lookInput.x * mouseSensitivity * Time.deltaTime; // yaw
        float mouseY = lookInput.y * mouseSensitivity * Time.deltaTime; // pitch

        xRotation -= mouseY;                // Invert for natural pitch
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);   // Limit vertical look
        cam.localRotation = Quaternion.Euler(xRotation, 0f, 0f);    // pitch on cam

        transform.Rotate(Vector3.up * mouseX);  // Yaw on player body (Y axis)
    }
}
