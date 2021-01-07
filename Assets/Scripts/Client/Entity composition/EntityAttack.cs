using System;
using UnityEngine;

/// <summary>
/// Entity Attack handler.
/// </summary>
[RequireComponent(typeof(EntityBehavoiur))]
public class EntityAttack : MonoBehaviour
{
    [SerializeField] private InputReader inputReader;

    private EntityBehavoiur entity;
    private MeleeWeaponItemSO heldWeapon;

    // Actions
    public Action<int> damageAction;


    // Get required components and variables
    public void Start()
    {
        entity = GetComponent<EntityBehavoiur>();

        heldWeapon = entity.entityData.GetHeldWeapon();
    }


    private void OnEnable()
    {
        inputReader.attackAction += OnAttack;
    }


    private void OnDisable()
    {
        inputReader.attackAction -= OnAttack;
    }


    private void OnAttack()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, heldWeapon.attackRadius);

        print(hits.Length);

        foreach (Collider2D hit in hits)
        {
            if (hit.gameObject != gameObject)
            {
                EntityHealth entityHealth = hit.gameObject.GetComponent<EntityHealth>();
                if (entityHealth)
                    entityHealth.OnHealthChange(heldWeapon.damage);
            }
        }
    }


    private void OnDrawGizmos()
    {
        if (heldWeapon != null)
            Gizmos.DrawWireSphere(transform.position, heldWeapon.attackRadius);
    }
}
