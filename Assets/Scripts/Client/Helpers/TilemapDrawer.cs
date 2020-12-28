using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// TilemapDrawer class is responsible for any Tilemap manipulations. use TilemapDrawer.Instance to reference TilemapDrawer from anywhere
/// </summary>
public class TilemapDrawer : MonoBehaviour
{   
    // Singleton Instance
    public static TilemapDrawer Instance;


    private void Awake()
    {
        CheckInstance();
    }


    // natureTilemap
    [SerializeField] private Tilemap natureTilemap;
    // Set
    public void SetNatureTilemapEntry(Vector3Int position, TileBase tile) => natureTilemap.SetTile(position, tile);
    public void SetNatureTilemap(Dictionary<Vector3Int, TileBase> tiles)
    {
        natureTilemap.ClearAllTiles();
        natureTilemap.SetTiles(tiles.Keys.ToArray(), tiles.Values.ToArray());
    }
    // Get
    public RuleTile GetNatureTilemapEntry(Vector3Int position) => natureTilemap.GetTile(position) as RuleTile; 
    public RuleTile[] GetNatureTilemap() => natureTilemap.GetTilesBlock(natureTilemap.cellBounds) as RuleTile[];

    // buildingTilemap
    [SerializeField] private Tilemap buildingTilemap;
    // Set
    public void SetBuildingTilemapEntry(Vector3Int position, TileBase tile) => buildingTilemap.SetTile(position, tile);
    public void SetBuildingTilemap(Dictionary<Vector3Int, TileBase> tiles)
    {
        buildingTilemap.ClearAllTiles();
        buildingTilemap.SetTiles(tiles.Keys.ToArray(), tiles.Values.ToArray());
    }
    // Get
    public RuleTile GetBuildingTilemapEntry(Vector3Int position) => buildingTilemap.GetTile(position) as RuleTile;
    public RuleTile[] GetBuildingTilemap() => buildingTilemap.GetTilesBlock(buildingTilemap.cellBounds) as RuleTile[];

    // placingAccessibilityTilemap
    [SerializeField] private Tilemap placingAccessibilityTilemap;
    // Set
    public void SetPlacingAccessibilityTilemapEntry(Vector3Int position, TileBase tile) => placingAccessibilityTilemap.SetTile(position, tile);
    public void SetPlacingAccessibilityTilemap(Dictionary<Vector3Int, TileBase> tiles)
    {
        placingAccessibilityTilemap.ClearAllTiles();
        placingAccessibilityTilemap.SetTiles(tiles.Keys.ToArray(), tiles.Values.ToArray());
    }
    // Get
    public RuleTile GetPlacingAccessibilityTilemapEntry(Vector3Int position) => placingAccessibilityTilemap.GetTile(position) as RuleTile;
    public RuleTile[] GetPlacingAccessibilityTilemap() => placingAccessibilityTilemap.GetTilesBlock(placingAccessibilityTilemap.cellBounds) as RuleTile[];


    private void CheckInstance() { if (Instance == null) Instance = this; }
}