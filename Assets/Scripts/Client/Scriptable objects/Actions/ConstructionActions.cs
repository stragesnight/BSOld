using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ConstructionActions class is responsible for any Construction actions.
/// </summary>
public class ConstructionActions : ScriptableObject
{
    // Actions
    public Action<Vector3Int, ConstructionSO> OnPlaceConstruction;
    public Action<Dictionary<Vector3Int, ConstructionSO>> OnPlaceBuildingMap;


    public void PlaceBuilding(Vector3Int position, ConstructionSO construction)
    {
        OnPlaceConstruction?.Invoke(position, construction);
    }


    public void PlaceBuildingMap(Dictionary<Vector3Int, ConstructionSO> construction)
    {
        OnPlaceBuildingMap?.Invoke(construction);
    }
}