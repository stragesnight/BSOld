using System;
using UnityEngine;

/// <summary>
/// Entity Health handler.
/// </summary>
[RequireComponent(typeof(EntityBehaviour))]
public class EntityHealth : MonoBehaviour
{
    private EntityBehaviour _entity;
    private StateMachine _stateMachine;

    [NonSerialized] public int healthPoints;

    // Actions
    public Action<int> damageAction;
    public Action<int> healAction;
    public Action deathAction;


    // Get required components and variables
    public void Start()
    {
        _entity = GetComponent<EntityBehaviour>();
        _stateMachine = _entity.stateMachine;

        healthPoints = _entity.entityData.GetMaxHealthPoints();
    }


    // Call whenever Entity's health must change
    public void OnHealthChange(int amount)
    {
        healthPoints -= amount;

        if (amount >= 0)
            damageAction?.Invoke(amount);
        else
            healAction?.Invoke(amount);

        if (healthPoints <= 0)
            OnDeath();

        StartCoroutine(StartIFrames());
    }


    System.Collections.Generic.IEnumerator<WaitForSeconds> StartIFrames()
    {
        _stateMachine.SetState(EState.Shocked);
        GetComponentInChildren<SpriteRenderer>().color = Color.red;

        yield return new WaitForSeconds(0.3f);

        _stateMachine.SetState(EState.Default);
        GetComponentInChildren<SpriteRenderer>().color = Color.white;
    }


    // Called when Entity dies
    private void OnDeath()
    {
        deathAction?.Invoke();
        Destroy(gameObject);
    }
}
