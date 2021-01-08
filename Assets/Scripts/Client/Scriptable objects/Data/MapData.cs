using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// MapData Scriptable Object class responsible for trasmitting map data between project components. Use MapData.Instance to access it from everywhere
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
    [SerializeField] private Dictionary<Vector3Int[], GameObject> _constructionMap = new Dictionary<Vector3Int[], GameObject>();
    // Set
    public void SetConstructionAtPoint(Vector3Int[] positions, GameObject construction) 
    {
        if (_constructionMap.ContainsKey(positions))
            _constructionMap[positions] = construction;
        else
            _constructionMap.Add(positions, construction);
        constructionActions.OnPlaceConstruction(positions, construction); 
    }
    public void SetConstructionMap(Dictionary<Vector3Int[], GameObject> map) 
    { 
        _constructionMap = map;
        constructionActions.OnPlaceConstructionMap(map);
    }
    // Get
    public bool GetConstructionAtPoint(Vector3Int position, out GameObject construction)
    {
        foreach (Vector3Int[] positions in _constructionMap.Keys)
        {
            if (positions.Contains(position))
                return _constructionMap.TryGetValue(positions, out construction);
        }

        construction = null;
        return false;
    }
    public Dictionary<Vector3Int[], GameObject> GetConstructionMap() => _constructionMap;

    // =========================================== RESOURCES ===========================================

    // resourceMap
    [SerializeField] private Dictionary<Vector3Int, Resource> _resourceMap = new Dictionary<Vector3Int, Resource>();
    // Set
    public void SetResourceAtPoint(Vector3Int position, Resource resource) 
    {
        if (_resourceMap.ContainsKey(position))
            _resourceMap[position] = resource;
        else
            _resourceMap.Add(position, resource);
        resourceActions.OnSetResourceAtPoint(position, resource);
    }
    public void SetResourceMap(Dictionary<Vector3Int, Resource> map) 
    {
        _resourceMap = map;
        resourceActions.OnSetResourceMap(map);
    }
    // Get
    public bool GetResourceAtPoint(Vector3Int position, out Resource resource)
    {
        return _resourceMap.TryGetValue(position, out resource);
    }
    public Dictionary<Vector3Int, Resource> GetResourceMap() => _resourceMap;

    // resourceAmounts
    [SerializeField] private Dictionary<Vector3Int, int> _resourceAmounts = new Dictionary<Vector3Int, int>();
    // Set
    public void SetResourceAmountAtPoint(Vector3Int position, int amount) 
    {
        if (_resourceAmounts.ContainsKey(position))
            _resourceAmounts[position] = amount;
        else
            _resourceAmounts.Add(position, amount);
        resourceActions.OnSetResourceAmountAtPoint(position, amount);
    }
    public void SetResourceAmounts(Dictionary<Vector3Int, int> amounts) 
    {
        _resourceAmounts = amounts;
        resourceActions.OnSetResourceAmounts(amounts);
    }
    // Get
    public bool GetResourceAmountAtPoint(Vector3Int position, out int amount)
    {
        return _resourceAmounts.TryGetValue(position, out amount);
    }
    public Dictionary<Vector3Int, int> GetResourceAmounts() => _resourceAmounts;

    // ======================================== WALKABLE NATURE ========================================

    [SerializeField] private Dictionary<Vector3Int, MapZone> _walkableNatureMap = new Dictionary<Vector3Int, MapZone>();
    // Set
    public void SetWalkableNatureAtPoint(Vector3Int position, MapZone tile) 
    { 
        if (_walkableNatureMap.ContainsKey(position))
            _walkableNatureMap[position] = tile;
        else
            _walkableNatureMap.Add(position, tile);
        tilemapActions.OnSetWalkableNatureTilemapEntry(position, tile);
    }
    public void SetWalkableNatureMap(Dictionary<Vector3Int, MapZone> map) 
    {
        _walkableNatureMap = map;
        tilemapActions.OnSetWalkableNatureTilemap(map);
    }
    // Get
    public bool GetWalkableNatureAtPoint(Vector3Int position, out MapZone mapZone)
    {
        return _walkableNatureMap.TryGetValue(position, out mapZone);
    }
    public Dictionary<Vector3Int, MapZone> GetWalkableNatureMap() => _walkableNatureMap;

    // ======================================= UNWALKABLE NATURE =======================================

    [SerializeField] private Dictionary<Vector3Int, MapZone> _unWalkableNatureMap = new Dictionary<Vector3Int, MapZone>();
    // Set
    public void SetUnWalkableNatureAtPoint(Vector3Int position, MapZone tile)
    {
        if (_unWalkableNatureMap.ContainsKey(position))
            _unWalkableNatureMap[position] = tile;
        else
            _unWalkableNatureMap.Add(position, tile);
        tilemapActions.OnSetUnWalkableNatureTilemapEntry(position, tile);
    }
    public void SetUnWalkableNatureMap(Dictionary<Vector3Int, MapZone> map)
    {
        _unWalkableNatureMap = map;
        tilemapActions.OnSetUnWalkableNatureTilemap(map);
    }
    // Get
    public bool GetUnWalkableNatureAtPoint(Vector3Int position, out MapZone mapZone)
    {
        return _unWalkableNatureMap.TryGetValue(position, out mapZone);
    }
    public Dictionary<Vector3Int, MapZone> GetUnWalkableNatureMap() => _unWalkableNatureMap;

    // ===================================== PLACING ACCESSIBILITY =====================================

    [SerializeField] private Dictionary<Vector3Int, bool> _placingAccessibilityMap = new Dictionary<Vector3Int, bool>();
    // Set
    public void SetPlacingAccessibilityMapAtPoint(Vector3Int position, bool value) 
    {
        if (_placingAccessibilityMap.ContainsKey(position))
            _placingAccessibilityMap[position] = value;
        else
            _placingAccessibilityMap.Add(position, value);
        tilemapActions.OnSetPlacingAccessibilityTilemapEntry(position, value);
    }
    public void SetPlacingAccessibilityMap(Dictionary<Vector3Int, bool> map) 
    {
        _placingAccessibilityMap = map;
        tilemapActions.OnSetPlacingAccessibilityTilemap(map);
    }
    // Get
    public bool GetPlacingAccessibilityMapAtPoint(Vector3Int position, out bool accessible)
    {
        return _placingAccessibilityMap.TryGetValue(position, out accessible);
    }
    public Dictionary<Vector3Int, bool> GetPlacingAccessibilityMap() => _placingAccessibilityMap;

    // ========================================== NOISEMAPS ==========================================

    // heightMap
    [SerializeField] private float[,] _heightMap = new float[0, 0];
    // Set
    public void SetHeightAtPoint(Vector3Int position, float value) { _heightMap[position.x, position.y] = value; }
    public void SetHeightMap(float[,] map) { _heightMap = map; }
    // Get
    public float GetHeightMapAtPoint(Vector3Int position) => _heightMap[position.x, position.y];
    public float[,] GetHeightMap() => _heightMap;


    // temperatureMap
    [SerializeField] private float[,] _temperatureMap = new float[0, 0];
    // Set
    public void SetTemperatureAtPoint(Vector3Int position, float value) { _temperatureMap[position.x, position.y] = value; }
    public void SetTemperatureMap(float[,] map) { _temperatureMap = map; }
    // Get
    public float GetTemperatureAtPoint(Vector3Int position) => _temperatureMap[position.x, position.y];
    public float[,] GetTemperatureMap() => _temperatureMap;


    // fertilityMap
    [SerializeField] private float[,] _fertilityMap = new float[0, 0];
    // Set
    public void SetFertilityAtPoint(Vector3Int position, float value) { _fertilityMap[position.x, position.y] = value; }
    public void SetFertilityMap(float[,] map) { _fertilityMap = map; }
    // Get
    public float GetFertilityAtPoint(Vector3Int position) => _fertilityMap[position.x, position.y];
    public float[,] GetFertilityMap() => _fertilityMap;
}