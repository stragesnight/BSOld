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
    }


    protected virtual void OnInventorySlotChanged(int index)
    {
        // Update held item
        _entity.HeldItem = _inventory.GetSlot(index).Item;

        if (_entity.HeldItem == null)
            return;

        if (TryGetComponent(out EntityAttack entityAttack))
            entityAttack.enabled = _entity.HeldItem.itemType == EItemType.Weapon;
    }
}
