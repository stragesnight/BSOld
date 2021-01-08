using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Entity Attack handler.
/// </summary>
[RequireComponent(typeof(EntityBehavoiur))]
public class EntityAttack : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    private EntityBehavoiur _entity;
    private StateMachine _stateMachine;

    private WeaponSO _heldWeapon;

    private bool _isOnCalldown = false;


    // Actions
    public Action<int> damageAction;


    // Get required components and variables
    public void Start()
    {
        _entity = GetComponent<EntityBehavoiur>();

        _heldWeapon = _entity.entityData.GetHeldWeapon();
        _stateMachine = _entity.stateMachine;
    }


    private void OnEnable()
    {
        _inputReader.attackAction += OnAttackInputReceived;
    }


    private void OnDisable()
    {
        _inputReader.attackAction -= OnAttackInputReceived;
    }


    private void OnAttackInputReceived()
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


    private void PreformMeleeCircleAttack(MeleeWeaponItemSO weapon)
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(_entity.transform.position, weapon.attackRadius);

        foreach (Collider2D hit in hits)
        {
            if (hit.gameObject != _entity.gameObject)
            {
                EntityHealth entityHealth = hit.gameObject.GetComponent<EntityHealth>();
                if (entityHealth)
                    entityHealth.OnHealthChange(weapon.damage);
            }
        }
    }


    IEnumerator<WaitForSeconds> StartWeaponCalldown()
    {
        _isOnCalldown = true;

        GetComponentInChildren<SpriteRenderer>().color = Color.yellow;

        yield return new WaitForSeconds(_heldWeapon.attackCalldown);

        GetComponentInChildren<SpriteRenderer>().color = Color.white;

        _isOnCalldown = false;
    }


    private void OnDrawGizmos()
    {
        if (_heldWeapon == null) return;

        Gizmos.DrawWireSphere(transform.position, ((MeleeWeaponItemSO)_heldWeapon).attackRadius);
    }
}
