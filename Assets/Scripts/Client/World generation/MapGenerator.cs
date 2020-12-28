using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/* General map generation class that ties generation parts together */
public class MapGenerator : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private MapData mapData;
    private MapTileGenerator mapTileGenerator;

    [Header("Map generation parameters")]
    [SerializeField] private int mapWidth;    //in tiles
    [SerializeField] private int mapHeight;   //in tiles

    [Header("Editor parameters")]
    [SerializeField] public bool autoUpdate;

    // Maps
    [SerializeField] private NoiseMap heightMap;
    [SerializeField] private NoiseMap temperatureMap;
    [SerializeField] private NoiseMap fertilityMap;

    private Dictionary<Vector3Int, TileBase> natureMap;


    private void Start()
    {
        GenerateMap();
    }


    // Main generation function
    public void GenerateMap()
    {
        mapTileGenerator = GetComponent<MapTileGenerator>();

        // Update mapData variables
        mapData.SetMapWidth(mapWidth);
        mapData.SetMapHeight(mapHeight);

        // Initializing dictionary
        natureMap = new Dictionary<Vector3Int, TileBase>();

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

        // Update maps in mapData
        mapData.SetHeightMap(heightMap.map);
        mapData.SetTemperatureMap(temperatureMap.map);
        mapData.SetFertilityMap(fertilityMap.map);

        // Decide which tiles to use
        natureMap = mapTileGenerator.Initialize();

        // Apply natureMap to naturre Tilemap
        TilemapDrawer.Instance.SetNatureTilemap(natureMap);
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