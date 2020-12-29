using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// TilemapActions class is responsible for any Tilemap manipulations.
/// </summary>
public class TilemapActions : ScriptableObject
{
    // Actions

    // Resource
    public Action<Vector3Int, TileBase> OnSetResourceTilemapEntry;
    public Action<Dictionary<Vector3Int, TileBase>> OnSetResourceTilemap;
    // Nature
    public Action<Vector3Int, TileBase> OnSetNatureTilemapEntry;
    public Action<Dictionary<Vector3Int, TileBase>> OnSetNatureTilemap;
    // Placing accessibility
    public Action<Vector3Int, bool> OnSetPlacingAccessibilityTilemapEntry;
    public Action<Dictionary<Vector3Int, bool>> OnSetPlacingAccessibilityTilemap;


    // Resource Tilemap
    public void SetResourceTilemapEntry(Vector3Int position, TileBase tile) 
    { 
        OnSetResourceTilemapEntry?.Invoke(position, tile);
    }
    public void SetResourceTilemap(Dictionary<Vector3Int, TileBase> tiles)
    {
        OnSetResourceTilemap?.Invoke(tiles);
    }

    // Nature Tilemap
    public void SetNatureTilemapEntry(Vector3Int position, TileBase tile) 
    { 
        OnSetNatureTilemapEntry?.Invoke(position, tile);
    }
    public void SetNatureTilemap(Dictionary<Vector3Int, TileBase> tiles)
    {
        OnSetNatureTilemap?.Invoke(tiles);
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