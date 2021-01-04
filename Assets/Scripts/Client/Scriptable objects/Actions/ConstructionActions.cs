using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ConstructionActions class is responsible for any Construction actions.
/// </summary>
public class ConstructionActions : ScriptableObject
{
    // Actions
    public Action<Vector3Int, ConstructionSO> placeConstructionAction;
    public Action<Dictionary<Vector3Int, ConstructionSO>> placeConstructionMapAction;


    public void OnPlaceConstruction(Vector3Int position, ConstructionSO construction)
    {
        placeConstructionAction?.Invoke(position, construction);
    }


    public void OnPlaceConstructionMap(Dictionary<Vector3Int, ConstructionSO> construction)
    {
        placeConstructionMapAction?.Invoke(construction);
    }
}