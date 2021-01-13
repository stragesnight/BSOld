using UnityEngine;

/// <summary>
/// Entity's Inventory Manager.
/// </summary>
[RequireComponent(typeof(EntityBehaviour))]
public abstract class EntityInventoryManager : MonoBehaviour
{
    private EntityBehaviour _entity;
    private InventorySO _inventory;


    protected virtual void Start()
    {
        _entity = GetComponent<EntityBehaviour>();
        _inventory = _entity.entityData.GetInventory();

        OnInventorySlotChanged(0);
    }


    protected virtual void OnInventorySlotChanged(int index)
    {
        // Update held item
        _entity.HeldItem = _inventory.GetSlot(index).Item;

        // Update components
        if (TryGetComponent(out EntityAttack entityAttack))
            entityAttack.enabled = _entity.HeldItem?.itemType == EItemType.Weapon;

        if (TryGetComponent(out EntityGathering entityGathering))
            entityGathering.enabled = _entity.HeldItem?.itemType == EItemType.Instrument;

        if (TryGetComponent(out EntityBuilding entityBuilding))
            entityBuilding.enabled = _entity.HeldItem?.itemType == EItemType.Resource;
    }
}
