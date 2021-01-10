using UnityEngine;

/// <summary>
/// Entity's Inventory manager based on player's input.
/// </summary>
public class EntityInputInventoryManager : EntityInventoryManager
{
    [SerializeField] private InputReader inputReader;


    private void OnEnable()
    {
        inputReader.inventorySlotAction += OnInventorySlotChanged;
    }


    private void OnDisable()
    {
        inputReader.inventorySlotAction -= OnInventorySlotChanged;
    }
}
