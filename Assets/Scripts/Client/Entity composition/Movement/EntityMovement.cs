using UnityEngine;

/// <summary>
/// Base Entity Movement class that all movement types will inherit from.
/// </summary>
[RequireComponent(typeof(EntityBehavoiur), typeof(Rigidbody2D))]
public abstract class EntityMovement : MonoBehaviour
{
    protected EntityBehavoiur _entity;
    protected Rigidbody2D _rb;

    protected float _speed;

    protected Vector2 _movementDirection;


    // Get required components and variables
    protected virtual void Start()
    {
        _entity = GetComponent<EntityBehavoiur>();
        _rb = GetComponent<Rigidbody2D>();

        _speed = _entity.entityData.GetSpeed();
    }


    // Change Rigidbody's velocity
    protected virtual void FixedUpdate()
    {
        _rb.AddForce(_movementDirection * _speed * Time.fixedDeltaTime);
    }


    // Called when movement direction needs to be changed
    protected void OnChangeMovementDirection(Vector2 direction)
    {
        _movementDirection = direction;
    }
}
