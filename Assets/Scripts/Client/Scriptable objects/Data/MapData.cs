using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// Scriptable Object class responsible for trasmitting map data between project components
/// </summary>
public class MapData : ScriptableObject
{
    [System.NonSerialized] public BuildingActions buildingActions;
    [System.NonSerialized] public TilemapActions tilemapActions;

    // Singleton Instance
    public static MapData Instance;
    public void CheckInstance() { if (Instance == null) Instance = this; }


    // Subscribe to Actions
    public void EnableActions()
    {
        // Building
        buildingActions.OnPlaceBuilding += SetBuildingMapEntry;
        buildingActions.OnPlaceBuildingMap += SetBuildingMap;
        // Resource
        tilemapActions.OnSetResourceTilemapEntry += SetResourceMapEntry;
        tilemapActions.OnSetResourceTilemap += SetResourceMap;
        // Nature
        tilemapActions.OnSetNatureTilemapEntry += SetNatureMapEntry;
        tilemapActions.OnSetNatureTilemap += SetNatureMap;
        // Placing Accessibility
        tilemapActions.OnSetPlacingAccessibilityTilemapEntry += SetPlacingAccessibilityMapEntry;
        tilemapActions.OnSetPlacingAccessibilityTilemap += SetPlacingAccessibilityMap;
    }

    // Unsubscribe from Actions
    public void DisableActions()
    {
        // Building
        buildingActions.OnPlaceBuilding -= SetBuildingMapEntry;
        buildingActions.OnPlaceBuildingMap -= SetBuildingMap;
        // Resource
        tilemapActions.OnSetResourceTilemapEntry -= SetResourceMapEntry;
        tilemapActions.OnSetResourceTilemap -= SetResourceMap;
        // Nature
        tilemapActions.OnSetNatureTilemapEntry -= SetNatureMapEntry;
        tilemapActions.OnSetNatureTilemap -= SetNatureMap;
        // Placing Accessibility
        tilemapActions.OnSetPlacingAccessibilityTilemapEntry -= SetPlacingAccessibilityMapEntry;
        tilemapActions.OnSetPlacingAccessibilityTilemap -= SetPlacingAccessibilityMap;
    }

    // ========================================= GENERAL DATA =========================================

    // mapWidth 
    [SerializeField] private int mapWidth;
    public void SetMapWidth(int value) { mapWidth = value; }
    public int GetMapWidth() => mapWidth;

    // mapHeight
    [SerializeField] private int mapHeight;
    public void SetMapHeight(int value) { mapHeight = value; }
    public int GetMapHeight() => mapHeight;


    // =========================================== TILEMAPS ===========================================

    // buildingMap
    [SerializeField] private Dictionary<Vector3Int, BuildingSO> buildingMap;
    // Set
    private void SetBuildingMapEntry(Vector3Int position, BuildingSO building) { buildingMap[position] = building; }
    private void SetBuildingMap(Dictionary<Vector3Int, BuildingSO> map) { buildingMap = map; }
    // Get
    public BuildingSO GetBuildingMapEntry(Vector3Int position) => buildingMap[position];
    public Dictionary<Vector3Int, BuildingSO> GetBuildingMap() => buildingMap;


    // resourceMap
    [SerializeField] private Dictionary<Vector3Int, TileBase> resourceMap;
    // Set
    private void SetResourceMapEntry(Vector3Int position, TileBase tile) { resourceMap[position] = tile; }
    private void SetResourceMap(Dictionary<Vector3Int, TileBase> map) { resourceMap = map; }
    // Get
    public TileBase GetResourceMapEntry(Vector3Int position) => resourceMap[position];
    public Dictionary<Vector3Int, TileBase> GetResourceMap() => resourceMap;


    // natureMap
    [SerializeField] private Dictionary<Vector3Int, TileBase> natureMap;
    // Set
    private void SetNatureMapEntry(Vector3Int position, TileBase tile) { natureMap[position] = tile; }
    private void SetNatureMap(Dictionary<Vector3Int, TileBase> map) { natureMap = map; }
    // Get
    public TileBase GetNatureMapEntry(Vector3Int position) => natureMap[position];
    public Dictionary<Vector3Int, TileBase> GetNatureMap() => natureMap;

    // placingAccessibilityMap
    [SerializeField] private Dictionary<Vector3Int, bool> placingAccessibilityMap;
    // Set
    private void SetPlacingAccessibilityMapEntry(Vector3Int position, bool value) { placingAccessibilityMap[position] = value; }
    private void SetPlacingAccessibilityMap(Dictionary<Vector3Int, bool> map) { placingAccessibilityMap = map; }
    // Get
    public bool GetPlacingAccessibilityMapEntry(Vector3Int position) => placingAccessibilityMap[position];
    public Dictionary<Vector3Int, bool> GetPlacingAccessibilityMap() => placingAccessibilityMap;


    // ========================================== NOISEMAPS ==========================================

    // heightMap
    [SerializeField] private float[,] heightMap;
    // Set
    public void SetHeightMapEntry(Vector3Int position, float value) { heightMap[position.x, position.y] = value; }
    public void SetHeightMap(float[,] map) { heightMap = map; }
    // Get
    public float GetHeightMapEntry(Vector3Int position) => heightMap[position.x, position.y];
    public float[,] GetHeightMap() => heightMap;


    // temperatureMap
    [SerializeField] private float[,] temperatureMap;
    // Set
    public void SetTemperatureMapEntry(Vector3Int position, float value) { temperatureMap[position.x, position.y] = value; }
    public void SetTemperatureMap(float[,] map) { temperatureMap = map; }
    // Get
    public float GetTemperatureMapEntry(Vector3Int position) => temperatureMap[position.x, position.y];
    public float[,] GetTemperatureMap() => temperatureMap;


    // fertilityMap
    [SerializeField] private float[,] fertilityMap;
    // Set
    public void SetFertilityMapEntry(Vector3Int position, float value) { fertilityMap[position.x, position.y] = value; }
    public void SetFertilityMap(float[,] map) { fertilityMap = map; }
    // Get
    public float GetFertilityMap(Vector3Int position) => fertilityMap[position.x, position.y];
    public float[,] GetFertilityMap() => fertilityMap;
}