using UnityEngine;

/// <summary>
/// MapGenerator class ties generation system together 
/// </summary>
public class MapGenerator : MonoBehaviour
{
    [Header("Dependencies")]
    private MapTileGenerator _mapTileGenerator;
    private ResourceMapGenerator _resourceMapGenerator;

    [Header("Map generation parameters")]
    [SerializeField] private int _mapWidth;    //in tiles
    [SerializeField] private int _mapHeight;   //in tiles

    [Header("Editor parameters")]
    [SerializeField] public bool autoUpdate;

    // Maps
    [SerializeField] private NoiseMap _heightMap;
    [SerializeField] private NoiseMap _temperatureMap;
    [SerializeField] private NoiseMap _fertilityMap;

    // Resources
    [SerializeField] private ResourceNoiseMap[] _resourceNoiseMaps;


    private void Start()
    {
        GenerateMap();
    }

    // Get required components
    private void GetRequiredComponents()
    {
        _mapTileGenerator = GetComponent<MapTileGenerator>();
        _resourceMapGenerator = GetComponent<ResourceMapGenerator>();
    }


    // Main generation function
    public void GenerateMap()
    {
        GetRequiredComponents();

        // Update mapData variables
        MapData.Instance.SetMapWidth(_mapWidth);
        MapData.Instance.SetMapHeight(_mapHeight);

        GenerateNoiseMaps();

        // Initialize tile generator
        _mapTileGenerator.Initialize();

        // Generate map of resources
        GenerateResourceMap();

        AstarPath.active.Scan();
    }


    private void GenerateNoiseMaps()
    {
        // Height map generation
        _heightMap.map = Noise.GenerateNoiseMap
            (
            _heightMap.seed,
            _heightMap.scale,
            _heightMap.octaves,
            _heightMap.persistance,
            _heightMap.lacunarity
            );

        // Temperature map generation
        _temperatureMap.map = Noise.GenerateNoiseMap
            (
            _temperatureMap.seed,
            _temperatureMap.scale,
            _temperatureMap.octaves,
            _temperatureMap.persistance,
            _temperatureMap.lacunarity
            );

        // Fertility map generation
        _fertilityMap.map = Noise.GenerateNoiseMap
            (
            _fertilityMap.seed,
            _fertilityMap.scale,
            _fertilityMap.octaves,
            _fertilityMap.persistance,
            _fertilityMap.lacunarity
            );

        // Update maps in mapData
        MapData.Instance.SetHeightMap(_heightMap.map);
        MapData.Instance.SetTemperatureMap(_temperatureMap.map);
        MapData.Instance.SetFertilityMap(_fertilityMap.map);
    }


    private void GenerateResourceMap()
    {
        _resourceMapGenerator.Initialize(_resourceNoiseMaps);
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
