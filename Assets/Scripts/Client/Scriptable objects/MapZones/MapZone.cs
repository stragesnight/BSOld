using UnityEngine;

public class MapZone : ScriptableObject
{
    /// <summary>
    /// RuleTile of that Map Zone
    /// </summary>
    public RuleTile ruleTile;
    /// <summary>
    /// Can Entities walk in this zone?
    /// </summary>
    public bool isWalkable;
    /// <summary>
    /// The Elevation Zome in which tile can appear
    /// </summary>
    public bool isRestrictedByElevation;
    public ElevationZone elevationZone;
    /// <summary>
    /// The Temperature Biome in which tile can appear
    /// </summary>
    public bool isRestrictedByTemperature;
    public TemperatureBiome temperatureBiome;
    /// <summary>
    /// The Fertility Zone in which tile can appear
    /// </summary>
    public bool isRestrictedByFertility;
    public FertilityZone fertilityZone;
}
