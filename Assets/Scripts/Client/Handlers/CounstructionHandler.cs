using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// CounstructionHandler class is responcible for Construction manipulations.
/// </summary>
public class CounstructionHandler : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private ConstructionActions constructionActions;

    /// <summary>
    /// Transform that will be parent object for all Buildings
    /// </summary>
    [SerializeField] private Transform parentTransform;


    // Subscrible to Actions
    private void OnEnable()
    {
        constructionActions.placeConstructionAction += InstantiateConstructionObject;
        constructionActions.placeConstructionMapAction += InstantiateConstructionMap;
    }

    // Unsubscribe from Actions
    private void OnDisable()
    {
        constructionActions.placeConstructionAction -= InstantiateConstructionObject;
        constructionActions.placeConstructionMapAction -= InstantiateConstructionMap;
    }


    // Instantiate desired Construction prefab and set parent
    private void InstantiateConstructionObject(Vector3Int position, GameObject construction)
    {
        GameObject buildingObject = Instantiate(construction);
        buildingObject.transform.position = position;
        buildingObject.transform.SetParent(parentTransform);
    }


    // Instantiate entire Construction map
    private void InstantiateConstructionMap(Dictionary<Vector3Int, GameObject> constructions)
    {
        ClearParent();

        foreach (Vector3Int position in constructions.Keys)
        {
            InstantiateConstructionObject(position, constructions[position]);
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