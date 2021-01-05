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
        constructionActions.placeConstructionAction += SetConstructionTilemapEntry;
        constructionActions.placeConstructionMapAction += SetConstructionTilemap;
        // Resource Rilemap
        resourceActions.setResouceAtPointAction += SetResourceTilemapEntry;
        resourceActions.setResourceMapAction += SetResourceTilemap;
        // Walkable Nature Tilemap
        tilemapActions.setWalkableNatureTilemapEntryAction += SetWalkableNatureTilemapEntry;
        tilemapActions.setWalkableNatureTilemapAction += SetWalkableNatureTilemap;
        // Unwalkable Nature Tilemap
        tilemapActions.setUnWalkableNatureTilemapEntryAction += SetUnWalkableNatureTilemapEntry;
        tilemapActions.setUnWalkableNatureTilemapAction += SetUnWalkableNatureTilemap;
        // Placing Accessibility Tilemap
        tilemapActions.setPlacingAccessibilityTilemapEntryAction += SetPlacingAccessibilityTilemapEntry;
        tilemapActions.setPlacingAccessibilityTilemapAction += SetPlacingAccessibilityTilemap;
    }

    // Unsubscribe from Actions
    private void OnDisable()
    {
        // Buildings
        constructionActions.placeConstructionAction -= SetConstructionTilemapEntry;
        constructionActions.placeConstructionMapAction -= SetConstructionTilemap;
        // Resource Rilemap
        resourceActions.setResouceAtPointAction -= SetResourceTilemapEntry;
        resourceActions.setResourceMapAction -= SetResourceTilemap;
        // Walkable Nature Tilemap
        tilemapActions.setWalkableNatureTilemapEntryAction -= SetWalkableNatureTilemapEntry;
        tilemapActions.setWalkableNatureTilemapAction -= SetWalkableNatureTilemap;
        // Unwalkable Nature Tilemap
        tilemapActions.setUnWalkableNatureTilemapEntryAction -= SetUnWalkableNatureTilemapEntry;
        tilemapActions.setUnWalkableNatureTilemapAction -= SetUnWalkableNatureTilemap;
        // Placing Accessibility Tilemap
        tilemapActions.setPlacingAccessibilityTilemapEntryAction -= SetPlacingAccessibilityTilemapEntry;
        tilemapActions.setPlacingAccessibilityTilemapAction -= SetPlacingAccessibilityTilemap;
    }

    [Header("Tilemaps")]
    // Construction Tilemap
    [SerializeField] private Tilemap constructionTilemap;
    private void SetConstructionTilemapEntry(Vector3Int[] positions, GameObject construction)
    {
        constructionTilemap.SetTile(positions[0], construction.GetComponent<ConstructionBehavoiur>().type.ruleTile);
    }
    private void SetConstructionTilemap(Dictionary<Vector3Int[], GameObject> map)
    {
        TileBase[] constructions = map.Values.Select(x => x.GetComponent<ConstructionBehavoiur>().type.ruleTile).ToArray();
        constructionTilemap.ClearAllTiles();
        foreach (Vector3Int[] positions in map.Keys)
            constructionTilemap.SetTiles(positions, constructions);
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
        UpdateCollider();
    }
    private void SetUnWalkableNatureTilemap(Dictionary<Vector3Int, MapZone> mapZones)
    {
        unWalkableNatureTilemap.ClearAllTiles();
        unWalkableNatureTilemap.SetTiles(mapZones.Keys.ToArray(), mapZones.Values.Select(x => x.ruleTile).ToArray());
        UpdateCollider();
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


    private void UpdateCollider()
    {
        TilemapCollider2D collider = unWalkableNatureTilemap.GetComponent<TilemapCollider2D>();
        collider.ProcessTilemapChanges();
        collider.composite.GenerateGeometry();
    }
}