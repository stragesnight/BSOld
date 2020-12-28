using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// Scriptable Object class responsible for trasmitting map data between project components
/// </summary>
public class MapData : ScriptableObject
{
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
    public void SetBuildingMapEntry(Vector3Int position, BuildingSO building) 
    { 
        buildingMap[position] = building; 
        TilemapDrawer.Instance.SetBuildingTilemapEntry(position, building);
        BuildingPlacer.Instance.PlaceBuilding(position, building);
    }
    public void SetBuildingMap(Dictionary<Vector3Int, BuildingSO> map) 
    { 
        buildingMap = map;
        TilemapDrawer.Instance.SetBuildingTilemap(map);
        BuildingPlacer.Instance.PlaceBuildingMap(map);
    }
    // Get
    public BuildingSO GetBuildingMapEntry(Vector3Int position) => buildingMap[position];
    public Dictionary<Vector3Int, BuildingSO> GetBuildingMap() => buildingMap;


    // resourceMap
    [SerializeField] private Dictionary<Vector3Int, TileBase> resourceMap;
    // Set
    public void SetResourceMapEntry(Vector3Int position, TileBase tile) 
    { 
        resourceMap[position] = tile; 
        TilemapDrawer.Instance.SetResourceTilemapEntry(position, tile); 
    }
    public void SetResourceMap(Dictionary<Vector3Int, TileBase> map) 
    { 
        resourceMap = map; 
        TilemapDrawer.Instance.SetResourceTilemap(map);
    }
    // Get
    public TileBase GetResourceMapEntry(Vector3Int position) => resourceMap[position];
    public Dictionary<Vector3Int, TileBase> GetResourceMap() => resourceMap;


    // natureMap
    [SerializeField] private Dictionary<Vector3Int, TileBase> natureMap;
    // Set
    public void SetNatureMapEntry(Vector3Int position, TileBase tile) 
    { 
        natureMap[position] = tile; 
        TilemapDrawer.Instance.SetNatureTilemapEntry(position, tile); 
    }
    public void SetNatureMap(Dictionary<Vector3Int, TileBase> map) 
    { 
        natureMap = map; 
        TilemapDrawer.Instance.SetNatureTilemap(map); 
    }
    // Get
    public TileBase GetNatureMapEntry(Vector3Int position) => natureMap[position];
    public Dictionary<Vector3Int, TileBase> GetNatureMap() => natureMap;

    // placingAccessibilityMap
    [SerializeField] private Dictionary<Vector3Int, bool> placingAccessibilityMap;
    // Set
    public void SetPlacingAccessibilityMapEntry(Vector3Int position, bool value) 
    { 
        placingAccessibilityMap[position] = value;
        TilemapDrawer.Instance.SetPlacingAccessibilityTilemapEntry(position, value);
    }
    public void SetPlacingAccessibilityMap(Dictionary<Vector3Int, bool> map) 
    { 
        placingAccessibilityMap = map;
        TilemapDrawer.Instance.SetPlacingAccessibilityTilemap(map);
    }
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