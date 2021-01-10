using UnityEngine;

/// <summary>
/// Generates a PickableItem instance. Use PickableItemDropper.Instance to acces it from everywhere.
/// </summary>
public class PickableItemDropHandler : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;


    // Singleton Instance
    public static PickableItemDropHandler Instance;
    private void Awake() { if (Instance == null) Instance = this; }


    public void DropItems(EntityBehaviour entity, InventorySO inventory)
    {
        // Return if Entity cannot drop items on death
        if (!entity.dropItemsOnDeath) return;

        // For each Inventory slot in Entity
        foreach (InventorySlot slot in inventory.GetSlots())
        {
            // If there is Item in a slot
            if (slot.Item != null)
                // If RNG God satisfies Item drop chance
                if (Random.value < slot.Item.dropChance)
                {
                    // Instantiate Prefab
                    GameObject newItem = Instantiate(_prefab, entity.transform.position + GetRandomOffset(), Quaternion.identity);
                    int itemAmount = Random.Range(slot.Item.minDroppedAmount, slot.Item.maxDroppedAmount + 1);
                    // And Initialize Pickable Item behaviour
                    newItem.GetComponent<PickableItem>().Initialize(slot.Item, itemAmount, slot.DropOnDeath);
                }
        }
    }


    private Vector3 GetRandomOffset() => new Vector3(Random.value, Random.value, 0);
}
