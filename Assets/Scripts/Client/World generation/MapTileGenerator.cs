using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// MapTileGenerator is responsible for choosing which tiles to draw depending on map properties 
/// </summary>
public class MapTileGenerator : MonoBehaviour
{
    private HashSet<MapZone> _mapZoneDB;

    // Maps
    private float[,] _heightMap;
    private float[,] _temperatureMap;
    private float[,] _fertilityMap;

    // Map Dictionaries
    private Dictionary<Vector3Int, MapZone> _walkableNatureMap;
    private Dictionary<Vector3Int, MapZone> _unWalkableNatureMap;

    // Zone and Biomes arrays
    private ElevationZone[] _elevationZones;
    private TemperatureBiome[] _temperatureBiomes;
    private FertilityZone[] _fertilityZones;


    // Algorithm initialization
    public void Initialize()
    {
        // Map Dictionary initialization
        _walkableNatureMap = new Dictionary<Vector3Int, MapZone>();
        _unWalkableNatureMap = new Dictionary<Vector3Int, MapZone>();

        // Load Rule Tiles from Resource folder and Initializing RuleTile DataBase HashSet
        _mapZoneDB = new HashSet<MapZone>(Resources.LoadAll<MapZone>("Map Zones"));

        // Maps initialization
        _heightMap = MapData.Instance.GetHeightMap();
        _temperatureMap = MapData.Instance.GetTemperatureMap();
        _fertilityMap = MapData.Instance.GetFertilityMap();

        // Fill Arrays
        _elevationZones = MapZones.GetValues<ElevationZone>();
        _temperatureBiomes = MapZones.GetValues<TemperatureBiome>();
        _fertilityZones = MapZones.GetValues<FertilityZone>();

        // Fill dictionary
        FillNatureMap();

        // Update natureMaps of a mapData
        MapData.Instance.SetWalkableNatureMap(_walkableNatureMap);
        MapData.Instance.SetUnWalkableNatureMap(_unWalkableNatureMap);
    }


    // Looping through every slot in map, choosing proper tile and adding value to dictionary
    private void FillNatureMap()
    {
        for (int x = 0; x < MapData.Instance.GetMapWidth(); x++)
        {
            for (int y = 0; y < MapData.Instance.GetMapHeight(); y++)
            {
                Vector3Int currSlot = new Vector3Int(x, y, 0);
                bool isFound = ChooseValidMapZone(currSlot, out MapZone mapZone, out bool isWalkable);

                // Adding entry to dictionary
                if (isFound)
                {
                    if (isWalkable)
                        _walkableNatureMap.Add(currSlot, mapZone);
                    else
                        _unWalkableNatureMap.Add(currSlot, mapZone);
                }
            }
        }
    }


    // Choosing valid tile depending on it's properties and map information
    private bool ChooseValidMapZone(Vector3Int pos, out MapZone validMapZone, out bool isWalkable)
    {
        // Looping through every tile in DataBase
        foreach (MapZone mapZone in _mapZoneDB)
        {
            // ADD ENTRY TO NEW BIOME/ZONE
            // Check Elevation Zone
            if (((int)mapZone.elevationZone == GetCurrentMapEnumValue<ElevationZone>(_heightMap[pos.x, pos.y])
                || !mapZone.isRestrictedByElevation)
                // Check Temperature Zone
                && ((int)mapZone.temperatureBiome == GetCurrentMapEnumValue<TemperatureBiome>(_temperatureMap[pos.x, pos.y])
                || !mapZone.isRestrictedByTemperature)
                // Check Fertility Zone
                && ((int)mapZone.fertilityZone == GetCurrentMapEnumValue<FertilityZone>(_fertilityMap[pos.x, pos.y])
                || !mapZone.isRestrictedByFertility))
            {
                // Assing values to out variables
                validMapZone = mapZone;
                isWalkable = mapZone.isWalkable;
                // true signifies that valid tile was found
                return true;
            }
        }

        // Return false if noone of avilable tiles are valid
        validMapZone = null;
        isWalkable = false;
        return false;
    }


    //Get current integer value of type T (Elevation Zone, Temperature Biome, etc) on current map position
    private int GetCurrentMapEnumValue<T>(float mapValue)
    {
        // Elevation Zone
        if (typeof(T) == typeof(ElevationZone))
        {
            foreach (ElevationZone elevationZone in _elevationZones)
            {
                if (mapValue <= (int)elevationZone / 100f)
                    return (int)elevationZone;
            }
        }
        // Temperature Zone
        else if (typeof(T) == typeof(TemperatureBiome))
        {
            foreach (TemperatureBiome temperatureBiome in _temperatureBiomes)
            {
                if (mapValue <= (int)temperatureBiome / 100f)
                    return (int)temperatureBiome;
            }

        }
        // Fertility Zone
        else if (typeof(T) == typeof(FertilityZone))
        {
            foreach (FertilityZone fertilityZone in _fertilityZones)
            {
                if (mapValue <= (int)fertilityZone / 100f)
                    return (int)fertilityZone;
            }
        }
        return 0;
    }
}