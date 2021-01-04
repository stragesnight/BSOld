using UnityEngine;

/// <summary>
/// Handles Entity's movement.
/// </summary>
[RequireComponent(typeof(EntityBehavoiur), typeof(CharacterController))]
public class EntityMovement : MonoBehaviour
{
    [SerializeField] private InputReader inputReader;

    private EntityBehavoiur entity;
    private CharacterController controller;


    // Get required components
    private void Start()
    {
        entity = GetComponent<EntityBehavoiur>();
        controller = GetComponent<CharacterController>();
    }


    private void OnEnable()
    {
        inputReader.moveAction += Move;
    }


    private void OnDisable()
    {
        inputReader.moveAction -= Move;
    }


    private void Move(Vector2 direction)
    {
        controller.SimpleMove(direction * entity.speed * Time.deltaTime);
    }
}
