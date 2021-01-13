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
    [SerializeField] private ConstructionActions _constructionActions;
    [SerializeField] private ResourceActions _resourceActions;
    [SerializeField] private TilemapActions _tilemapActions;
    [Header("Accessibility tiles")]
    [SerializeField] private RuleTile _accessibilityTile;
    [SerializeField] private RuleTile _nonAccessibilityTile;


    // Subscribe to Actions
    private void OnEnable()
    {
        // Buildings
        _constructionActions.placeConstructionAction += SetConstructionTilemapEntry;
        _constructionActions.placeConstructionMapAction += SetConstructionTilemap;
        // Resource Rilemap
        _resourceActions.setResouceAtPointAction += SetResourceTilemapEntry;
        _resourceActions.setResourceMapAction += SetResourceTilemap;
        // Walkable Nature Tilemap
        _tilemapActions.setWalkableNatureTilemapEntryAction += SetWalkableNatureTilemapEntry;
        _tilemapActions.setWalkableNatureTilemapAction += SetWalkableNatureTilemap;
        // Unwalkable Nature Tilemap
        _tilemapActions.setUnWalkableNatureTilemapEntryAction += SetUnWalkableNatureTilemapEntry;
        _tilemapActions.setUnWalkableNatureTilemapAction += SetUnWalkableNatureTilemap;
        // Placing Accessibility Tilemap
        _tilemapActions.setPlacingAccessibilityTilemapEntryAction += SetPlacingAccessibilityTilemapEntry;
        _tilemapActions.setPlacingAccessibilityTilemapAction += SetPlacingAccessibilityTilemap;
    }

    // Unsubscribe from Actions
    private void OnDisable()
    {
        // Buildings
        _constructionActions.placeConstructionAction -= SetConstructionTilemapEntry;
        _constructionActions.placeConstructionMapAction -= SetConstructionTilemap;
        // Resource Rilemap
        _resourceActions.setResouceAtPointAction -= SetResourceTilemapEntry;
        _resourceActions.setResourceMapAction -= SetResourceTilemap;
        // Walkable Nature Tilemap
        _tilemapActions.setWalkableNatureTilemapEntryAction -= SetWalkableNatureTilemapEntry;
        _tilemapActions.setWalkableNatureTilemapAction -= SetWalkableNatureTilemap;
        // Unwalkable Nature Tilemap
        _tilemapActions.setUnWalkableNatureTilemapEntryAction -= SetUnWalkableNatureTilemapEntry;
        _tilemapActions.setUnWalkableNatureTilemapAction -= SetUnWalkableNatureTilemap;
        // Placing Accessibility Tilemap
        _tilemapActions.setPlacingAccessibilityTilemapEntryAction -= SetPlacingAccessibilityTilemapEntry;
        _tilemapActions.setPlacingAccessibilityTilemapAction -= SetPlacingAccessibilityTilemap;
    }

    [Header("Tilemaps")]
    // Construction Tilemap
    [SerializeField] private Tilemap _constructionTilemap;
    private void SetConstructionTilemapEntry(Vector3Int[] positions, GameObject construction)
    {
        _constructionTilemap.SetTile(positions[0], construction.GetComponent<ConstructionBehaviour>().type.ruleTile);
    }
    private void SetConstructionTilemap(Dictionary<Vector3Int[], GameObject> map)
    {
        TileBase[] constructions = map.Values.Select(x => x.GetComponent<ConstructionBehaviour>().type.ruleTile).ToArray();
        _constructionTilemap.ClearAllTiles();
        foreach (Vector3Int[] positions in map.Keys)
            _constructionTilemap.SetTiles(positions, constructions);
    }

    // Resource Tilemap
    [SerializeField] private Tilemap _resourceTilemap;
    private void SetResourceTilemapEntry(Vector3Int position, ResourceItemSO resource)
    {
        _resourceTilemap.SetTile(position, resource?.ruleTile);
    }
    private void SetResourceTilemap(Dictionary<Vector3Int, ResourceItemSO> resources)
    {
        _resourceTilemap.ClearAllTiles();
        _resourceTilemap.SetTiles(resources.Keys.ToArray(), resources.Values.Select(x => x.ruleTile).ToArray());
    }

    // Walkable Nature Tilemap
    [SerializeField] private Tilemap _walkableNatureTilemap;
    private void SetWalkableNatureTilemapEntry(Vector3Int position, MapZone mapZone)
    {
        _walkableNatureTilemap.SetTile(position, mapZone.ruleTile);
    }
    private void SetWalkableNatureTilemap(Dictionary<Vector3Int, MapZone> mapZones)
    {
        _walkableNatureTilemap.ClearAllTiles();
        _walkableNatureTilemap.SetTiles(mapZones.Keys.ToArray(), mapZones.Values.Select(x => x.ruleTile).ToArray());
    }

    // Unwalkable Nature Tilemap
    [SerializeField] private Tilemap _unWalkableNatureTilemap;
    private void SetUnWalkableNatureTilemapEntry(Vector3Int position, MapZone mapZone)
    {
        _unWalkableNatureTilemap.SetTile(position, mapZone.ruleTile);
        UpdateCollider();
    }
    private void SetUnWalkableNatureTilemap(Dictionary<Vector3Int, MapZone> mapZones)
    {
        _unWalkableNatureTilemap.ClearAllTiles();
        _unWalkableNatureTilemap.SetTiles(mapZones.Keys.ToArray(), mapZones.Values.Select(x => x.ruleTile).ToArray());
        UpdateCollider();
    }

    // Placing Accessibility Tilemap
    [SerializeField] private Tilemap _placingAccessibilityTilemap;
    private void SetPlacingAccessibilityTilemapEntry(Vector3Int position, bool value)
    {
        TileBase tile = value ? _accessibilityTile : _nonAccessibilityTile;
        _placingAccessibilityTilemap.SetTile(position, tile);
    }
    private void SetPlacingAccessibilityTilemap(Dictionary<Vector3Int, bool> map)
    {
        _placingAccessibilityTilemap.ClearAllTiles();
        _placingAccessibilityTilemap.SetTiles(map.Keys.ToArray(), GetTilesFromBools(map.Values.ToArray()));
    }


    // Get tiles from bool values for placingAccessibilityTilemap
    private TileBase[] GetTilesFromBools(bool[] values)
    {
        TileBase[] tilesFromBools = new TileBase[values.Length];

        for (int i = 0; i < values.Length; i++)
        {
            tilesFromBools[i] = values[i] ? _accessibilityTile : _nonAccessibilityTile;
        }

        return tilesFromBools;
    }


    private void UpdateCollider()
    {
        TilemapCollider2D collider = _unWalkableNatureTilemap.GetComponent<TilemapCollider2D>();
        collider.ProcessTilemapChanges();
        collider.composite.GenerateGeometry();
    }
}
