using UnityEngine;

/// <summary>
/// Handles Entity's movement.
/// </summary>
[RequireComponent(typeof(EntityBehavoiur), typeof(Rigidbody2D))]
public class EntityMovement : MonoBehaviour
{
    [SerializeField] private InputReader inputReader;

    private EntityBehavoiur entity;
    private Rigidbody2D rb;

    private Vector2 movementDirection;


    // Get required components
    private void Start()
    {
        entity = GetComponent<EntityBehavoiur>();
        rb = GetComponent<Rigidbody2D>();
    }


    private void OnEnable()
    {
        inputReader.moveAction += OnEntityMove;
    }


    private void OnDisable()
    {
        inputReader.moveAction -= OnEntityMove;
    }


    private void FixedUpdate()
    {
        rb.velocity = movementDirection * entity.speed * Time.fixedDeltaTime;
    }


    private void OnEntityMove(Vector2 direction)
    {
        movementDirection = direction;
    }
}
