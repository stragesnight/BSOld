using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// TilemapDrawer class is responsible for any Tilemap manipulations. use TilemapDrawer.Instance to reference TilemapDrawer from everywhere
/// </summary>
public class TilemapDrawer : MonoBehaviour
{   
    // Singleton Instance
    public static TilemapDrawer Instance;

    [SerializeField] private RuleTile accessibilityTile;
    [SerializeField] private RuleTile nonAccessibilityTile;


    private void Awake()
    {
        CheckInstance();
    }

    // buildingTilemap
    [SerializeField] private Tilemap buildingTilemap;
    public void SetBuildingTilemapEntry(Vector3Int position, BuildingSO building) { buildingTilemap.SetTile(position, building.graphics); }
    public void SetBuildingTilemap(Dictionary<Vector3Int, BuildingSO> buildings)
    {
        buildingTilemap.ClearAllTiles();
        buildingTilemap.SetTiles(buildings.Keys.ToArray(), buildings.Values.Select(x => x.graphics).ToArray());
    }

    // resourceTilemap
    [SerializeField] private Tilemap resourceTilemap;
    public void SetResourceTilemapEntry(Vector3Int position, TileBase tile) { resourceTilemap.SetTile(position, tile); }
    public void SetResourceTilemap(Dictionary<Vector3Int, TileBase> tiles)
    {
        resourceTilemap.ClearAllTiles();
        resourceTilemap.SetTiles(tiles.Keys.ToArray(), tiles.Values.ToArray());
    }

    // natureTilemap
    [SerializeField] private Tilemap natureTilemap;
    public void SetNatureTilemapEntry(Vector3Int position, TileBase tile) { natureTilemap.SetTile(position, tile); }
    public void SetNatureTilemap(Dictionary<Vector3Int, TileBase> tiles)
    {
        natureTilemap.ClearAllTiles();
        natureTilemap.SetTiles(tiles.Keys.ToArray(), tiles.Values.ToArray());
    }

    // placingAccessibilityTilemap
    [SerializeField] private Tilemap placingAccessibilityTilemap;
    public void SetPlacingAccessibilityTilemapEntry(Vector3Int position, bool value) 
    { 
        placingAccessibilityTilemap.SetTile(position, value ? accessibilityTile : nonAccessibilityTile); 
    }
    public void SetPlacingAccessibilityTilemap(Dictionary<Vector3Int, bool> values)
    {
        // IMPLEMENT
        //placingAccessibilityTilemap.ClearAllTiles();
        //placingAccessibilityTilemap.SetTiles(tiles.Keys.ToArray(), tiles.Values.ToArray());
    }


    private void CheckInstance() { if (Instance == null) Instance = this; }
}