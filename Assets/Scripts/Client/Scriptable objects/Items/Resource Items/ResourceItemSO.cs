using UnityEngine;

/// <summary>
/// General Resource Scriptable Object class that desctibes map resources.
/// </summary>
public class ResourceItemSO : ItemSO
{
    [Header("Type-specific properties")]
    public RuleTile ruleTile;
    [Header("Map amounts")]
    public int minMapAmount;
    public int maxMapAmount;
    [Header("Required Instrument")]
    public EInstrumentType requiredInstrumentType;
}