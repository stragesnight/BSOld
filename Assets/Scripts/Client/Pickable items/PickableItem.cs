using UnityEngine;

/// <summary>
/// Item pickable by Entities.
/// </summary>
[RequireComponent(typeof(Collider2D))]
public class PickableItem : MonoBehaviour
{
    [SerializeField] private InventorySlot slot;


    public void Initialize(ItemSO item, int amount, bool dropOnDeath)
    {
        slot.Item = item;
        slot.Amount = amount;
        slot.DropOnDeath = dropOnDeath;

        GetComponent<SpriteRenderer>().sprite = item.sprite;
    }


    // Add item to whatever entity collides with a trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!slot.Item) return;

        bool isEntity = collision.TryGetComponent(out EntityBehaviour entity);

        // If collision is Entity
        if (isEntity)
        {
            if (entity.canPickupItems)
                // Add slot to Entity's Inventory
                entity.entityData.GetInventory().AddSlot(slot);
        }

        Destroy(gameObject);
    }
}
