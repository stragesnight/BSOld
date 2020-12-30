using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// TilemapActions class is responsible for any Tilemap manipulations.
/// </summary>
public class TilemapActions : ScriptableObject
{
    // Actions

    // Nature
    public Action<Vector3Int, MapZone> OnSetNatureTilemapEntry;
    public Action<Dictionary<Vector3Int, MapZone>> OnSetNatureTilemap;
    // Placing accessibility
    public Action<Vector3Int, bool> OnSetPlacingAccessibilityTilemapEntry;
    public Action<Dictionary<Vector3Int, bool>> OnSetPlacingAccessibilityTilemap;


    // Nature Tilemap
    public void SetNatureTilemapEntry(Vector3Int position, MapZone mapZone) 
    { 
        OnSetNatureTilemapEntry?.Invoke(position, mapZone);
    }
    public void SetNatureTilemap(Dictionary<Vector3Int, MapZone> mapZones)
    {
        OnSetNatureTilemap?.Invoke(mapZones);
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