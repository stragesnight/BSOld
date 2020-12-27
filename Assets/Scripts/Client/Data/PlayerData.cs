using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


/// <summary>
/// Static class responcible for trasmitting static data between project components
/// </summary>
public static class PlayerData
{
    // mapWidth
    static int mapWidth;
    public static void SetMapWidth(int value) { mapWidth = value; }
    public static int GetMapWidth() { return mapWidth; }

    // mapHeight
    static int mapHeight;
    public static void SetMapHeight(int value) { mapHeight = value; }
    public static int GetMapHeight() { return mapHeight; }

    // natureMap
    static Dictionary<Vector3Int, TileBase> natureMap;
    // Set
    public static void SetNatureMapEntry(Vector3Int key, TileBase value) { natureMap[key] = value; }
    public static void SetNatureMap(Dictionary<Vector3Int, TileBase> map) { natureMap = map; }
    // Get
    public static TileBase GetNatureMapEntry(Vector3Int position) { return natureMap[position]; }
    public static Dictionary<Vector3Int, TileBase> GetNatureMap() { return natureMap; }

    // resourceMap
    static Dictionary<Vector3Int, TileBase> resourceMap;
    // Set
    public static void SetResourceMapEntry(Vector3Int key, TileBase value) { resourceMap[key] = value; }
    public static void SetResourceMap(Dictionary<Vector3Int, TileBase> map) { resourceMap = map; }
    // Get
    public static TileBase GetResourceMapEntry(Vector3Int position) { return resourceMap[position]; }
    public static Dictionary<Vector3Int, TileBase> GetResourceMap() { return resourceMap; }

    // buildingMap
    static Dictionary<Vector3Int, TileBase> buildingMap;
    // Set
    public static void SetBuildingMapEntry(Vector3Int key, TileBase value) { buildingMap[key] = value; }
    public static void SetBuildingMap(Dictionary<Vector3Int, TileBase> map) { buildingMap = map; }
    // Get
    public static TileBase GetBuildingMapEntry(Vector3Int position) { return buildingMap[position]; }
    public static Dictionary<Vector3Int, TileBase> GetBuildingMap() { return buildingMap; }

    // placingAccessibilityMap
    static bool[,] placingAccessibilityMap;
    // Set
    public static void SetPlacingAccessibilityMapEntry(Vector3Int position, bool value) { placingAccessibilityMap[position.x, position.y] = value; }
    public static void SetPlacingAccessibilityMap(bool[,] map) { placingAccessibilityMap = map; }
    // Get
    public static bool GetPlacingAccessibilityMapEntry(Vector3Int position) { return placingAccessibilityMap[position.x, position.y]; }
    public static bool[,] GetPlacingAccessibilityMap() { return placingAccessibilityMap; }
}
