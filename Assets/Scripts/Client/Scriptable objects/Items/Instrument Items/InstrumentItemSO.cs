using UnityEngine;

/// <summary>
/// Abstract class describing Instruments.
/// </summary>
public class InstrumentItemSO : ItemSO
{
    [Header("Type-specific properties")]
    public EInstrumentType instrumentType;
    public float gatheringTime;
    public int gatheringRadius;
}


public enum EInstrumentType { Axe, Pickaxe }
