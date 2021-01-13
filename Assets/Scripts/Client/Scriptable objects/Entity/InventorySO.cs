using System;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// InventorySO Scriptable Object class is responsible for cerating and storing inventories used by entities
/// </summary>
public class InventorySO : ScriptableObject
{
    [SerializeField] private InventorySlot[] _inventorySlots = new InventorySlot[10];


    // Single Slot
    public void AddSlot(InventorySlot newSlot)
    {
        // For each slot in inventory
        for (int i = 0; i < _inventorySlots.Length; i++)
        {
            // If current slot has the same item as needed to add
            if (_inventorySlots[i].Compare(newSlot))
            {
                // Add to item amount and check for overhead
                if (!_inventorySlots[i].AddAmount(newSlot, out newSlot))
                    // Return if no overhead was found
                    return;
            }
        }

        // If there is free slot in inventory
        if (GetFreeSlot(out int index))
            // Add it
            _inventorySlots[index] = newSlot;
    }


    public void RemoveSlot(int index)
    {
        _inventorySlots[index].Item = null;
        _inventorySlots[index].Amount = 0;
    }


    public void DepositItems(Dictionary<ItemSO, int> requiredItems, out Dictionary<ItemSO, int> depositedItems)
    {
        depositedItems = new Dictionary<ItemSO, int>();

        // For each inventory slot
        foreach (InventorySlot slot in _inventorySlots)
        {
            // For each needed item
            foreach (ItemSO neededItem in requiredItems.Keys)
            {
                // If items are matching
                if (neededItem.Compare(slot.Item))
                {
                    int inventorySlotIndex = Array.IndexOf(_inventorySlots, slot);
                    // Remove slot from inventory if it's amount is below zero
                    if (slot.SubtractAmount(requiredItems[neededItem], out int subtractedAmount))
                        RemoveSlot(inventorySlotIndex);
                    // Else apply inventory slot
                    else
                        _inventorySlots[inventorySlotIndex] = slot;

                    // Add item do depositedItems if subtracted amount is not zero
                    if (subtractedAmount > 0)
                        depositedItems.Add(neededItem, subtractedAmount);
                }
            }
        }
    }


    public InventorySlot GetSlot(int index) => _inventorySlots[index];

    // All Slots
    public void SetSlots(InventorySlot[] slots) { _inventorySlots = slots; }
    public InventorySlot[] GetSlots() => _inventorySlots;


    // Try to get free inventory slot
    private bool GetFreeSlot(out int index)
    {
        // Iterate for each inventory slot
        for (int i = 0; i < _inventorySlots.Length; i++)
        {
            // Return true and index if current slot is free
            if (_inventorySlots[i].Item == null)
            {
                index = i;
                return true;
            }
        }

        // Set free slot index to 0
        index = 0;
        // Return false if no free slots were found
        return index != 9;
    }
}


/// <summary>
/// InventorySlot struct describes a slot held by inventory
/// </summary>
[System.Serializable]
public struct InventorySlot
{
    public ItemSO Item;
    public int Amount;
    public bool DropOnDeath;

    public InventorySlot(ItemSO item, int amount, bool dropOnDeath = false)
    {
        Item = item;
        Amount = amount;
        DropOnDeath = dropOnDeath;
    }

    public void SetAmount(int newAmount) { Amount = newAmount; }
    public bool AddAmount(InventorySlot addedSlot, out InventorySlot overhead)
    {
        Amount += addedSlot.Amount;
        if (Amount > Item.maxInventoryAmount)
        {
            int deltaAmount = Amount - Item.maxInventoryAmount;
            Amount = Item.maxInventoryAmount;
            addedSlot.Amount = deltaAmount;
            overhead = addedSlot;
            return true;
        }
        overhead = this;
        return false;
    }
    public bool SubtractAmount(int amount, out int subtractedAmount)
    {
        subtractedAmount = Amount;
        // Substract amount
        Amount -= amount;
        // If amount is <= 0 return true (should remove slot)
        if (Amount <= 1) return true;
        // Otherwise return false
        else
        {
            subtractedAmount = amount;
            return false;
        }
    }
    public bool Compare(InventorySlot other) { return Item == other.Item; }
}
