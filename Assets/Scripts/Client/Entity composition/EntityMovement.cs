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

    private Vector2 movementDirection;


    // Get required components
    private void Start()
    {
        entity = GetComponent<EntityBehavoiur>();
        controller = GetComponent<CharacterController>();
    }


    private void OnEnable()
    {
        inputReader.moveAction += OnEntityMove;
    }


    private void OnDisable()
    {
        inputReader.moveAction -= OnEntityMove;
    }


    private void Update()
    {
        controller.Move(movementDirection * entity.speed * Time.deltaTime);
    }


    private void OnEntityMove(Vector2 direction)
    {
        movementDirection = direction;
    }
}
