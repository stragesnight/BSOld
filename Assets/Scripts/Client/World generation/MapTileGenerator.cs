using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// MapTileGenerator is responsible for choosing which tiles to draw depending on map properties 
/// </summary>
public class MapTileGenerator : MonoBehaviour
{
    private HashSet<MapZone> mapZoneDB;

    // Maps
    private float[,] heightMap;
    private float[,] temperatureMap;
    private float[,] fertilityMap;

    // Map Dictionaries
    private Dictionary<Vector3Int, MapZone> walkableNatureMap;
    private Dictionary<Vector3Int, MapZone> unWalkableNatureMap;

    // Zone and Biomes arrays
    private ElevationZone[] elevationZones;
    private TemperatureBiome[] temperatureBiomes;
    private FertilityZone[] fertilityZones;


    // Algorithm initialization
    public void Initialize()
    {
        // Map Dictionary initialization
        walkableNatureMap = new Dictionary<Vector3Int, MapZone>();
        unWalkableNatureMap = new Dictionary<Vector3Int, MapZone>();

        // Load Rule Tiles from Resource folder and Initializing RuleTile DataBase HashSet
        mapZoneDB = new HashSet<MapZone>(Resources.LoadAll<MapZone>("Map Zones"));

        // Maps initialization
        heightMap = MapData.Instance.GetHeightMap();
        temperatureMap = MapData.Instance.GetTemperatureMap();
        fertilityMap = MapData.Instance.GetFertilityMap();

        // Fill Arrays
        elevationZones = MapZones.GetValues<ElevationZone>();
        temperatureBiomes = MapZones.GetValues<TemperatureBiome>();
        fertilityZones = MapZones.GetValues<FertilityZone>();

        // Fill dictionary
        FillNatureMap();

        // Update natureMaps of a mapData
        MapData.Instance.SetWalkableNatureMap(walkableNatureMap);
        MapData.Instance.SetUnWalkableNatureMap(unWalkableNatureMap);
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
                        walkableNatureMap.Add(currSlot, mapZone);
                    else
                        unWalkableNatureMap.Add(currSlot, mapZone);
                }
            }
        }
    }


    // Choosing valid tile depending on it's properties and map information
    private bool ChooseValidMapZone(Vector3Int pos, out MapZone validMapZone, out bool isWalkable)
    {
        // Looping through every tile in DataBase
        foreach (MapZone mapZone in mapZoneDB)
        {
            // ADD ENTRY TO NEW BIOME/ZONE
            // Check Elevation Zone
            if (((int)mapZone.elevationZone == GetCurrentMapEnumValue<ElevationZone>(heightMap[pos.x, pos.y])
                || !mapZone.isRestrictedByElevation)
                // Check Temperature Zone
                && ((int)mapZone.temperatureBiome == GetCurrentMapEnumValue<TemperatureBiome>(temperatureMap[pos.x, pos.y])
                || !mapZone.isRestrictedByTemperature)
                // Check Fertility Zone
                && ((int)mapZone.fertilityZone == GetCurrentMapEnumValue<FertilityZone>(fertilityMap[pos.x, pos.y])
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
            foreach (ElevationZone elevationZone in elevationZones)
            {
                if (mapValue <= (int)elevationZone / 100f)
                    return (int)elevationZone;
            }
        }
        // Temperature Zone
        else if (typeof(T) == typeof(TemperatureBiome))
        {
            foreach (TemperatureBiome temperatureBiome in temperatureBiomes)
            {
                if (mapValue <= (int)temperatureBiome / 100f)
                    return (int)temperatureBiome;
            }

        }
        // Fertility Zone
        else if (typeof(T) == typeof(FertilityZone))
        {
            foreach (FertilityZone fertilityZone in fertilityZones)
            {
                if (mapValue <= (int)fertilityZone / 100f)
                    return (int)fertilityZone;
            }
        }
        return 0;
    }
}