using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// Scriptable Object class responsible for trasmitting map data between project components. Use MapData.Instance to access it from everywhere
/// </summary>
public class MapData : ScriptableObject
{
    [System.NonSerialized] public ConstructionActions constructionActions;
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

    // constructionMap
    [SerializeField] private Dictionary<Vector3Int, ConstructionSO> constructionMap = new Dictionary<Vector3Int, ConstructionSO>();
    // Set
    public void SetConstructionAtPoint(Vector3Int position, ConstructionSO construction) 
    { 
        if (constructionMap.ContainsKey(position))
            constructionMap[position] = construction;
        else
            constructionMap.Add(position, construction);
        constructionActions.PlaceBuilding(position, construction); 
    }
    public void SetConstructionMap(Dictionary<Vector3Int, ConstructionSO> map) 
    { 
        constructionMap = map;
        constructionActions.PlaceBuildingMap(map);
    }
    // Get
    public bool GetConstructionAtPoint(Vector3Int position, out ConstructionSO construction)
    {
        return constructionMap.TryGetValue(position, out construction);
    }
    public Dictionary<Vector3Int, ConstructionSO> GetConstructionMap() => constructionMap;

    // =========================================== RESOURCES ===========================================

    // resourceMap
    [SerializeField] private Dictionary<Vector3Int, Resource> resourceMap = new Dictionary<Vector3Int, Resource>();
    // Set
    public void SetResourceAtPoint(Vector3Int position, Resource resource) 
    {
        if (resourceMap.ContainsKey(position))
            resourceMap[position] = resource;
        else
            resourceMap.Add(position, resource);
        resourceActions.SetResourceAtPoint(position, resource);
    }
    public void SetResourceMap(Dictionary<Vector3Int, Resource> map) 
    {
        resourceMap = map;
        resourceActions.SetResourceMap(map);
    }
    // Get
    public bool GetResourceAtPoint(Vector3Int position, out Resource resource)
    {
        return resourceMap.TryGetValue(position, out resource);
    }
    public Dictionary<Vector3Int, Resource> GetResourceMap() => resourceMap;

    // resourceAmounts
    [SerializeField] private Dictionary<Vector3Int, int> resourceAmounts = new Dictionary<Vector3Int, int>();
    // Set
    public void SetResourceAmountAtPoint(Vector3Int position, int amount) 
    {
        if (resourceAmounts.ContainsKey(position))
            resourceAmounts[position] = amount;
        else
            resourceAmounts.Add(position, amount);
        resourceActions.SetResourceAmountAtPoint(position, amount);
    }
    public void SetResourceAmounts(Dictionary<Vector3Int, int> amounts) 
    {
        resourceAmounts = amounts;
        resourceActions.SetResourceAmounts(amounts);
    }
    // Get
    public bool GetResourceAmountAtPoint(Vector3Int position, out int amount)
    {
        return resourceAmounts.TryGetValue(position, out amount);
    }
    public Dictionary<Vector3Int, int> GetResourceAmounts() => resourceAmounts;

    // =========================================== NATURE ===========================================

    // natureMap
    [SerializeField] private Dictionary<Vector3Int, MapZone> natureMap = new Dictionary<Vector3Int, MapZone>();
    // Set
    public void SetNatureAtPoint(Vector3Int position, MapZone tile) 
    { 
        if (natureMap.ContainsKey(position))
            natureMap[position] = tile;
        else
            natureMap.Add(position, tile);
        tilemapActions.SetNatureTilemapEntry(position, tile);
    }
    public void SetNatureMap(Dictionary<Vector3Int, MapZone> map) 
    {
        natureMap = map;
        tilemapActions.SetNatureTilemap(map);
    }
    // Get
    public bool GetNatureAtPoint(Vector3Int position, out MapZone mapZone)
    {
        return natureMap.TryGetValue(position, out mapZone);
    }
    public Dictionary<Vector3Int, MapZone> GetNatureMap() => natureMap;

    // placingAccessibilityMap
    [SerializeField] private Dictionary<Vector3Int, bool> placingAccessibilityMap = new Dictionary<Vector3Int, bool>();
    // Set
    public void SetPlacingAccessibilityMapAtPoint(Vector3Int position, bool value) 
    {
        if (placingAccessibilityMap.ContainsKey(position))
            placingAccessibilityMap[position] = value;
        else
            placingAccessibilityMap.Add(position, value);
        tilemapActions.SetPlacingAccessibilityTilemapEntry(position, value);
    }
    public void SetPlacingAccessibilityMap(Dictionary<Vector3Int, bool> map) 
    {
        placingAccessibilityMap = map;
        tilemapActions.SetPlacingAccessibilityTilemap(map);
    }
    // Get
    public bool GetPlacingAccessibilityMapAtPoint(Vector3Int position, out bool accessible)
    {
        return placingAccessibilityMap.TryGetValue(position, out accessible);
    }
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