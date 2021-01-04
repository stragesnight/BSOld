using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// TilemapActions class is responsible for any Tilemap manipulations.
/// </summary>
public class TilemapActions : ScriptableObject
{
    // Actions

    // Walkable Nature
    public Action<Vector3Int, MapZone> OnSetWalkableNatureTilemapEntry;
    public Action<Dictionary<Vector3Int, MapZone>> OnSetWalkableNatureTilemap;
    // Unwalkable Nature
    public Action<Vector3Int, MapZone> OnSetUnWalkableNatureTilemapEntry;
    public Action<Dictionary<Vector3Int, MapZone>> OnSetUnWalkableNatureTilemap;
    // Placing accessibility
    public Action<Vector3Int, bool> OnSetPlacingAccessibilityTilemapEntry;
    public Action<Dictionary<Vector3Int, bool>> OnSetPlacingAccessibilityTilemap;


    // Walkable Nature Tilemap
    public void SetWalkableNatureTilemapEntry(Vector3Int position, MapZone mapZone) 
    { 
        OnSetWalkableNatureTilemapEntry?.Invoke(position, mapZone);
    }
    public void SetWalkableNatureTilemap(Dictionary<Vector3Int, MapZone> mapZones)
    {
        OnSetWalkableNatureTilemap?.Invoke(mapZones);
    }

    // Unwalkable Nature Tilemap
    public void SetUnWalkableNatureTilemapEntry(Vector3Int position, MapZone mapZone)
    {
        OnSetUnWalkableNatureTilemapEntry?.Invoke(position, mapZone);
    }
    public void SetUnWalkableNatureTilemap(Dictionary<Vector3Int, MapZone> mapZones)
    {
        OnSetUnWalkableNatureTilemap?.Invoke(mapZones);
    }

    // Placing Accessibility Tilemap
    public void SetPlacingAccessibilityTilemapEntry(Vector3Int position, bool value) 
    {
        OnSetPlacingAccessibilityTilemapEntry?.Invoke(position, value);
    }
    public void SetPlacingAccessibilityTilemap(Dictionary<Vector3Int, bool> values)
    {
        OnSetPlacingAccessibilityTilemap?.Invoke(values);
    }
}