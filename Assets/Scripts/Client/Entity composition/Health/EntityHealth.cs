using System;
using UnityEngine;

/// <summary>
/// Entity Health handler.
/// </summary>
[RequireComponent(typeof(EntityBehavoiur))]
public class EntityHealth : MonoBehaviour
{
    private EntityBehavoiur entity;

    [NonSerialized] public int healthPoints;

    // Actions
    public Action<int> damageAction;
    public Action<int> healAction;
    public Action deathAction;


    // Get required components and variables
    public void Start()
    {
        entity = GetComponent<EntityBehavoiur>();

        healthPoints = entity.entityData.GetMaxHealthPoints();
    }


    // Call whenever Entity's health must change
    public void OnHealthChange(int amount)
    {
        print("OnHealthChange");
        healthPoints -= amount;

        if (amount >= 0)
            damageAction?.Invoke(amount);
        else
            healAction?.Invoke(amount);

        GetComponentInChildren<SpriteRenderer>().color = Color.red;

        if (healthPoints <= 0)
            OnDeath();
    }


    // Called when Entity dies
    private void OnDeath()
    {
        print("dead");
        deathAction?.Invoke();
        Destroy(gameObject);
    }
}
