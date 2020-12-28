using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// BuildingPlacer class is responsible for placing buildings onto game map. Use BuildingPlacer.Instance to reference it everywhere
/// </summary>
public class BuildingPlacer : MonoBehaviour
{
    [SerializeField] private Transform parentTransform;

    public static BuildingPlacer Instance;

    private void Awake()
    {
        CheckInstance();
    }


    public void PlaceBuilding(Vector3Int position, BuildingSO building)
    {
        GameObject buildingObject = Instantiate(building.prefab);
        buildingObject.transform.position = position;
        buildingObject.transform.SetParent(parentTransform);
    }


    public void PlaceBuildingMap(Dictionary<Vector3Int, BuildingSO> buildings)
    {
        ClearParent();

        foreach (Vector3Int position in buildings.Keys)
        {
            PlaceBuilding(position, buildings[position]);
        }
    }


    private void ClearParent()
    {
        while(parentTransform.childCount > 0)
        {
            DestroyImmediate(parentTransform.GetChild(0));
        }
    }


    private void CheckInstance() { if (Instance == null) Instance = this; }
}