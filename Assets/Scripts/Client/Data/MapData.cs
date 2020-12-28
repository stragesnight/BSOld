using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// Scriptable Object class responsible for trasmitting map data between project components
/// </summary>
public class MapData : ScriptableObject
{
    // mapWidth
    [SerializeField] private int mapWidth;
    public void SetMapWidth(int value) { mapWidth = value; }
    public int GetMapWidth() { return mapWidth; }

    // mapHeight
    [SerializeField] private int mapHeight;
    public void SetMapHeight(int value) { mapHeight = value; }
    public int GetMapHeight() { return mapHeight; }

    // natureMap
    [SerializeField] private Dictionary<Vector3Int, TileBase> natureMap;
    // Set
    public void SetNatureMapEntry(Vector3Int key, TileBase value) { natureMap[key] = value; }
    public void SetNatureMap(Dictionary<Vector3Int, TileBase> map) { natureMap = map; }
    // Get
    public TileBase GetNatureMapEntry(Vector3Int position) { return natureMap[position]; }
    public Dictionary<Vector3Int, TileBase> GetNatureMap() { return natureMap; }

    // resourceMap
    [SerializeField] private Dictionary<Vector3Int, TileBase> resourceMap;
    // Set
    public void SetResourceMapEntry(Vector3Int key, TileBase value) { resourceMap[key] = value; }
    public void SetResourceMap(Dictionary<Vector3Int, TileBase> map) { resourceMap = map; }
    // Get
    public TileBase GetResourceMapEntry(Vector3Int position) { return resourceMap[position]; }
    public Dictionary<Vector3Int, TileBase> GetResourceMap() { return resourceMap; }

    // buildingMap
    [SerializeField] private Dictionary<Vector3Int, TileBase> buildingMap;
    // Set
    public void SetBuildingMapEntry(Vector3Int key, TileBase value) { buildingMap[key] = value; }
    public void SetBuildingMap(Dictionary<Vector3Int, TileBase> map) { buildingMap = map; }
    // Get
    public TileBase GetBuildingMapEntry(Vector3Int position) { return buildingMap[position]; }
    public Dictionary<Vector3Int, TileBase> GetBuildingMap() { return buildingMap; }

    // heightMap
    [SerializeField] private float[,] heightMap;
    // Set
    public void SetHeightMapEntry(Vector3Int position, float value) { heightMap[position.x, position.y] = value; }
    public void SetHeightMap(float[,] map) { heightMap = map; }
    // Get
    public float GetHeightMapEntry(Vector3Int position) { return heightMap[position.x, position.y]; }
    public float[,] GetHeightMap() { return heightMap; }

    // temperatureMap
    [SerializeField] private float[,] temperatureMap;
    // Set
    public void SetTemperatureMapEntry(Vector3Int position, float value) { temperatureMap[position.x, position.y] = value; }
    public void SetTemperatureMap(float[,] map) { temperatureMap = map; }
    // Get
    public float GetTemperatureMapEntry(Vector3Int position) { return temperatureMap[position.x, position.y]; }
    public float[,] GetTemperatureMap() { return temperatureMap; }

    // fertilityMap
    [SerializeField] private float[,] fertilityMap;
    // Set
    public void SetFertilityMapEntry(Vector3Int position, float value) { fertilityMap[position.x, position.y] = value; }
    public void SetFertilityMap(float[,] map) { fertilityMap = map; }
    // Get
    public float GetFertilityMap(Vector3Int position) { return fertilityMap[position.x, position.y]; }
    public float[,] GetFertilityMap() { return fertilityMap; }

    // placingAccessibilityMap
    [SerializeField] private bool[,] placingAccessibilityMap;
    // Set
    public void SetPlacingAccessibilityMapEntry(Vector3Int position, bool value) { placingAccessibilityMap[position.x, position.y] = value; }
    public void SetPlacingAccessibilityMap(bool[,] map) { placingAccessibilityMap = map; }
    // Get
    public bool GetPlacingAccessibilityMapEntry(Vector3Int position) { return placingAccessibilityMap[position.x, position.y]; }
    public bool[,] GetPlacingAccessibilityMap() { return placingAccessibilityMap; }
}
