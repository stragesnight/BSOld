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

    protected EAttackState _attackState = EAttackState.Done;
    protected float _anticipationTimer;
    protected float _calldownTimer;


    // Get required components and variables
    protected virtual void Start()
    {
        _entity = GetComponent<EntityBehaviour>();
        _stateMachine = _entity.stateMachine;
    }


    private void Update()
    {
        // Tick needed timer
        switch (_attackState)
        {
            case EAttackState.Anticipation:
                _anticipationTimer -= Time.deltaTime;
                // Call OnAnticipationCompleted if timer is below zero
                if (_anticipationTimer <= 0)
                    OnAnticipationCompleted();
                break;
            case EAttackState.Calldown:
                _calldownTimer -= Time.deltaTime;
                // Call OnCalldownCompleted if timer is below zero
                if (_calldownTimer <= 0)
                    OnCalldownCompleted();
                break;
        }
    }


    protected virtual void OnAttackInputReceived()
    {
        // Get held weapon
        _heldWeapon = (WeaponItemSO)_entity.HeldItem;

        // If Entity can attack in current state and if weapon is not on calldown
        if (_stateMachine.GetState().Attackable && _attackState == EAttackState.Done )
        {
            _anticipationTimer = _heldWeapon.attackAnticipation;
            _attackState = EAttackState.Anticipation;
            _stateMachine.SetState(EState.Attacking);
        }
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

        // Initiate timer and change states
        _calldownTimer = _heldWeapon.attackCalldown;
        _attackState = EAttackState.Calldown;
        _stateMachine.SetState(EState.Default);
    }


    private void OnAnticipationCompleted()
    {
        // Change state to Attack
        _attackState = EAttackState.Attack;
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
    }


    private void OnCalldownCompleted()
    {
        // Change internal state to done
        _attackState = EAttackState.Done;
    }


    protected virtual void OnTargetPositionChanged(Vector2 targetPosition)
    {
        Vector2 deltaVector = (targetPosition - (Vector2)transform.position).normalized;

        _angleToTarget = Vector2.SignedAngle(Vector2.up, deltaVector);
        _weaponPositionOffset = deltaVector;
    }


    public enum EAttackState { Anticipation, Attack, Calldown, Done }
}
