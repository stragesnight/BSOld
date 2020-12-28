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
    [SerializeField] private Tilemap placingAccessibilityTilemap;
    [SerializeField] private MapData mapData;

    // Unserialized variables

    private Dictionary<Vector3Int, TileBase> natureMap;
    private Dictionary<Vector3Int, bool> accessibilityMap;


    private void Start()
    {
        Initialize();
        GenerateAccessibilityMap();

        mapData.SetPlacingAccessibilityMap(accessibilityMap);
    }


    // Get required components and initialize variables
    private void Initialize()
    {
        natureMap = mapData.GetNatureMap();
        accessibilityMap = new Dictionary<Vector3Int, bool>();
    }


    // Generate initial accessibility map
    public void GenerateAccessibilityMap()
    {
        // Get array of positions
        Vector3Int[] mapPositions = natureMap.Keys.ToArray();

        foreach (Vector3Int position in mapPositions)
        {
            // Get current tile
            RuleTile currentTile = natureMap[position] as RuleTile;

            // Set accessibility to true if current tile is a land tile
            // Will be changed later
            accessibilityMap.Add(position, currentTile.elevationZone == ElevationZone.land);
        }
    }
}
