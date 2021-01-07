using UnityEngine;

/// <summary>
/// Base Item abstract class that all item types will inherit from.
/// </summary>
public abstract class ItemSO : ScriptableObject
{
    public Sprite sprite;
    public Sprite inventoryIcon;
}
