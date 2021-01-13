using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Initial state of Building beofere ones completion.
/// </summary>
[RequireComponent(typeof(ConstructionBehaviour))]
public class ConstructionBlueprint : MonoBehaviour
{
    private ConstructionBehaviour _construction;
    private Dictionary<ItemSO, int> _itemsLeft;


    private void Awake()
    {
        _construction = GetComponent<ConstructionBehaviour>();
        // Initiate blueprint
        _itemsLeft = _construction.type.GetRequiredResources();
        _construction.enabled = false;
    }


    public void DepositItems(Dictionary<ItemSO, int> depositedItems)
    {
        print("item deposit started");

        if (!_construction)
            _construction = GetComponent<ConstructionBehaviour>();

        if (_itemsLeft == null)
            _itemsLeft = _construction.type.GetRequiredResources();

        List<ItemSO> itemsToRemove = new List<ItemSO>();
        ItemSO[] neededItems = _itemsLeft.Keys.ToArray();

        foreach (ItemSO depositedItem in depositedItems.Keys)
        {
            foreach (ItemSO requiredItem in neededItems)
            {
                // If Items match
                if (depositedItem.Compare(requiredItem))
                {
                    // Substract amount of deposited item from needed amount
                    _itemsLeft[requiredItem] -= depositedItems[depositedItem];

                    // Remove item from needed items if it's required amount is less that zero
                    if (_itemsLeft[requiredItem] <= 0)
                        itemsToRemove.Add(requiredItem);
                }
            }
        }

        // Remove Items that should be removed
        foreach (ItemSO itemToRemove in itemsToRemove)
            _itemsLeft.Remove(itemToRemove);

        print(_itemsLeft.Count);

        // Call OnConstructionComplete if no items are left
        if (_itemsLeft.Count == 0)
            OnConstructionComplete();
    }


    private void OnConstructionComplete()
    {
        print("construction completed");
        _construction.enabled = true;
    }
}
