using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ConstructionActions class is responsible for any Construction actions.
/// </summary>
public class ConstructionActions : ScriptableObject
{
    // Actions
    public Action<Vector3Int[], GameObject> placeConstructionAction;
    public Action<Dictionary<Vector3Int[], GameObject>> placeConstructionMapAction;


    public void OnPlaceConstruction(Vector3Int[] positions, GameObject construction)
    {
        placeConstructionAction?.Invoke(positions, construction);
    }


    public void OnPlaceConstructionMap(Dictionary<Vector3Int[], GameObject> constructions)
    {
        placeConstructionMapAction?.Invoke(constructions);
    }
}
