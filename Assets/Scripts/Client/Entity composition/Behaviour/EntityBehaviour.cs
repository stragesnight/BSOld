using UnityEngine;

/// <summary>
/// General game Entity Behaviour class.
/// </summary>
public class EntityBehaviour : MonoBehaviour
{
    [Header("Dependencies")]
    public EntityData entityData;
    public StateMachine stateMachine;
    [Header("Properties")]
    public bool canPickupItems;
    public bool dropItemsOnDeath;
    [HideInInspector] public EReaction currentReaction;


    // Subscribe to Actions
    protected virtual void OnEnable()
    {
        if (TryGetComponent(out EntityHealth entityHealth))
            entityHealth.deathAction += DropItems;
    }


    // Unsubscribe from actions
    protected virtual void OnDisable()
    {
        if (TryGetComponent(out EntityHealth entityHealth))
            entityHealth.deathAction -= DropItems;
    }


    protected virtual void Awake()
    {
        stateMachine = new StateMachine();
        stateMachine.SetState(EState.Default);

        currentReaction = entityData.GetDefaultReaction();
    }


    protected virtual void DropItems()
    {
        PickableItemDropHandler.Instance.DropItems(this, entityData.GetInventory());
    }
}
