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
        // Walkable Nature Tilemap
        tilemapActions.OnSetWalkableNatureTilemapEntry += SetWalkableNatureTilemapEntry;
        tilemapActions.OnSetWalkableNatureTilemap += SetWalkableNatureTilemap;
        // Unwalkable Nature Tilemap
        tilemapActions.OnSetUnWalkableNatureTilemapEntry += SetUnWalkableNatureTilemapEntry;
        tilemapActions.OnSetUnWalkableNatureTilemap += SetUnWalkableNatureTilemap;
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
        // Walkable Nature Tilemap
        tilemapActions.OnSetWalkableNatureTilemapEntry -= SetWalkableNatureTilemapEntry;
        tilemapActions.OnSetWalkableNatureTilemap -= SetWalkableNatureTilemap;
        // Unwalkable Nature Tilemap
        tilemapActions.OnSetUnWalkableNatureTilemapEntry -= SetUnWalkableNatureTilemapEntry;
        tilemapActions.OnSetUnWalkableNatureTilemap -= SetUnWalkableNatureTilemap;
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

    // Walkable Nature Tilemap
    [SerializeField] private Tilemap walkableNatureTilemap;
    private void SetWalkableNatureTilemapEntry(Vector3Int position, MapZone mapZone)
    {
        walkableNatureTilemap.SetTile(position, mapZone.ruleTile);
    }
    private void SetWalkableNatureTilemap(Dictionary<Vector3Int, MapZone> mapZones)
    {
        walkableNatureTilemap.ClearAllTiles();
        walkableNatureTilemap.SetTiles(mapZones.Keys.ToArray(), mapZones.Values.Select(x => x.ruleTile).ToArray());
    }

    // Unwalkable Nature Tilemap
    [SerializeField] private Tilemap unWalkableNatureTilemap;
    private void SetUnWalkableNatureTilemapEntry(Vector3Int position, MapZone mapZone)
    {
        unWalkableNatureTilemap.SetTile(position, mapZone.ruleTile);
        UpdateTilemapCollider();
    }
    private void SetUnWalkableNatureTilemap(Dictionary<Vector3Int, MapZone> mapZones)
    {
        unWalkableNatureTilemap.ClearAllTiles();
        unWalkableNatureTilemap.SetTiles(mapZones.Keys.ToArray(), mapZones.Values.Select(x => x.ruleTile).ToArray());
        UpdateTilemapCollider();
    }

    // Placing Accessibility Tilemap
    [SerializeField] private Tilemap placingAccessibilityTilemap;
    private void SetPlacingAccessibilityTilemapEntry(Vector3Int position, bool value)
    {
        TileBase tile = value ? accessibilityTile : nonAccessibilityTile;
        placingAccessibilityTilemap.SetTile(position, tile);
    }
    private void SetPlacingAccessibilityTilemap(Dictionary<Vector3Int, bool> map)
    {
        placingAccessibilityTilemap.ClearAllTiles();
        placingAccessibilityTilemap.SetTiles(map.Keys.ToArray(), GetTilesFromBools(map.Values.ToArray()));
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


    // Update TilemapCollider2D and CompositeCollider to match the actual map
    private void UpdateTilemapCollider()
    {
        TilemapCollider2D tilemapCollider = unWalkableNatureTilemap.GetComponent<TilemapCollider2D>();
        tilemapCollider.ProcessTilemapChanges();
        tilemapCollider.composite.GenerateGeometry();
    }
}