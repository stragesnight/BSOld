using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

/* Class that chooses which tiles to draw depending on their parameters and noise maps */
public class MapTileGenerator : MonoBehaviour
{
    [SerializeField] private RuleTile defaultTile;
    private TilemapDrawer tilemapDrawer;

    private HashSet<RuleTile> tileDB;

    // Maps
    private float[,] heightMap;
    private float[,] temperatureMap;
    private float[,] fertilityMap;

    // Map Dictionary
    private Dictionary<Vector3Int, TileBase> natureMap;

    // Zone and Biomes arrays
    private ElevationZone[] elevationZones;
    private TemperatureBiome[] temperatureBiomes;
    private FertilityZone[] fertilityZones;


    // Algorithm initialization
    public Dictionary<Vector3Int, TileBase> Initialize()
    {
        tilemapDrawer = GetComponent<TilemapDrawer>();

        // Map Dictionary initialization
        natureMap = new Dictionary<Vector3Int, TileBase>();

        // Load Rule Tiles from Resource folder and Initializing RuleTile DataBase HashSet
        tileDB = new HashSet<RuleTile>(Resources.LoadAll<RuleTile>("Tiles/MapZoneRuleTiles"));

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

        // Update natureMap of a mapData
        tilemapDrawer.SetNatureTilemap(natureMap);

        // Return Map Dictionary
        return natureMap;
    }


    // Looping through every slot in map, choosing proper tile and adding value to dictionary
    private void FillNatureMap()
    {
        for (int x = 0; x < MapData.Instance.GetMapWidth(); x++)
        {
            for (int y = 0; y < MapData.Instance.GetMapHeight(); y++)
            {
                Vector3Int currSlot = new Vector3Int(x, y, 0);
                TileBase currTile = ChooseValidTile(currSlot);

                // Adding entry to dictionary
                natureMap.Add(currSlot, currTile);
            }
        }
    }


    // Choosing valid tile depending on it's properties and map information
    private RuleTile ChooseValidTile(Vector3Int pos)
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