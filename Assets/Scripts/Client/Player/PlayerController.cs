using UnityEngine;

/// <summary>
/// PlayerController is responsible for Player activity and input
/// </summary>
public class PlayerController : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private Camera cam;
    [SerializeField] private ConstructionSO building;
    [SerializeField] private MapZone mapZone;

    [Header("Player parameters")]
    [SerializeField] [Range(0, 1)] private float cameraSensitivity;


    private Vector3 mouseScreenPos;
    private Vector3 deltaMouseScreenPos = Vector3.zero;


    private void Update()
    {
        GetInputs();

        if (Input.GetMouseButton(0))
            HandleCameraMovement();

        Vector3 position = cam.ScreenToWorldPoint(mouseScreenPos);
        Vector3Int cellPosition = new Vector3Int((int)position.x, (int)position.y, 0);

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            MapData.Instance.SetConstructionAtPoint(cellPosition, building);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            MapData.Instance.SetNatureAtPoint(cellPosition, mapZone);
        }
    }


    // Gather inputs and store them
    private void GetInputs()
    {
        // Compare previous mouse position and it's position last frame
        deltaMouseScreenPos = mouseScreenPos - Input.mousePosition;
        deltaMouseScreenPos.z = 0;

        // Get current mouse position
        mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = 0;
    }


    private void HandleCameraMovement()
    {
        cam.transform.position += deltaMouseScreenPos * cameraSensitivity;
    }
}
