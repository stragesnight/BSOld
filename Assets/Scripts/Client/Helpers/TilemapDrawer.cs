using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// TilemapDrawer class is responsible for any Tilemap manipulations. use TilemapDrawer.Instance to reference TilemapDrawer from everywhere
/// </summary>
public class TilemapDrawer : MonoBehaviour
{
    [SerializeField] private RuleTile accessibilityTile;
    [SerializeField] private RuleTile nonAccessibilityTile;
    private BuildingPlacer buildingPlacer;

    // Actions

    // Building
    public Action<Vector3Int, BuildingSO> OnSetBuildingTilemapEntry;
    public Action<Dictionary<Vector3Int, BuildingSO>> OnSetBuildingTilemap;
    // Resource
    public Action<Vector3Int, TileBase> OnSetResourceTilemapEntry;
    public Action<Dictionary<Vector3Int, TileBase>> OnSetResourceTilemap;
    // Nature
    public Action<Vector3Int, TileBase> OnSetNatureTilemapEntry;
    public Action<Dictionary<Vector3Int, TileBase>> OnSetNatureTilemap;
    // Placing accessibility
    //...


    private void OnEnable()
    {
        buildingPlacer = GetComponent<BuildingPlacer>();

        buildingPlacer.OnPlaceBuilding += SetBuildingTilemapEntry;
        buildingPlacer.OnPlaceBuildingMap += SetBuildingTilemap;
    }


    // buildingTilemap
    [SerializeField] private Tilemap buildingTilemap;
    private void SetBuildingTilemapEntry(Vector3Int position, BuildingSO building) 
    { 
        buildingTilemap.SetTile(position, building.graphics);
        OnSetBuildingTilemapEntry?.Invoke(position, building);
    }
    private void SetBuildingTilemap(Dictionary<Vector3Int, BuildingSO> buildings)
    {
        buildingTilemap.ClearAllTiles();
        buildingTilemap.SetTiles(buildings.Keys.ToArray(), buildings.Values.Select(x => x.graphics).ToArray());
        OnSetBuildingTilemap?.Invoke(buildings);
    }

    // resourceTilemap
    [SerializeField] private Tilemap resourceTilemap;
    public void SetResourceTilemapEntry(Vector3Int position, TileBase tile) 
    { 
        resourceTilemap.SetTile(position, tile);
        OnSetResourceTilemapEntry?.Invoke(position, tile);
    }
    public void SetResourceTilemap(Dictionary<Vector3Int, TileBase> tiles)
    {
        resourceTilemap.ClearAllTiles();
        resourceTilemap.SetTiles(tiles.Keys.ToArray(), tiles.Values.ToArray());
        OnSetResourceTilemap?.Invoke(tiles);
    }

    // natureTilemap
    [SerializeField] private Tilemap natureTilemap;
    public void SetNatureTilemapEntry(Vector3Int position, TileBase tile) 
    { 
        natureTilemap.SetTile(position, tile);
        OnSetNatureTilemapEntry?.Invoke(position, tile);
    }
    public void SetNatureTilemap(Dictionary<Vector3Int, TileBase> tiles)
    {
        natureTilemap.ClearAllTiles();
        natureTilemap.SetTiles(tiles.Keys.ToArray(), tiles.Values.ToArray());
        OnSetNatureTilemap?.Invoke(tiles);
    }

    // placingAccessibilityTilemap
    [SerializeField] private Tilemap placingAccessibilityTilemap;
    public void SetPlacingAccessibilityTilemapEntry(Vector3Int position, bool value) 
    {
        TileBase tile = value ? accessibilityTile : nonAccessibilityTile;
        placingAccessibilityTilemap.SetTile(position, tile);
    }
    public void SetPlacingAccessibilityTilemap(Dictionary<Vector3Int, bool> values)
    {
        // IMPLEMENT
        //placingAccessibilityTilemap.ClearAllTiles();
        //placingAccessibilityTilemap.SetTiles(tiles.Keys.ToArray(), tiles.Values.ToArray());
    }
}