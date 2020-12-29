using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// TilemapHandler class is responsible for any tilemap changes.
/// </summary>
public class TilemapHandler : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private BuildingActions buildingActions;
    [SerializeField] private TilemapActions tilemapActions;
    [Header("Accessibility tiles")]
    [SerializeField] private RuleTile accessibilityTile;
    [SerializeField] private RuleTile nonAccessibilityTile;


    // Subscribe to Actions
    private void OnEnable()
    {
        // Buildings
        buildingActions.OnPlaceBuilding += SetBuildingTilemapEntry;
        buildingActions.OnPlaceBuildingMap += SetBuildingTilemap;
        // Resource Rilemap
        tilemapActions.OnSetResourceTilemapEntry += SetResourceTilemapEntry;
        tilemapActions.OnSetResourceTilemap += SetResourceTilemap;
        // Nature Tilemap
        tilemapActions.OnSetNatureTilemapEntry += SetNatureTilemapEntry;
        tilemapActions.OnSetNatureTilemap += SetNatureTilemap;
        // Placing Accessibility Tilemap
        tilemapActions.OnSetPlacingAccessibilityTilemapEntry += SetPlacingAccessibilityTilemapEntry;
        tilemapActions.OnSetPlacingAccessibilityTilemap += SetPlacingAccessibilityTilemap;
    }

    // Unsubscribe from Actions
    private void OnDisable()
    {
        // Buildings
        buildingActions.OnPlaceBuilding -= SetBuildingTilemapEntry;
        buildingActions.OnPlaceBuildingMap -= SetBuildingTilemap;
        // Resource Rilemap
        tilemapActions.OnSetResourceTilemapEntry -= SetResourceTilemapEntry;
        tilemapActions.OnSetResourceTilemap -= SetResourceTilemap;
        // Nature Tilemap
        tilemapActions.OnSetNatureTilemapEntry -= SetNatureTilemapEntry;
        tilemapActions.OnSetNatureTilemap -= SetNatureTilemap;
        // Placing Accessibility Tilemap
        tilemapActions.OnSetPlacingAccessibilityTilemapEntry -= SetPlacingAccessibilityTilemapEntry;
        tilemapActions.OnSetPlacingAccessibilityTilemap -= SetPlacingAccessibilityTilemap;
    }

    [Header("Tilemaps")]
    // Building Tilemap
    [SerializeField] private Tilemap buildingTilemap;
    private void SetBuildingTilemapEntry(Vector3Int position, BuildingSO building)
    {
        buildingTilemap.SetTile(position, building.graphics);
    }
    private void SetBuildingTilemap(Dictionary<Vector3Int, BuildingSO> buildings)
    {
        buildingTilemap.ClearAllTiles();
        buildingTilemap.SetTiles(buildings.Keys.ToArray(), buildings.Values.Select(x => x.graphics).ToArray());
    }

    // Resource Tilemap
    [SerializeField] private Tilemap resourceTilemap;
    private void SetResourceTilemapEntry(Vector3Int position, TileBase tile)
    {
        resourceTilemap.SetTile(position, tile);
    }
    private void SetResourceTilemap(Dictionary<Vector3Int, TileBase> tiles)
    {
        resourceTilemap.ClearAllTiles();
        resourceTilemap.SetTiles(tiles.Keys.ToArray(), tiles.Values.ToArray());
    }

    // Nature Tilemap
    [SerializeField] private Tilemap natureTilemap;
    private void SetNatureTilemapEntry(Vector3Int position, TileBase tile)
    {
        natureTilemap.SetTile(position, tile);
    }
    private void SetNatureTilemap(Dictionary<Vector3Int, TileBase> tiles)
    {
        natureTilemap.ClearAllTiles();
        natureTilemap.SetTiles(tiles.Keys.ToArray(), tiles.Values.ToArray());
    }

    // Placing Accessibility Tilemap
    [SerializeField] private Tilemap placingAccessibilityTilemap;
    private void SetPlacingAccessibilityTilemapEntry(Vector3Int position, bool value)
    {
        TileBase tile = value ? accessibilityTile : nonAccessibilityTile;
        placingAccessibilityTilemap.SetTile(position, tile);
    }
    private void SetPlacingAccessibilityTilemap(Dictionary<Vector3Int, bool> values)
    {
        placingAccessibilityTilemap.ClearAllTiles();

        placingAccessibilityTilemap.SetTiles(values.Keys.ToArray(), GetTilesFromBools(values.Values.ToArray()));
    }


    // Get tiles from bool values for placingAccessibilityTilemap
    private TileBase[] GetTilesFromBools(bool[] values)
    {
        TileBase[] tilesFromBools = new TileBase[values.Length];

        for (int i = 0; i < values.Length; i++)
        {
            tilesFromBools[i] = values[i] ? accessibilityTile : nonAccessibilityTile;
        }

        return tilesFromBools;
    }
}