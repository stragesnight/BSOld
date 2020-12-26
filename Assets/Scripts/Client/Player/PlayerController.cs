using UnityEngine;

/// <summary>
/// PlayerController is responsible for Player activity and input
/// </summary>
public class PlayerController : MonoBehaviour
{
    // Serialized variables
    [Header("Dependencies")]
    [SerializeField] Camera cam;

    [Header("Player parameters")]
    [SerializeField] [Range(0, 1)] float cameraSensitivity;

    //Unserialized variables

    Vector3 mouseScreenPos;
    Vector3 deltaMouseScreenPos = Vector3.zero;


    void Update()
    {
        GetInputs();

        if (Input.GetMouseButton(0))
            HandleCameraMovement();
    }


    // Gather inputs and store them
    void GetInputs()
    {
        // Compare previous mouse position and it's position last frame
        deltaMouseScreenPos = mouseScreenPos - Input.mousePosition;
        deltaMouseScreenPos.z = 0;

        // Get current mouse position
        mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = 0;
    }


    void HandleCameraMovement()
    {
        cam.transform.position += deltaMouseScreenPos * cameraSensitivity;
    }
}
