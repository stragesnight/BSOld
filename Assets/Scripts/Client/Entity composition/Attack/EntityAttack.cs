using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Entity Attack handler.
/// </summary>
[RequireComponent(typeof(EntityBehavoiur))]
public abstract class EntityAttack : MonoBehaviour
{
    protected EntityBehavoiur _entity;
    protected StateMachine _stateMachine;

    protected WeaponSO _heldWeapon;

    protected bool _isOnCalldown = false;


    // Actions
    public Action<int> damageAction;


    // Get required components and variables
    protected virtual void Start()
    {
        _entity = GetComponent<EntityBehavoiur>();

        _heldWeapon = _entity.entityData.GetHeldWeapon();
        _stateMachine = _entity.stateMachine;
    }


    protected virtual void OnAttack()
    {
        if (_stateMachine.GetState().Attackable && !_isOnCalldown)
        {
            switch (_heldWeapon.attackType)
            {
                case EAttackType.MeleeCirce:
                    PreformMeleeCircleAttack((MeleeWeaponItemSO)_heldWeapon);
                    break;
            }

            StartCoroutine(StartWeaponCalldown());
        }
    }


    protected virtual void PreformMeleeCircleAttack(MeleeWeaponItemSO weapon)
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(_entity.transform.position, weapon.attackRadius);

        foreach (Collider2D hit in hits)
        {
            bool isEntity = hit.TryGetComponent(out EntityBehavoiur checkedEntity);
            if (isEntity)
            {
                if (hit.gameObject != _entity.gameObject && _entity.currentReaction != checkedEntity.currentReaction)
                {
                    EntityHealth entityHealth = hit.gameObject.GetComponent<EntityHealth>();
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


    protected virtual void OnDrawGizmos()
    {
        if (_heldWeapon == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, ((MeleeWeaponItemSO)_heldWeapon).attackRadius);
        Gizmos.color = Color.white;
    }
}
