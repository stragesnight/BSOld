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
    [SerializeField] private ConstructionActions constructionActions;
    [SerializeField] private ResourceActions resourceActions;
    [SerializeField] private TilemapActions tilemapActions;
    [Header("Accessibility tiles")]
    [SerializeField] private RuleTile accessibilityTile;
    [SerializeField] private RuleTile nonAccessibilityTile;


    // Subscribe to Actions
    private void OnEnable()
    {
        // Buildings
        constructionActions.OnPlaceConstruction += SetConstructionTilemapEntry;
        constructionActions.OnPlaceBuildingMap += SetConstructionTilemap;
        // Resource Rilemap
        resourceActions.OnSetResourceAtPoint += SetResourceTilemapEntry;
        resourceActions.OnSetResourceMap += SetResourceTilemap;
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
        constructionActions.OnPlaceConstruction -= SetConstructionTilemapEntry;
        constructionActions.OnPlaceBuildingMap -= SetConstructionTilemap;
        // Resource Rilemap
        resourceActions.OnSetResourceAtPoint -= SetResourceTilemapEntry;
        resourceActions.OnSetResourceMap -= SetResourceTilemap;
        // Nature Tilemap
        tilemapActions.OnSetNatureTilemapEntry -= SetNatureTilemapEntry;
        tilemapActions.OnSetNatureTilemap -= SetNatureTilemap;
        // Placing Accessibility Tilemap
        tilemapActions.OnSetPlacingAccessibilityTilemapEntry -= SetPlacingAccessibilityTilemapEntry;
        tilemapActions.OnSetPlacingAccessibilityTilemap -= SetPlacingAccessibilityTilemap;
    }

    [Header("Tilemaps")]
    // Construction Tilemap
    [SerializeField] private Tilemap constructionTilemap;
    private void SetConstructionTilemapEntry(Vector3Int position, ConstructionSO construction)
    {
        constructionTilemap.SetTile(position, construction.ruleTile);
    }
    private void SetConstructionTilemap(Dictionary<Vector3Int, ConstructionSO> map)
    {
        constructionTilemap.ClearAllTiles();
        constructionTilemap.SetTiles(map.Keys.ToArray(), map.Values.Select(x => x.ruleTile).ToArray());
    }

    // Resource Tilemap
    [SerializeField] private Tilemap resourceTilemap;
    private void SetResourceTilemapEntry(Vector3Int position, Resource resource)
    {
        resourceTilemap.SetTile(position, resource.ruleTile);
    }
    private void SetResourceTilemap(Dictionary<Vector3Int, Resource> resources)
    {
        resourceTilemap.ClearAllTiles();
        resourceTilemap.SetTiles(resources.Keys.ToArray(), resources.Values.Select(x => x.ruleTile).ToArray());
    }

    // Nature Tilemap
    [SerializeField] private Tilemap natureTilemap;
    private void SetNatureTilemapEntry(Vector3Int position, MapZone mapZone)
    {
        natureTilemap.SetTile(position, mapZone.ruleTile);
    }
    private void SetNatureTilemap(Dictionary<Vector3Int, MapZone> mapZones)
    {
        natureTilemap.ClearAllTiles();
        natureTilemap.SetTiles(mapZones.Keys.ToArray(), mapZones.Values.Select(x => x.ruleTile).ToArray());
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