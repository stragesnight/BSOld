using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Entity Attack handler.
/// </summary>
[RequireComponent(typeof(EntityBehaviour))]
public abstract class EntityAttack : MonoBehaviour
{
    protected EntityBehaviour _entity;
    protected StateMachine _stateMachine;

    protected WeaponItemSO _heldWeapon;

    protected float _angleToTarget;
    protected Vector3 _weaponPositionOffset;

    protected bool _isOnCalldown = false;


    // Get required components and variables
    protected virtual void Start()
    {
        _entity = GetComponent<EntityBehaviour>();

        _stateMachine = _entity.stateMachine;
    }


    protected virtual void OnAttack()
    {
        // Get held weapon
        _heldWeapon = (WeaponItemSO)_entity.HeldItem;

        // If Entity can attack in current state and if weapon is not on calldown
        if (_stateMachine.GetState().Attackable && !_isOnCalldown)
        {
            // Change state to attacking
            _stateMachine.SetState(EState.Attacking);

            // Find needed attack type
            switch (_heldWeapon.attackType)
            {
                case EAttackType.MeleeCirce:
                    InitiateMeleeCircleAttack((MeleeWeaponItemSO)_heldWeapon);
                    break;

                case EAttackType.MeleeLine:
                    InitiateMeleeLineAttack((MeleeWeaponItemSO)_heldWeapon);
                    break;
            }

            // Change state to default
            _stateMachine.SetState(EState.Default);

            // Call WeaponCalldown
            StartCoroutine(StartWeaponCalldown());
        }
    }


    protected virtual void OnTargetPositionChanged(Vector2 targetPosition)
    {
        Vector2 deltaVector = (targetPosition - (Vector2)transform.position).normalized;

        _angleToTarget = Vector2.SignedAngle(Vector2.up, deltaVector);
        _weaponPositionOffset = deltaVector;
    }


    protected virtual void InitiateMeleeCircleAttack(MeleeWeaponItemSO weapon)
    {
        // Get all Collider2D in a attack radius
        Collider2D[] hits = Physics2D.OverlapCircleAll(_entity.transform.position, weapon.attackRange);
        PreformAttack(weapon, hits);
    }


    protected virtual void InitiateMeleeLineAttack(MeleeWeaponItemSO weapon)
    {
        //Collider2D[] hits = Physics2D.OverlapCapsuleAll(transform.position, new Vector2(1, weapon.attackRange), CapsuleDirection2D.Vertical, _angleToTarget);
        Vector3 weaponOffset = _weaponPositionOffset * weapon.attackRange / 2;
        Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position + weaponOffset, new Vector2(1, weapon.attackRange), _angleToTarget);
        
        PreformAttack(weapon, hits);
    }


    protected virtual void PreformAttack(WeaponItemSO weapon, Collider2D[] hits)
    {
        foreach (Collider2D hit in hits)
        {
            // Try to get EntityBehaviour
            if (hit.TryGetComponent(out EntityBehaviour checkedEntity))
            {
                // If checked Entity is not self and if their reaction are different
                if (hit.gameObject != _entity.gameObject && _entity.currentReaction != checkedEntity.currentReaction)
                {
                    // Try to access EntityHealth 
                    EntityHealth entityHealth = hit.gameObject.GetComponent<EntityHealth>();
                    // And call OnHealthChange
                    if (entityHealth)
                        entityHealth.OnHealthChange(weapon.damage);
                }
            }
        }
    }


    protected virtual IEnumerator<WaitForSeconds> StartWeaponCalldown()
    {
        _isOnCalldown = true;

        GetComponentInChildren<SpriteRenderer>().color = Color.yellow;

        yield return new WaitForSeconds(_heldWeapon.attackCalldown);

        GetComponentInChildren<SpriteRenderer>().color = Color.white;

        _isOnCalldown = false;
    }
}
