using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// InventorySO Scriptable Object class is responsible for cerating and storing inventories used by entities
/// </summary>
public class InventorySO : ScriptableObject
{
    private Dictionary<Vector3Int, InventorySlot> inventorySlots;


    // Single Slot
    public void SetSlot(Vector3Int position, InventorySlot slot) { inventorySlots[position] = slot; }
    public InventorySlot GetSlot(Vector3Int position) => inventorySlots[position];

    // All Slots
    public void SetSlots(Dictionary<Vector3Int, InventorySlot> slots) { inventorySlots = slots; }
    public Dictionary<Vector3Int, InventorySlot> GetSlots() => inventorySlots;
}


/// <summary>
/// InventorySlot struct describes a slot held by inventory
/// </summary>
[System.Serializable]
public struct InventorySlot
{
    //public Item item;
    public int amount;

    public void SetAmount(int newAmount) { amount = newAmount; }
}