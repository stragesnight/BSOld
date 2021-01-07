using UnityEngine;

/// <summary>
/// Base Entity Movement class that all movemment types will inherit from.
/// </summary>
[RequireComponent(typeof(EntityBehavoiur), typeof(Rigidbody2D))]
public abstract class EntityMovement : MonoBehaviour
{
    protected EntityBehavoiur entity;
    protected Rigidbody2D rb;

    protected Vector2 movementDirection;


    // Get required components
    protected virtual void Start()
    {
        entity = GetComponent<EntityBehavoiur>();
        rb = GetComponent<Rigidbody2D>();
    }


    // Change Rigidbody's velocity
    protected virtual void FixedUpdate()
    {
        rb.AddForce(movementDirection * entity.speed * Time.fixedDeltaTime);
    }


    // Called when movement direction needs to be changed
    protected void OnChangeMovementDirection(Vector2 direction)
    {
        movementDirection = direction;
    }
}
