using System;
using UnityEngine;

/// <summary>
/// Entity Attack handler.
/// </summary>
[RequireComponent(typeof(EntityBehavoiur))]
public class EntityAttack : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    private EntityBehavoiur _entity;
    private MeleeWeaponItemSO _heldWeapon;

    // Actions
    public Action<int> damageAction;


    // Get required components and variables
    public void Start()
    {
        _entity = GetComponent<EntityBehavoiur>();

        _heldWeapon = _entity.entityData.GetHeldWeapon();
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
        if (_heldWeapon.GetType() == typeof(MeleeWeaponItemSO))
            PreformMeleeAttack();
    }


    private void PreformMeleeAttack()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, _heldWeapon.attackRadius);

        foreach (Collider2D hit in hits)
        {
            if (hit.gameObject != gameObject)
            {
                EntityHealth entityHealth = hit.gameObject.GetComponent<EntityHealth>();
                if (entityHealth)
                    entityHealth.OnHealthChange(_heldWeapon.damage);
            }
        }
    }


    private void OnDrawGizmos()
    {
        if (_heldWeapon != null)
            Gizmos.DrawWireSphere(transform.position, _heldWeapon.attackRadius);
    }
}
