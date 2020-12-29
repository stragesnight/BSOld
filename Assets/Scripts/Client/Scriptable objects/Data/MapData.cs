using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// Scriptable Object class responsible for trasmitting map data between project components. Use MapData.Instance to access it from everywhere
/// </summary>
public class MapData : ScriptableObject
{
    [System.NonSerialized] public BuildingActions buildingActions;
    [System.NonSerialized] public ResourceActions resourceActions;
    [System.NonSerialized] public TilemapActions tilemapActions;

    // Singleton Instance
    public static MapData Instance;
    public void CheckInstance() { if (Instance == null) Instance = this; }


    // ========================================= GENERAL DATA =========================================

    // mapWidth 
    [SerializeField] private int mapWidth;
    public void SetMapWidth(int value) { mapWidth = value; }
    public int GetMapWidth() => mapWidth;

    // mapHeight
    [SerializeField] private int mapHeight;
    public void SetMapHeight(int value) { mapHeight = value; }
    public int GetMapHeight() => mapHeight;


    // =========================================== BUILDINGS ===========================================

    // buildingMap
    [SerializeField] private Dictionary<Vector3Int, BuildingSO> buildingMap = new Dictionary<Vector3Int, BuildingSO>();
    // Set
    public void SetBuildingAtPoint(Vector3Int position, BuildingSO building) 
    { 
        buildingMap[position] = building; 
        buildingActions.PlaceBuilding(position, building); 
    }
    public void SetBuildingMap(Dictionary<Vector3Int, BuildingSO> map) 
    { 
        buildingMap = map;
        buildingActions.PlaceBuildingMap(map);
    }
    // Get
    public BuildingSO GetBuildingAtPoint(Vector3Int position) => buildingMap[position];
    public Dictionary<Vector3Int, BuildingSO> GetBuildingMap() => buildingMap;

    // =========================================== RESOURCES ===========================================

    // resourceMap
    [SerializeField] private Dictionary<Vector3Int, TileBase> resourceMap = new Dictionary<Vector3Int, TileBase>();
    // Set
    public void SetResourceAtPoint(Vector3Int position, TileBase tile) 
    {
        resourceMap[position] = tile;
        resourceActions.SetResourceAtPoint(position, tile);
    }
    public void SetResourceMap(Dictionary<Vector3Int, TileBase> map) 
    {
        resourceMap = map;
        resourceActions.SetResourceMap(map);
    }
    // Get
    public TileBase GetResourceAtPoint(Vector3Int position) => resourceMap[position];
    public Dictionary<Vector3Int, TileBase> GetResourceMap() => resourceMap;

    // resourceAmounts
    [SerializeField] private Dictionary<Vector3Int, int> resourceAmounts = new Dictionary<Vector3Int, int>();
    // Set
    public void SetResourceAmountAtPoint(Vector3Int position, int amount) 
    {
        resourceAmounts[position] = amount;
        resourceActions.SetResourceAmountAtPoint(position, amount);
    }
    public void SetResourceAmounts(Dictionary<Vector3Int, int> amounts) 
    {
        resourceAmounts = amounts;
        resourceActions.SetResourceAmounts(amounts);
    }
    // Get
    public int GetResourceAmountAtPoint(Vector3Int position) => resourceAmounts[position];
    public Dictionary<Vector3Int, int> GetResourceAmounts() => resourceAmounts;

    // =========================================== TILEMAPS ===========================================

    // natureMap
    [SerializeField] private Dictionary<Vector3Int, TileBase> natureMap = new Dictionary<Vector3Int, TileBase>();
    // Set
    public void SetNatureAtPoint(Vector3Int position, TileBase tile) 
    { 
        natureMap[position] = tile;
        tilemapActions.SetNatureTilemapEntry(position, tile);
    }
    public void SetNatureMap(Dictionary<Vector3Int, TileBase> map) 
    {
        natureMap = map;
        tilemapActions.SetNatureTilemap(map);
    }
    // Get
    public TileBase GetNatureAtPoint(Vector3Int position) => natureMap[position];
    public Dictionary<Vector3Int, TileBase> GetNatureMap() => natureMap;

    // placingAccessibilityMap
    [SerializeField] private Dictionary<Vector3Int, bool> placingAccessibilityMap = new Dictionary<Vector3Int, bool>();
    // Set
    public void SetPlacingAccessibilityMapAtPoint(Vector3Int position, bool value) 
    {
        placingAccessibilityMap[position] = value;
        tilemapActions.SetPlacingAccessibilityTilemapEntry(position, value);
    }
    public void SetPlacingAccessibilityMap(Dictionary<Vector3Int, bool> map) 
    {
        placingAccessibilityMap = map;
        tilemapActions.SetPlacingAccessibilityTilemap(map);
    }
    // Get
    public bool GetPlacingAccessibilityMapAtPoint(Vector3Int position) => placingAccessibilityMap[position];
    public Dictionary<Vector3Int, bool> GetPlacingAccessibilityMap() => placingAccessibilityMap;


    // ========================================== NOISEMAPS ==========================================

    // heightMap
    [SerializeField] private float[,] heightMap = new float[0, 0];
    // Set
    public void SetHeightAtPoint(Vector3Int position, float value) { heightMap[position.x, position.y] = value; }
    public void SetHeightMap(float[,] map) { heightMap = map; }
    // Get
    public float GetHeightMapAtPoint(Vector3Int position) => heightMap[position.x, position.y];
    public float[,] GetHeightMap() => heightMap;


    // temperatureMap
    [SerializeField] private float[,] temperatureMap = new float[0, 0];
    // Set
    public void SetTemperatureAtPoint(Vector3Int position, float value) { temperatureMap[position.x, position.y] = value; }
    public void SetTemperatureMap(float[,] map) { temperatureMap = map; }
    // Get
    public float GetTemperatureAtPoint(Vector3Int position) => temperatureMap[position.x, position.y];
    public float[,] GetTemperatureMap() => temperatureMap;


    // fertilityMap
    [SerializeField] private float[,] fertilityMap = new float[0, 0];
    // Set
    public void SetFertilityAtPoint(Vector3Int position, float value) { fertilityMap[position.x, position.y] = value; }
    public void SetFertilityMap(float[,] map) { fertilityMap = map; }
    // Get
    public float GetFertilityAtPoint(Vector3Int position) => fertilityMap[position.x, position.y];
    public float[,] GetFertilityMap() => fertilityMap;
}