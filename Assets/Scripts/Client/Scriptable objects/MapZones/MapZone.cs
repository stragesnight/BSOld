using UnityEngine;

public class MapZone : ScriptableObject
{
    /// <summary>
    /// RuleTile of that Map Zone
    /// </summary>
    public RuleTile ruleTile;
    /// <summary>
    /// The Elevation Zome in which tile can appear
    /// </summary>
    public ElevationZone elevationZone;
    public bool isRestrictedByElevation;
    /// <summary>
    /// The Temperature Biome in which tile can appear
    /// </summary>
    public TemperatureBiome temperatureBiome;
    public bool isRestrictedByTemperature;
    /// <summary>
    /// The Fertility Zone in which tile can appear
    /// </summary>
    public FertilityZone fertilityZone;
    public bool isRestrictedByFertility;
}
