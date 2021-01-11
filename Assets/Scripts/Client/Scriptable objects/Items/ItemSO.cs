using UnityEngine;

/// <summary>
/// Base Item abstract class that all item types will inherit from.
/// </summary>
public abstract class ItemSO : ScriptableObject
{
    [Header("General properties")]
    public EItemType itemType;
    [Header("Graphics")]
    public Sprite sprite;
    public Sprite inventoryIcon;
    [Header("Amounts")]
    public int maxInventoryAmount;
    public int minDroppedAmount;
    public int maxDroppedAmount;
    [Header("Chance")]
    [Range(0, 1)] public float dropChance;
}


public enum EItemType { Weapon, Instrument, Resource, Consumable }
