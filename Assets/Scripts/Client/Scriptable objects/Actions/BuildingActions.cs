using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// BuildingActions class is responsible for any Building actions.
/// </summary>
public class BuildingActions : ScriptableObject
{
    // Actions
    public Action<Vector3Int, BuildingSO> OnPlaceBuilding;
    public Action<Dictionary<Vector3Int, BuildingSO>> OnPlaceBuildingMap;


    public void PlaceBuilding(Vector3Int position, BuildingSO building)
    {
        OnPlaceBuilding?.Invoke(position, building);
    }


    public void PlaceBuildingMap(Dictionary<Vector3Int, BuildingSO> buildings)
    {
        OnPlaceBuildingMap?.Invoke(buildings);
    }
}