using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

/* Class that chooses which tiles to draw depending on their parameters and noise maps
   And then assigning those tiles to Tilemap */
public static class MapDisplay
{
    static HashSet<RuleTile> tileDB;
    static RuleTile defaultTile;
    // Size data
    static int mapWidth;
    static int mapHeight;
    // Maps
    static float[,] heightMap;
    static float[,] temperatureMap;
    static float[,] fertilityMap;
    // Map Dictionary
    static Dictionary<Vector3Int, TileBase> mapDictionary;
    // Zone and Biomes arrays
    static ElevationZone[] elevationZones;
    static TemperatureBiome[] temperatureBiomes;
    static FertilityZone[] fertilityZones;


    // Algorithm initialization
    public static Dictionary<Vector3Int, TileBase> Initialize(RuleTile defaultTile_, int mapWidth_, int mapHeight_, float[,] heightMap_, float[,] temperatureMap_, float[,] fertilityMap_)
    {
        // VARIABLES INITIALIZATION

        // Map Dictionary
        mapDictionary = new Dictionary<Vector3Int, TileBase>();

        // Load Rule Tiles from Resource folder and Initializing RuleTile DataBase HashSet
        tileDB = new HashSet<RuleTile>(Resources.LoadAll<RuleTile>("Tiles"));
        // Default Tile
        defaultTile = defaultTile_;
        // Size data
        mapWidth = mapWidth_;
        mapHeight = mapHeight_;
        // Maps
        heightMap = heightMap_;
        temperatureMap = temperatureMap_;
        fertilityMap = fertilityMap_;

        // Fill Arrays
        elevationZones = MapZones.GetValues<ElevationZone>();
        temperatureBiomes = MapZones.GetValues<TemperatureBiome>();
        fertilityZones = MapZones.GetValues<FertilityZone>();

        // Fill dictionary
        FillDictionary();

        // Return Map Dictionary
        return mapDictionary;
    }


    // Looping through every slot in map, choosing proper tile and adding value to dictionary
    static void FillDictionary()
    {
        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                Vector3Int currSlot = new Vector3Int(x, y, 0);
                TileBase currTile = ChooseValidTile(currSlot);

                // Adding entry to dictionary
                mapDictionary.Add(currSlot, currTile);
            }
        }
    }


    // Choosing valid tile depending on it's properties and map information
    static RuleTile ChooseValidTile(Vector3Int pos)
    {
        // Looping through every tile in DataBase
        foreach (RuleTile tile in tileDB)
        {
            // ADD ENTRY TO NEW BIOME/ZONE
            // Check Elevation Zone
            if (((int)tile.elevationZone == GetCurrentMapEnumValue<ElevationZone>(heightMap[pos.x, pos.y])
                || !tile.isRestrictedByElevation)
                // Check Temperature Zone
                && ((int)tile.temperatureBiome == GetCurrentMapEnumValue<TemperatureBiome>(temperatureMap[pos.x, pos.y])
                || !tile.isRestrictedByTemperature)
                // Check Fertility Zone
                && ((int)tile.fertilityZone == GetCurrentMapEnumValue<FertilityZone>(fertilityMap[pos.x, pos.y])
                || !tile.isRestrictedByFertility))

                // Return current Tile if it meets all conditions
                return tile;
        }

        // Return default if noone of avilable tiles are valid
        return defaultTile;
    }


    //Get current integer value of type T (Elevation Zone, Temperature Biome, etc) on current map position
    static int GetCurrentMapEnumValue<T>(float mapValue)
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