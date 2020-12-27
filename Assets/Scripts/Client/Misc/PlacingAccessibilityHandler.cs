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
    [SerializeField] Tilemap placingAccessibilityTilemap;

    // Unserialized variables

    Dictionary<Vector3Int, TileBase> natureMapDictionary;
    public bool[,] accessibilityMap;


    private void Awake()
    {
        Initialize();
        GenerateAccessibilityMap();

        PlayerData.SetPlacingAccessibilityMap(accessibilityMap);
    }


    // Get required components and initialize variables
    void Initialize()
    {
        natureMapDictionary = PlayerData.GetNatureMap();
        accessibilityMap = new bool[PlayerData.GetMapWidth(), PlayerData.GetMapHeight()];
    }


    // Generate initial accessibility map
    public void GenerateAccessibilityMap()
    {
        // Get array of positions
        Vector3Int[] mapPositions = natureMapDictionary.Keys.ToArray();

        foreach (Vector3Int position in mapPositions)
        {
            // Get current tile
            RuleTile currentTile = natureMapDictionary[position] as RuleTile;

            // Set accessibility to true if current tile is a land tile
            // Will be changed later
            accessibilityMap[position.x, position.y] = currentTile.elevationZone == ElevationZone.land;
        }
    }
}
