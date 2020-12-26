using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

/* General map generation class that ties generation parts together */
public class MapGenerator : MonoBehaviour
{
    // Serialized variables
    [Header("Dependencies")]
    [SerializeField] Tilemap tilemap;
    [SerializeField] RuleTile defaultTile;

    [Header("Map generation parameters")]
    [SerializeField] int mapWidth;  //in tiles
    [SerializeField] int mapHeight;

    [Header("Editor parameters")]
    [SerializeField] public bool autoUpdate;

    // Maps
    [SerializeField] NoiseMap heightMap;
    [SerializeField] NoiseMap temperatureMap;
    [SerializeField] NoiseMap fertilityMap;

    Dictionary<Vector3Int, TileBase> mapDictionary;


    void Start()
    {
        GenerateMap();
    }


    // Main generation function
    public void GenerateMap()
    {
        // Initializing dictionary
        mapDictionary = new Dictionary<Vector3Int, TileBase>();

        // Height map generation
        heightMap.map = Noise.GenerateNoiseMap
            (
            heightMap.seed, 
            mapWidth, mapHeight, 
            heightMap.scale, 
            heightMap.octaves, 
            heightMap.persistance, 
            heightMap.lacunarity
            );

        // Temperature map generation
        temperatureMap.map = Noise.GenerateNoiseMap
            (
            temperatureMap.seed,
            mapWidth, mapHeight,
            temperatureMap.scale,
            temperatureMap.octaves,
            temperatureMap.persistance,
            temperatureMap.lacunarity
            );

        // Fertility map generation
        fertilityMap.map = Noise.GenerateNoiseMap
            (
            fertilityMap.seed,
            mapWidth, mapHeight,
            fertilityMap.scale,
            fertilityMap.octaves,
            fertilityMap.persistance,
            fertilityMap.lacunarity
            );

        //Deciding which tiles to use
        mapDictionary = MapDisplay.Initialize(defaultTile, mapWidth, mapHeight, heightMap.map, temperatureMap.map, fertilityMap.map);
        //Clearing map
        tilemap.ClearAllTiles();
        //Drawing tiles onto tilemap
        tilemap.SetTiles(mapDictionary.Keys.ToArray(), mapDictionary.Values.ToArray());
    }
}


/* NoiseMap struct holds information about parameters used in noise generation
 And float[,] map itself */
[System.Serializable]
public struct NoiseMap
{
    public float scale;
    public int octaves;
    [Range(0, 1)] public float persistance;
    public float lacunarity;

    public int seed;

    [System.NonSerialized] public float[,] map;
}