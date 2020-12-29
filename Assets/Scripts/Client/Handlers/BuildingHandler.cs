using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// BuildingHandler class is responcible for Building manipulations.
/// </summary>
public class BuildingHandler : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private BuildingActions buildingActions;

    /// <summary>
    /// Transform that will be parent object for all Buildings
    /// </summary>
    [SerializeField] private Transform parentTransform;


    // Subscrible to Actions
    private void OnEnable()
    {
        buildingActions.OnPlaceBuilding += InstantiateBuildingObject;
        buildingActions.OnPlaceBuildingMap += InstantiateBuildingMap;
    }

    // Unsubscribe from Actions
    private void OnDisable()
    {
        buildingActions.OnPlaceBuilding -= InstantiateBuildingObject;
        buildingActions.OnPlaceBuildingMap -= InstantiateBuildingMap;
    }


    // Instantiate desired Building prefab and set parent
    private void InstantiateBuildingObject(Vector3Int position, BuildingSO building)
    {
        GameObject buildingObject = Instantiate(building.prefab);
        buildingObject.transform.position = position;
        buildingObject.transform.SetParent(parentTransform);
    }


    // Instantiate entire Building map
    private void InstantiateBuildingMap(Dictionary<Vector3Int, BuildingSO> buildings)
    {
        ClearParent();

        foreach (Vector3Int position in buildings.Keys)
        {
            InstantiateBuildingObject(position, buildings[position]);
        }
    }


    // Clear all children from parent Trasform
    private void ClearParent()
    {
        // This approach is more reliable than just looping through every child and destroying it
        while (parentTransform.childCount > 0)
        {
            DestroyImmediate(parentTransform.GetChild(0));
        }
    }
}