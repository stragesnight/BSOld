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
    public Action<Vector3Int, MapZone> setWalkableNatureTilemapEntryAction;
    public Action<Dictionary<Vector3Int, MapZone>> setWalkableNatureTilemapAction;
    // Unwalkable Nature
    public Action<Vector3Int, MapZone> setUnWalkableNatureTilemapEntryAction;
    public Action<Dictionary<Vector3Int, MapZone>> setUnWalkableNatureTilemapAction;
    // Placing accessibility
    public Action<Vector3Int, bool> setPlacingAccessibilityTilemapEntryAction;
    public Action<Dictionary<Vector3Int, bool>> setPlacingAccessibilityTilemapAction;


    // Walkable Nature Tilemap
    public void OnSetWalkableNatureTilemapEntry(Vector3Int position, MapZone mapZone) 
    { 
        setWalkableNatureTilemapEntryAction?.Invoke(position, mapZone);
    }
    public void OnSetWalkableNatureTilemap(Dictionary<Vector3Int, MapZone> mapZones)
    {
        setWalkableNatureTilemapAction?.Invoke(mapZones);
    }

    // Unwalkable Nature Tilemap
    public void OnSetUnWalkableNatureTilemapEntry(Vector3Int position, MapZone mapZone)
    {
        setUnWalkableNatureTilemapEntryAction?.Invoke(position, mapZone);
    }
    public void OnSetUnWalkableNatureTilemap(Dictionary<Vector3Int, MapZone> mapZones)
    {
        setUnWalkableNatureTilemapAction?.Invoke(mapZones);
    }

    // Placing Accessibility Tilemap
    public void OnSetPlacingAccessibilityTilemapEntry(Vector3Int position, bool value) 
    {
        setPlacingAccessibilityTilemapEntryAction?.Invoke(position, value);
    }
    public void OnSetPlacingAccessibilityTilemap(Dictionary<Vector3Int, bool> values)
    {
        setPlacingAccessibilityTilemapAction?.Invoke(values);
    }
}
