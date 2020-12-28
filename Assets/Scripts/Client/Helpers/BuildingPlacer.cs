using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// BuildingPlacer class is responsible for placing buildings onto game map. Use BuildingPlacer.Instance to reference it everywhere
/// </summary>
public class BuildingPlacer : MonoBehaviour
{
    [SerializeField] private Transform parentTransform;

    // Actions
    public Action<Vector3Int, BuildingSO> OnPlaceBuilding;
    public Action<Dictionary<Vector3Int, BuildingSO>> OnPlaceBuildingMap;


    public void PlaceBuilding(Vector3Int position, BuildingSO building)
    {
        GameObject buildingObject = Instantiate(building.prefab);
        buildingObject.transform.position = position;
        buildingObject.transform.SetParent(parentTransform);

        OnPlaceBuilding?.Invoke(position, building);
    }


    public void PlaceBuildingMap(Dictionary<Vector3Int, BuildingSO> buildings)
    {
        ClearParent();

        foreach (Vector3Int position in buildings.Keys)
        {
            PlaceBuilding(position, buildings[position]);
        }

        OnPlaceBuildingMap?.Invoke(buildings);
    }


    private void ClearParent()
    {
        while(parentTransform.childCount > 0)
        {
            DestroyImmediate(parentTransform.GetChild(0));
        }
    }
}