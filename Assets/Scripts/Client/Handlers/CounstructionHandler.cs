using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// CounstructionHandler class is responcible for Construction manipulations.
/// </summary>
public class CounstructionHandler : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private ConstructionActions _constructionActions;

    /// <summary>
    /// Transform that will be parent object for all Buildings
    /// </summary>
    [SerializeField] private Transform _parentTransform;


    // Subscrible to Actions
    private void OnEnable()
    {
        _constructionActions.placeConstructionAction += InstantiateConstructionObject;
        _constructionActions.placeConstructionMapAction += InstantiateConstructionMap;
    }

    // Unsubscribe from Actions
    private void OnDisable()
    {
        _constructionActions.placeConstructionAction -= InstantiateConstructionObject;
        _constructionActions.placeConstructionMapAction -= InstantiateConstructionMap;
    }


    // Instantiate desired Construction prefab and set parent
    private void InstantiateConstructionObject(Vector3Int[] positions, GameObject construction)
    {
        // Instantiate prefab
        GameObject buildingObject = Instantiate(construction);

        // Apply proper object parameters
        buildingObject.transform.position = positions[0];
        buildingObject.transform.SetParent(_parentTransform);

        // Set Construction at point (now as GameObject in scene, not as prefab)
        MapData.Instance.SetConstructionAtPoint(positions, buildingObject);

        // Make all tiles taken by construction inaccessible
        foreach (Vector3Int position in positions)
            MapData.Instance.SetPlacingAccessibilityMapAtPoint(position, false);
    }


    // Instantiate entire Construction map
    private void InstantiateConstructionMap(Dictionary<Vector3Int[], GameObject> constructions)
    {
        ClearParent();

        foreach (Vector3Int[] positions in constructions.Keys)
        {
            InstantiateConstructionObject(positions, constructions[positions]);
        }
    }


    // Clear all children from parent Trasform
    private void ClearParent()
    {
        // This approach is more reliable than just looping through every child and destroying it
        while (_parentTransform.childCount > 0)
        {
            DestroyImmediate(_parentTransform.GetChild(0));
        }
    }
}
