using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// PlacingAccessibilityHandler class handles where you can and can't place structures and buildings
/// </summary>
public class PlacingAccessibilityHandler : MonoBehaviour
{
    // Serialized variables
    [SerializeField] private Tilemap _placingAccessibilityTilemap;
    [SerializeField] private MapData _mapData;

    // Unserialized variables

    private Dictionary<Vector3Int, MapZone> _natureMap;
    private Dictionary<Vector3Int, bool> _accessibilityMap;


    private void Start()
    {
        Initialize();
        GenerateAccessibilityMap();

        //mapData.SetPlacingAccessibilityMap(accessibilityMap);
    }


    // Get required components and initialize variables
    private void Initialize()
    {
        _natureMap = _mapData.GetWalkableNatureMap();
        _accessibilityMap = new Dictionary<Vector3Int, bool>();
    }


    // Generate initial accessibility map
    public void GenerateAccessibilityMap()
    {
        // Get array of positions
        Vector3Int[] mapPositions = _natureMap.Keys.ToArray();

        foreach (Vector3Int position in mapPositions)
        {
            // Set accessibility to true if current tile is a land tile
            // Will be changed later
            _accessibilityMap.Add(position, _natureMap[position].elevationZone == ElevationZone.land);
        }
    }
}
