using UnityEngine;

/// <summary>
/// MapGenerator class ties generation system together 
/// </summary>
public class MapGenerator : MonoBehaviour
{
    [Header("Dependencies")]
    private MapTileGenerator mapTileGenerator;
    private ResourceMapGenerator resourceMapGenerator;

    [Header("Map generation parameters")]
    [SerializeField] private int mapWidth;    //in tiles
    [SerializeField] private int mapHeight;   //in tiles

    [Header("Editor parameters")]
    [SerializeField] public bool autoUpdate;

    // Maps
    [SerializeField] private NoiseMap heightMap;
    [SerializeField] private NoiseMap temperatureMap;
    [SerializeField] private NoiseMap fertilityMap;

    // Resources
    [SerializeField] private ResourceNoiseMap[] resourceNoiseMaps;


    private void Start()
    {
        GenerateMap();
    }

    // Get required components
    private void GetRequiredComponents()
    {
        mapTileGenerator = GetComponent<MapTileGenerator>();
        resourceMapGenerator = GetComponent<ResourceMapGenerator>();
    }


    // Main generation function
    public void GenerateMap()
    {
        GetRequiredComponents();

        // Update mapData variables
        MapData.Instance.SetMapWidth(mapWidth);
        MapData.Instance.SetMapHeight(mapHeight);

        GenerateNatureMap();

        // Initialize tile generator
        mapTileGenerator.Initialize();

        // Generate map of resources
        GenerateResourceMap();
    }


    private void GenerateNatureMap()
    {
        // Height map generation
        heightMap.map = Noise.GenerateNoiseMap
            (
            heightMap.seed,
            heightMap.scale,
            heightMap.octaves,
            heightMap.persistance,
            heightMap.lacunarity
            );

        // Temperature map generation
        temperatureMap.map = Noise.GenerateNoiseMap
            (
            temperatureMap.seed,
            temperatureMap.scale,
            temperatureMap.octaves,
            temperatureMap.persistance,
            temperatureMap.lacunarity
            );

        // Fertility map generation
        fertilityMap.map = Noise.GenerateNoiseMap
            (
            fertilityMap.seed,
            fertilityMap.scale,
            fertilityMap.octaves,
            fertilityMap.persistance,
            fertilityMap.lacunarity
            );

        // Update maps in mapData
        MapData.Instance.SetHeightMap(heightMap.map);
        MapData.Instance.SetTemperatureMap(temperatureMap.map);
        MapData.Instance.SetFertilityMap(fertilityMap.map);
    }


    private void GenerateResourceMap()
    {
        resourceMapGenerator.Initialize(resourceNoiseMaps);
    }
}


/// <summary>
/// NoiseMap struct holds information about parameters used in noise generation
///And float[,] map itself
/// </summary>
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