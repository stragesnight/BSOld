using UnityEngine;

/// <summary>
/// General Resource Scriptable Object class that desctibes map resources.
/// </summary>
public class ResourceItem : ItemSO
{
    [Header("Rule Tile")]
    public RuleTile ruleTile;
    [Header("Map amounts")]
    public int minMapAmount;
    public int maxMapAmount;
}