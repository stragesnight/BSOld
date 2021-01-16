using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// PlacingAccessibilityHandler class handles where you can and can't place structures and buildings
/// </summary>
public class PlacingAccessibilityHandler : MonoBehaviour
{
    [SerializeField] private Tilemap _placingAccessibilityTilemap;

    private Dictionary<Vector3Int, bool> _accessibilityMap;


    public void GenerateAccesibilityMap()
    {
        _accessibilityMap = new Dictionary<Vector3Int, bool>();
        // Get maps
        Dictionary<Vector3Int, MapZone> _walkableNatureMap = MapData.Instance.GetWalkableNatureMap();
        Dictionary<Vector3Int, MapZone> _unWalkableNatureMap = MapData.Instance.GetUnWalkableNatureMap();

        // Assign true for each walkable tile
        foreach (Vector3Int position in _walkableNatureMap.Keys)
            _accessibilityMap.Add(position, true);

        // Assign false for each unwalkable tile
        foreach (Vector3Int position in _unWalkableNatureMap.Keys)
            _accessibilityMap.Add(position, false);

        // Update map
        MapData.Instance.SetPlacingAccessibilityMap(_accessibilityMap);
    }
}
